using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Serpent {

    public class MainMenu : MonoBehaviour {

        [NotNull]
        public Button playButton;

        void Start() {
            playButton.onClick.AddListener(() => {
                SceneManager.LoadScene("Terrain", LoadSceneMode.Single);
            });
        }
    }

} // namespace Serpent
