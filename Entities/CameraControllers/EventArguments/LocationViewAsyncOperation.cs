using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Scripts.Tools;
using Scripts.Tools.AsyncOperationsHandle;
using Scripts.Tools.Interpolation;
using UnityEngine;

#if UNITY_EDITOR
    using Scripts.Tools.CustomEdit;
#endif

namespace Scripts.Systems.Camera.GridView
{
    internal class LocationViewAsyncOperation : IAsyncOperation
    {
        protected readonly ShowMapArgs _args;
        protected private readonly IFocusCatcher _focusCatcher;
        protected readonly UnityEngine.Camera _camera;
        protected private readonly ViewLocationSettings _settings;
        protected AsyncOperationHandler _operationHandler;

        internal bool IsCancellationRequests;
        
        internal LocationViewAsyncOperation(UnityEngine.Camera camera, ViewLocationSettings settings, IFocusCatcher focusCatcher, ShowMapArgs args) {
            _camera = camera;
            _settings = settings;
            _focusCatcher = focusCatcher;
            _args = args;
        }
        
        public async UniTask RunAsyncOperation(CancellationTokenSource cts) {
            await ShowMapAsyncRecursive();
        }
        
        public async UniTask ShowMapAsyncRecursive() {
            IsCancellationRequests = false;

            await _focusCatcher.MoveAt(new MoveToSelectedItemArgs(_args.StartPosition));

            try {
                await ShowIntervalAsyncRecursive(_args);
            }
            catch (StackOverflowException overflow) {
#if UNITY_EDITOR
                overflow.Log(this);
#endif
            }
            catch (InvalidOperationException e) {
#if UNITY_EDITOR
                e.Log(this);
#endif
            }
            await ReturnToStartAsync();
        }

        protected async UniTask ShowIntervalAsyncRecursive(ShowMapArgs args) {
            if (args.MovePointsTrace.Count < 2 && IsCancellationRequests)
                return;
            
            CreateOperation(
                startPosition: args.MovePointsTrace.Dequeue(), 
                targetPosition: args.MovePointsTrace.Peek(), 
                byTime: _settings.TimeOfMovingOneWayPoint);
            
            await _operationHandler.RunAsync();
            await ShowIntervalAsyncRecursive(args);
        }

        protected async UniTask ReturnToStartAsync() {
            CreateOperation(_camera.transform.position, _args.StartPosition, _settings.TimeReturn);
            await _operationHandler.RunAsync();
        }

        public void Cancel() {
            IsCancellationRequests = true;
            _operationHandler.Cancel();
        }

        protected void CreateOperation(Vector3 startPosition, Vector3 targetPosition, float byTime) {
            _operationHandler = new AsyncOperationHandler(new InterpolationLinearVector3<Transform>(
                _camera.transform,
                PropInfos.PosTransform,
                new Vector3(startPosition.x, startPosition.y, Config.CAMERA_POS_Z),
                new Vector3(targetPosition.x, targetPosition.y, Config.CAMERA_POS_Z),
                byTime
            ));
        }
    }
}