using System.Diagnostics.CodeAnalysis;
using Scripts.Services.EventBus;
using Zenject;

namespace Scripts.Systems.Camera.GridView
{
    internal class GridViewer : ITickable //  IZoomHandler (не забыв про то, что эти методы асинхронные)
    {
        internal protected CameraState CurrentState { get; protected set; }

        internal void SwitchState([DisallowNull] CameraState newState) {
            CurrentState = newState;
        }

        void ITickable.Tick() => CurrentState?.Update();
    }
}