using UnityEngine;
using System.Collections;

namespace Serpent {

    /*
     * Why functionality is isolated inside static class:
     *   - Guarantees the separation of resource generation and management
     *     (user code cares about leaks itself)
     *   - Makes dependencies between methods more obvious
     *   - Don't care about MonoBehaviour-related code
     * 
     * TODO:
     *   - Ensure that resources are disposed properly
     *   - Interpolate height value in GetHeightAt()
     */
    
    public static class PlanetSurfaceBuilder {
        
        [System.Serializable]
        public class Config {
            public const int kMaxSubdivisionLevel = 5;

            [Range(0, kMaxSubdivisionLevel)]
            public int subdivisionLevel = 4;
            public float radius = 25;
            public float oceanDepth = 2, mountainHeight = 2;
            public bool flipInsideOut = false;

            public int heightCubemapSize = 64;
            public double noiseScale = 0.5;
            public int octaves = 3;
            public int seed = 123321;
        }

        public struct Result {
            public Cubemap heightMap;
            public Mesh mesh;
        }
        
        public static Result Build(Config cfg) {
            var result = new Result();

            Mesh mesh = Icosphere.Create(cfg.subdivisionLevel, cfg.radius);
            if (cfg.flipInsideOut)
                mesh.FlipNormals();

            Cubemap heightMap = GenerateHeightmap(cfg);
            ApplyDisplacementMap(cfg, heightMap, mesh);

            System.GC.Collect();

            result.heightMap = heightMap;
            result.mesh = mesh;

            return result;
        }


        #region Private part

        private static float GetHeightAt(Config cfg, Cubemap heightMap, Vector3 radiusVector) {
            Color pixel = CubemapProjections.ReadPixel(heightMap, radiusVector);

            // Altitude above water level
            float heightDelta = pixel.r * (cfg.oceanDepth + cfg.mountainHeight) - cfg.oceanDepth;

            return cfg.radius + heightDelta;
        }
        
        /// <param name="mesh">Icosphere mesh</param>
        private static void ApplyDisplacementMap(Config cfg, Cubemap heightMap, Mesh mesh) {
            Vector3[] vertices = mesh.vertices;
            for (int i = 0; i < vertices.Length; ++i) {
                float height = GetHeightAt(cfg, heightMap, vertices[i]);
                vertices[i] = vertices[i].normalized * height;
            }

            mesh.vertices = vertices;
            mesh.RecalculateNormals();
            mesh.RecalculateBounds();
        }

        private static Cubemap GenerateHeightmap(Config cfg) {
            Random.State savedState = Random.state;

            int size = cfg.heightCubemapSize;
            Cubemap heightMap = new Cubemap(size, TextureFormat.RGB24, false);

            // Pixels are laid out right to left, top to bottom
            Color[] pixels = new Color[size * size];
            Color pixel = new Color();

            var generator = new LibNoise.Generator.Perlin();
            generator.Frequency = cfg.noiseScale;
            generator.OctaveCount = cfg.octaves;
            generator.Seed = cfg.seed;
            
            foreach (CubemapFace face in System.Enum.GetValues(typeof(CubemapFace))) {
                if (face == CubemapFace.Unknown)
                    continue;

                for (int y = 0; y < size; ++y) {
                    for (int x = 0; x < size; ++x) {
                        Vector2 uv = new Vector2((float)x / (size - 1), (float)y / (size - 1));
                        Vector3 radiusVec = CubemapProjections.GetRadiusVectorFromFace(face, uv);

                        /*pixel.r = (radius.x + 1) * 0.5f;
                        pixel.g = (radius.y + 1) * 0.5f;
                        pixel.b = (radius.z + 1) * 0.5f;*/

                        float height = (float)generator.GetValue(radiusVec * cfg.radius);
                        height = (height + 1) * 0.5f;
                        pixel.r = pixel.g = pixel.b = height;

                        pixels[x + y * size] = pixel;
                    }
                }

                heightMap.SetPixels(pixels, face);
                heightMap.Apply();
            }


            Random.state = savedState;

            return heightMap;
        }

        #endregion Private part
    }

} // namespace Serpent
