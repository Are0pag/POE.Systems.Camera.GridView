namespace Scripts.Systems.Camera.GridView
{
    public interface IFocusTargetRequestHandler : IExternalGridViewEventHandler {
        void GetTarget(IFocusTargetContainer focusTargetContainer);
    }
}