namespace Scripts.Systems.Camera.GridView
{
    internal interface ICameraModeHandler : IGridViewSubscriber
    {
        void SwitchCameraMode(CameraState newCameraState);
    }
}