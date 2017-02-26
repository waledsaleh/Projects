using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Serpent {

public class FpsDisplay : MonoBehaviour {

    private const float kFPSUpdateInterval = 0.5f;
    private Text debugText;

    void Start() {
        debugText = GameObject.FindWithTag("Debug text").GetRequiredComponent<Text>();
        StartCoroutine(UpdateFPS());
    }

    IEnumerator UpdateFPS() {
        for (; ; ) {
            int fps = Time.unscaledDeltaTime == 0 ? 0 : (int)(1f / Time.unscaledDeltaTime);
            debugText.text = $"FPS: {fps}";
            yield return new WaitForSeconds(kFPSUpdateInterval);
        }
    }

}

} // namespace Serpent
