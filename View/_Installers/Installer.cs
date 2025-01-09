using UnityEngine;
using Zenject;

namespace Scripts.Systems.Camera.LocationView.View
{
    public class Installer : MonoInstaller
    {
        [SerializeField] private ViewSettings _settings;
        
        public override void InstallBindings() {
            Container.Bind<FocusButton>().AsSingle().WithArguments(_settings.FocusButtonStyle);
            Container.Bind<SwapButton>().AsSingle().WithArguments(_settings.SwapButtonStyle);
            Container.Bind<CameraModeInput>().AsSingle();
            Container.Bind<LocationViewUI>().AsSingle();
        }
    }
}