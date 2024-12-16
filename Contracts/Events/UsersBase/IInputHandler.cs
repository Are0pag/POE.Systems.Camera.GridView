using System.Threading;
using Cysharp.Threading.Tasks;
using Scripts.Services.EventBus;
using Scripts.Tools.Interpolation;

namespace Scripts.Systems.Camera.GridView
{
    public interface IInputHandler : IExternalGridViewEventHandler
    {
        void OnMouseButtonDown();
        void OnMouseButtonUp();
    }
    
    /* To use for invoke async events */
    public interface ILocationViewHandler : IExternalGridViewEventHandler
    {
        void OnLocationView(AsyncOperationHandlerInitialized asyncOperationHandlerInitiali);
    }

    public class Controllerr
    {
        private AsyncOperationHandlerInitialized _asyncOperationHandlerInitiali;
        
        public async void OnMouseButtonDown() {
            EventBus<IExternalGridViewEventHandler>.RaiseEvent<ILocationViewHandler>(h => h.OnLocationView(_asyncOperationHandlerInitiali));
            await _asyncOperationHandlerInitiali.RunAsync();
        }
    }

    public class C : ILocationViewHandler
    {
        protected readonly F _f = new F();
        
        public void OnMouseButtonDown() {
            EventBus<IExternalGridViewEventHandler>.Subscribe(this);
        }

        public void OnLocationView(AsyncOperationHandlerInitialized asyncOperationHandlerInitiali) {
            asyncOperationHandlerInitiali.Initialize(_f);
        }
    }

    public class F : IAsyncOperation
    {
        public async UniTask RunAsyncOperation(CancellationTokenSource cts) {
            await UniTask.Yield();
        }
    }
}