using UnityEngine;
using Zenject;
using System;

namespace Serpent {

    public class FoodSpawner : IInitializable {

        [Serializable]
        public class Config {
            public GameObject foodPrefab;
        }

        public delegate void FoodSpawnedDelegate(GameObject food);
        public FoodSpawnedDelegate OnFoodSpawned;
        
        private MeshWalker walker;

        // Dependencies
        private GameObject foodPrefab;
        
        public FoodSpawner(Config config, LevelSurface levelSurface) {
            foodPrefab = config.foodPrefab;

            walker = levelSurface.CreateWalker();
        }

        public void Initialize() {
            // Postpone this call so that OnFoodSpawned listeners
            // can register themselves in dependency injection phase
            SpawnNewFood();
        }

        public void SpawnNewFood() {
            GameObject food = UnityEngine.Object.Instantiate(foodPrefab);
            walker.RespawnRandomly();
            walker.WriteToTransform(food.transform);

            OnFoodSpawned?.Invoke(food);
        }
    }

} // namespace Serpent
