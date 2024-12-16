using UnityEngine;
using Zenject;
using Scripts.Systems.Camera.GridView.View;
using Scripts.Tools.Attributes;

namespace Scripts.Systems.Camera.GridView
{
    public sealed class GridViewInstaller : MonoInstaller
    {
        [SerializeField] private Config _config;
        [SerializeField] private ViewSettings _viewSettings;
        [SerializeField] private SceneSettings _sceneSettings;
        
        public override void InstallBindings() {
            // Entities / Intermediaries
            Container.BindInterfacesAndSelfTo<Swapper>().AsSingle().WithArguments(_sceneSettings.Camera);
            Container.Bind<IZoom>().To<Zoom>().AsSingle().WithArguments(_sceneSettings.Camera, _config);
            Container.Bind<IFocusCatcher>().To<FocusCatcher>().AsSingle().WithArguments(_sceneSettings.Camera, _config);
            Container.Bind<IFocusable>().To<FocusFollower>().AsSingle().WithArguments(_sceneSettings.Camera);
            Container.BindInterfacesAndSelfTo<LocationViewer>().AsSingle().WithArguments(_sceneSettings.Camera, _config.ViewLocationSettings);
            
            Container.BindInterfacesAndSelfTo<GridViewer>().AsSingle();

            Container.Bind<FocusState>().AsSingle();
            Container.Bind<SwapState>().AsSingle();

            Container.Bind<ViewModule>().AsSingle();
        }
    }
}