namespace Scripts.Systems.Camera.LocationView
{
    public interface IFocusTargetRequestHandler : IExternalLocationViewEventSubscriber {
        void GetTarget(IFocusTargetContainer focusTargetContainer);
    }
}