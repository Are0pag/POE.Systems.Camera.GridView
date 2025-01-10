using System.Threading;
using Cysharp.Threading.Tasks;
using POE.Systems.Camera.LocationView;
using Scripts.Tools.AsyncOperationsHandle;

namespace Scripts.Systems.Camera.LocationView
{
    internal class SkipLocationViewAsyncOperation : IAsyncOperation
    {
        protected readonly LocationViewAsyncOperation _locationViewOperation;

        public SkipLocationViewAsyncOperation(LocationViewAsyncOperation locationViewOperation) {
            _locationViewOperation = locationViewOperation;
        }

        async UniTask IAsyncOperation.RunAsyncOperation(CancellationTokenSource cts) {
            await _locationViewOperation.Skip();
        }
    }
}