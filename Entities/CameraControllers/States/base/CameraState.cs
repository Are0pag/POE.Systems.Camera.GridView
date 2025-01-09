namespace Scripts.Systems.Camera.LocationView
{
    public abstract class CameraState
    {
        internal abstract void UpdateState();

        internal virtual void OnEnterState() {
            
        }

        internal virtual void OnExitState() {
            
        }
    }
}