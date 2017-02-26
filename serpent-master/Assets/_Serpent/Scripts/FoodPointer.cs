using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using Zenject;

namespace Serpent {

    [RequireComponent(typeof(RectTransform), typeof(Image))]
    public class FoodPointer : MonoBehaviour {

        public float margin = 48;

        private RectTransform rectTransform;
        private RectTransform parentRectTransform;
        private Behaviour image;

        private Transform food;

        void Start() {
            rectTransform = GetComponent<RectTransform>();

            parentRectTransform = transform.parent.GetRequiredComponent<RectTransform>();

            image = GetComponent<Image>();
            image.enabled = true;
        }

        [Inject]
        private void Init(FoodSpawner spawner) {
            spawner.OnFoodSpawned += (GameObject food) => {
                this.food = food.transform;
            };
        }

        void Update() {
            if (food == null)
                return;

            // Get food position in screen space
            Camera camera = Camera.main;
            Assert.IsNotNull(camera);
            Vector2 position = camera.WorldToScreenPoint(food.position);

            // Should food pointer be visible now?
            bool facingAwayFromCamera = Vector3.Angle(camera.transform.forward, food.up) < 80;
            image.enabled = !camera.pixelRect.Contains(position) || facingAwayFromCamera;


            // Align to screen border
            position -= 0.5f * camera.pixelRect.size;
            Rect parentRect = parentRectTransform.rect;
            position.x = Mathf.Clamp(position.x, parentRect.xMin + margin, parentRect.xMax - margin);
            position.y = Mathf.Clamp(position.y, parentRect.yMin + margin, parentRect.yMax - margin);
            rectTransform.anchoredPosition = position;

            // Rotate
            float angle = Vector2.Angle(Vector2.right, position);
            if (position.y < 0)
                angle = -angle;
            transform.localEulerAngles = new Vector3(0, 0, angle);
        }
    }

} // namespace Serpent
