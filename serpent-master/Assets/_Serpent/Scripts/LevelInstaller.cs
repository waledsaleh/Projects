using Zenject;

namespace Serpent {

    public class LevelInstaller : MonoInstaller {
        public FoodSpawner.Config foodSpawnerConfig;
        public LevelSurface.Config levelSurfaceConfig;

        public override void InstallBindings() {
            Container.BindInstance(foodSpawnerConfig);
            Container.BindAllInterfacesAndSelf<FoodSpawner>().To<FoodSpawner>().AsSingle();

            Container.BindInstance(levelSurfaceConfig);
            Container.Bind<LevelSurface>().AsSingle();
        }
    }

} // namespace Serpent
