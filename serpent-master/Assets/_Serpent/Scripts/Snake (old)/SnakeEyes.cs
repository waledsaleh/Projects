using UnityEngine;
using System.Collections;

namespace Serpent {

    public class SnakeEyes : MonoBehaviour {

        [NotNull] public Transform leftPupil;
        [NotNull] public Transform rightPupil;

        private Vector3 targetPosition, previousPosition;
        float lastTime;

        void Start() {
            StartCoroutine(UpdateLookTarget());
        }

        void Update() {
            const float interval = 0.5f;
            float factor = Mathf.SmoothStep(0, 1, (Time.time - lastTime) / interval);
            Vector3 newPosition = Vector3.Lerp(previousPosition, targetPosition, factor);

            leftPupil.localPosition = rightPupil.localPosition = newPosition;
        }

        private IEnumerator UpdateLookTarget() {
            for (;;) {
                lastTime = Time.time;
                previousPosition = leftPupil.localPosition;
                targetPosition = new Vector3(
                    0.17f,
                    Random.Range(-0.17f, 0.3f),
                    Random.Range(-0.4f, 0.4f)
                    );

                float delay = Random.Range(0.2f, 3);
                yield return new WaitForSeconds(delay);
            }
        }
    }

} // namespace Serpent
