namespace Scripts.Systems.Camera.GridView
{
    internal interface IFocusTargetResolver : IGridViewSubscriber
    {
        void OnFocusMissingTarget(IFocusable focusable);
    }
}