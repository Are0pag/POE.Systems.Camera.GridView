namespace Scripts.Systems.Camera.GridView
{
    internal interface IFocusTargetHandler : IGridViewSubscriber
    {
        void SetFocusTarget(UnityEngine.Transform focusTarget);
    }
}