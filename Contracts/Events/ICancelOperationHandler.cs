namespace Scripts.Systems.Camera.GridView
{
    internal interface ICancelOperationHandler : IGridViewSubscriber
    {
        void CancelOperations();
    }
}