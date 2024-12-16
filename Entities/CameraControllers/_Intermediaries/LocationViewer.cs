using System;
using System.Reflection;
using Cysharp.Threading.Tasks;
using Scripts.Tools.CustomEdit;
using Scripts.Tools.Interpolation;
using UnityEngine;

namespace Scripts.Systems.Camera.GridView
{
    internal class LocationViewer : IFreeCamera
    {
        protected readonly IFocusCatcher _focusCatcher;
        protected readonly UnityEngine.Camera _camera;
        protected readonly PropertyInfo _fieldInfo = typeof(Transform).GetProperty("position");
        protected readonly ViewLocationSettings _settings;
        protected AsyncOperationHandler _operationHandler;
        protected float _timeOfMoveByOneInterval;
        protected Vector3 _startPosition;

        internal bool IsCancellationRequests;

        internal LocationViewer(UnityEngine.Camera camera, ViewLocationSettings settings, IFocusCatcher focusCatcher) {
            _camera = camera;
            _settings = settings;
            _focusCatcher = focusCatcher;
        }

        public async UniTask ShowMapAsyncRecursive(ShowMapArgs args) {
            IsCancellationRequests = false;
            _startPosition = args.MovePointsTrace.Peek();
            _timeOfMoveByOneInterval = _settings.TimeOfView / args.MovePointsTrace.Count - 1;

            await _focusCatcher.MoveAt(new MoveToSelectedItemArgs(_startPosition));

            try {
                await ShowIntervalAsyncRecursive(args);
            }
            catch (StackOverflowException overflow) {
                #if UNITY_EDITOR
                    ExceptionLogger.Log(overflow, this);
                #endif
            }
            catch (InvalidOperationException e) {
                #if UNITY_EDITOR
                    ExceptionLogger.Log(e, this);
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
                byTime: _timeOfMoveByOneInterval);
            
            await _operationHandler.RunAsync();
            await ShowIntervalAsyncRecursive(args);
        }

        protected async UniTask ReturnToStartAsync() {
            CreateOperation(_camera.transform.position, _startPosition, _settings.TimeReturn);
            await _operationHandler.RunAsync();
        }

        public void Cancel() {
            IsCancellationRequests = true;
            _operationHandler.Cancel();
        }

        protected void CreateOperation(Vector3 startPosition, Vector3 targetPosition, float byTime) {
            _operationHandler = new AsyncOperationHandler(new InterpolationLinearVector3<Transform>(
                _camera.transform,
                _fieldInfo,
                new Vector3(startPosition.x, startPosition.y, Config.CAMERA_POS_Z),
                 new Vector3(targetPosition.x, targetPosition.y, Config.CAMERA_POS_Z),
                byTime
            ));
        }
    }
}