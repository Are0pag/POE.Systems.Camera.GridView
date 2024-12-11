

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

    // Неплоxо было бы иметь сслку на EventBus и уже там определить эти аргументы

    /*
    Action actEvent;
    UnityAction unityEvent; // especially used in uGUI

        // Bad: async void
    actEvent += async () => { };
    unityEvent += async () => { };

        // Ok: create Action delegate by lambda
    actEvent += UniTask.Action(async () => { await UniTask.Yield(); });
    unityEvent += UniTask.UnityAction(async () => { await UniTask.Yield(); });
    */
}