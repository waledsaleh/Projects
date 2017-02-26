using UnityEngine;
using System.Collections;

namespace Serpent {

    public class LevelSurface {

        [System.Serializable]
        public class Config {
            public MeshFilter meshFilter;
        }

        public readonly Mesh mesh;
        public readonly MeshIndex meshIndex;

        public LevelSurface(Config config) {
            mesh = config.meshFilter.mesh;

            MeshUtils.ApplyTransformToMesh(config.meshFilter);

            meshIndex = new MeshIndex(mesh);
        }

        public MeshWalker CreateWalker() {
            return new MeshWalker(mesh, meshIndex);
        }
    }

} // namespace Serpent
