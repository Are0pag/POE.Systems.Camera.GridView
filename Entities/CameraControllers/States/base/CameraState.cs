namespace Scripts.Systems.Camera.GridView
{
    public abstract class CameraState
    {
        internal abstract void Update();

        internal virtual void OnExit() {
            
        }
    }
}