

// Считает ли Zenject в методе BindInterfaces<> абстрактный класс как эквивалентную сущность?

namespace Scripts.Systems.Camera.GridView
{
    internal interface IGidViewer
    {
        IFreeCamera FreeCameraComponent { get; }
        
        IFocusable FocusableComponent { get; }
        
        ISwapper SwapComponent { get; }
        
        IZoom ZoomComponent { get; }
    }
}