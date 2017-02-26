using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Serpent {

    public class PauseManager : MonoBehaviour {

        const float kFadeAnimationLength = 0.7f;
        const float kEndBlurSize = 4;

        public GameObject pauseCanvas;
        public Animator animator;

        private Camera pauseUICamera;
        private Button pauseButton;
        private bool pauseStateNowChanging = false;

        void Start() {
            pauseUICamera = GameObject.FindGameObjectWithTag("Pause UI Camera").GetRequiredComponent<Camera>();
            pauseButton = GameObject.FindGameObjectWithTag("Pause button").GetRequiredComponent<Button>();
        }

        public void PauseGame() {
            if (pauseStateNowChanging)
                return;

            StartCoroutine(PauseCoroutine(true));
        }

        public void ResumeGame() {
            if (pauseStateNowChanging)
                return;

            StartCoroutine(PauseCoroutine(false));
        }

        private IEnumerator PauseCoroutine(bool pause) {
            pauseStateNowChanging = true;

            //Blur blurComponent = Camera.main.GetRequiredComponent<Blur>();

            if (pause) {
                pauseButton.interactable = false;
                pauseUICamera.enabled = true;
                //blurComponent.enabled = true;
                pauseCanvas.SetActive(true);
                Time.timeScale = 0;
            }

            // Play animation
            animator.SetBool("Open", pause);

            float endTime = Time.unscaledTime + kFadeAnimationLength;
            while (Time.unscaledTime <= endTime) {
                float factor = (endTime - Time.unscaledTime) / kFadeAnimationLength;
                if (pause)
                    factor = 1f - factor;
                //blurComponent.blurSize = factor * kEndBlurSize;

                yield return new WaitForEndOfFrame();
            }

            if (!pause) {
                pauseButton.interactable = true;
                pauseUICamera.enabled = false;
                //blurComponent.enabled = false;
                pauseCanvas.SetActive(false);
                Time.timeScale = 1;
            }

            pauseStateNowChanging = false;

            yield return null;
        }
    }

} // namespace Serpent
