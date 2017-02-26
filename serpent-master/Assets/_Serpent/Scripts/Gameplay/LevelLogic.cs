using UnityEngine;
using UnityEngine.UI;

namespace Serpent {

    public class LevelLogic : MonoBehaviour {

        public int Score {
            get { return score; }
            set {
                score = value;
                scoreText.text = value.ToString();
            }
        }
        
        private Text scoreText;
        private int score;
        
        void Start() {
            scoreText = GameObject.Find("Score text").GetRequiredComponent<Text>();

            AdjustUiScale();
        }

        public void ExitGame() {
            Application.Quit();
        }


        private void AdjustUiScale() {
            CanvasScaler scaler = GameObject.Find("Play Canvas").GetRequiredComponent<CanvasScaler>();

            if (!Application.isEditor)
                scaler.scaleFactor = 1;
        }
    }

} // namespace Serpent
