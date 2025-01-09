using System.Diagnostics.CodeAnalysis;
using Scripts.Services.EventBus;
using Scripts.Tools.AsyncOperationsHandle;
using Zenject;

namespace Scripts.Systems.Camera.LocationView
{
    internal class LocationViewController : ITickable, IInitializable, ILateDisposable, IFreeViewHandler
    {
        protected readonly NonUpdatedState _nonUpdatedState;
        
        internal protected CameraState CurrentState { get; protected set; }

        internal LocationViewController(NonUpdatedState nonUpdatedState) {
            _nonUpdatedState = nonUpdatedState;
        }
        
        internal void SwitchState([DisallowNull] CameraState newState) {
            CurrentState?.OnExitState();
            CurrentState = newState;
            newState?.OnEnterState();
        }

        void ITickable.Tick() 
            => CurrentState?.UpdateState();

        void IInitializable.Initialize() 
            => EventBus<IExternalLocationViewEventSubscriber>.Subscribe(this);

        void ILateDisposable.LateDispose() 
            => EventBus<IExternalLocationViewEventSubscriber>.Unsubscribe(this);

        void IFreeViewHandler.OnViewLocation(ShowMapArgs args, IAsyncOperationHandlerInitialized asyncOperationHandler) 
            => SwitchState(_nonUpdatedState);
    }
}