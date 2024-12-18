using System.Diagnostics.CodeAnalysis;
using Zenject;

namespace Scripts.Systems.Camera.GridView
{
    internal class GridViewer : ITickable
    {
        internal protected CameraState CurrentState { get; protected set; }

        internal void SwitchState([DisallowNull] CameraState newState) {
            CurrentState.OnExit();
            CurrentState = newState;
        }

        void ITickable.Tick() => CurrentState?.Update();
    }
}