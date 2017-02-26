using UnityEngine;
using Zenject;

namespace Serpent {

   
    [RequireComponent(typeof(AudioSource))]
    public class SnakeHead : MonoBehaviour {

        [NotNull] public GrowController growController;
        public float growDelta = 4;
        private LevelLogic levelLogic;
        private FoodSpawner foodSpawner;
        private AudioSource audioSource;
        public GameObject gameOverText;
        public static bool gameOver = false;
        [Inject]
        void Init(LevelLogic levelLogic, FoodSpawner foodSpawner) {
            this.levelLogic = levelLogic;
            this.foodSpawner = foodSpawner;
            foodSpawner.SpawnNewFood();
            growController.targetLength += growDelta;

            audioSource = GetComponent<AudioSource>();
        }
      
        void OnTriggerEnter(Collider other) {

            Debug.Log(other.name);
            if (!other.CompareTag("Food")) {
                //  game over
              
               Debug.Log("collision tree");
               if (gameOver){
                   gameOverText.SetActive(true);
                   Time.timeScale = 0;
               }
             
               
                return;
            }
            Debug.Log("collision food");

            OnFoodPickedUp(other.gameObject);
        }

        private void OnFoodPickedUp(GameObject food) {
            Destroy(food);
            audioSource.Play();

            foodSpawner.SpawnNewFood();
            levelLogic.Score++;
            // Grow snake
            growController.targetLength += growDelta;
        }
        public static bool getGameOverCheck(bool set){

            return gameOver = set;    
        }
    }

} // namespace Serpent
