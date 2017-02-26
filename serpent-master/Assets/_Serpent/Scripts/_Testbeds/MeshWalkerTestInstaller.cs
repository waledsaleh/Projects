using UnityEngine;
using System.Collections;
using Zenject;

namespace Serpent {

    public class MeshWalkerTestInstaller : MonoInstaller {
        public LevelSurface.Config levelSurfaceConfig;

        public override void InstallBindings() {
            Container.BindInstance(levelSurfaceConfig);
            Container.Bind<LevelSurface>().AsSingle();
        }
    }

} // namespace Serpent
