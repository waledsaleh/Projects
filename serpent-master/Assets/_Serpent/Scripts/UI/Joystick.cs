using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Zenject;

namespace Serpent {

    [RequireComponent(typeof(Image))]
    public class Joystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {

        // Value's magnitude is <= 1 and == (0, 0) when joystick is not pressed
        public Vector2 Value { get; private set; }

        // These two properties hold their value after joystick release
        public float Angle { get; private set; } // In degrees
        // Notice: when isPressed == false, Direction != Value.normalized
        public Vector3 Direction => MathUtils.AngleToDirection(Angle);

        public bool isPressed { get; private set; }
        public float maxStickDistance = 58;

        public delegate void Delegate();
        public Delegate OnChange;
        public Delegate OnDown;
        public Delegate OnUp;

        private Image joystickBackground;
        private Image joystickCenter;
        private Camera myCamera;

        [Inject]
        public void Init() {
            joystickBackground = GetComponent<Image>();
            joystickCenter = transform.Find("Joystick Center").GetRequiredComponent<Image>();

            // What camera to use?
            Canvas canvas = transform.FindNearestParentWithComponent<Canvas>();
            if (canvas.renderMode == RenderMode.WorldSpace || canvas.renderMode == RenderMode.ScreenSpaceCamera)
                myCamera = canvas.worldCamera;
            else
                myCamera = null;
        }

        public void OnPointerDown(PointerEventData eventData) {
            // Check whether click is out of joystick area
            Vector2 stickPosition = new Vector2();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                joystickBackground.rectTransform,
                eventData.position,
                myCamera,
                out stickPosition
            );
            if (stickPosition.magnitude > joystickBackground.rectTransform.rect.width / 2)
                // Ignore event
                return;

            UpdateValues(eventData.position);

            isPressed = true;
            OnDown?.Invoke();
            OnChange?.Invoke();
        }

        public void OnDrag(PointerEventData eventData) {
            UpdateValues(eventData.position);

            OnChange?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData) {
            Value = Vector2.zero;
            joystickCenter.rectTransform.anchoredPosition = Value;

            isPressed = false;
            OnUp?.Invoke();
        }


        private void UpdateValues(Vector2 pointerCoords) {
            Vector2 stickPosition = new Vector2();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                joystickBackground.rectTransform,
                pointerCoords,
                myCamera,
                out stickPosition
            );

            Vector2 direction = stickPosition.normalized;
            float magnitude = stickPosition.magnitude;

            if (magnitude > maxStickDistance)
                magnitude = maxStickDistance;

            joystickCenter.rectTransform.anchoredPosition = direction * magnitude;
            Value = direction * magnitude / maxStickDistance;

            Angle = Value.GetAngle();
        }
    }

} // namespace Serpent
