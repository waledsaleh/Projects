using UnityEngine;
using System.Collections;
using RawImage = UnityEngine.UI.RawImage;

namespace Serpent {

    [RequireComponent(typeof(RawImage), typeof(RectTransform))]
    public class TiledBackground : MonoBehaviour {

        public float speed = 0.1f;

        private RawImage rawImage;
        private RectTransform rectTransform;
        private int textureSize;    // Assuming square texture
        private float offset = 0;

        // Use this for initialization
        void Start () {
            rawImage = GetComponent<RawImage>();
            rectTransform = GetComponent<RectTransform>();

            textureSize = rawImage.texture.width;
        }

        // Update is called once per frame
        void Update() {
            offset += speed * Time.deltaTime;
            if (offset >= 1)
                offset -= 1;

            Rect rect = rectTransform.rect;
            rawImage.uvRect = new Rect(
                    0,
                    offset,
                    rect.width / textureSize,
                    rect.height / textureSize
                );
        }
    }

} // namespace Serpent
