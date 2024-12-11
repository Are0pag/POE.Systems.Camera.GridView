using UnityEngine;
using Zenject;

namespace Scripts.Systems.Camera.GridView
{
    public class GridViewInstaller : MonoInstaller
    {
        [SerializeField] private Config _config;
        [SerializeField] private SceneSettings _sceneSettings;
        
        public override void InstallBindings() {
            Container.Bind<ISwapper>().To<Swapper>().AsSingle();
            //Container.BindInterfacesAndSelfTo<GridViewer>().AsSingle();


        }
    }
}