using UnityEngine;
using System.Collections;

namespace Serpent {

    public class OrbitalCamera : MonoBehaviour {

        // Speed in degrees
        public float speed = 60;
        public Joystick joystick;

        Vector3 eulerRotation = new Vector3();

        void Start() {

        }

        void Update() {
            Vector3 rotationDelta = new Vector3();
            rotationDelta.y = -joystick.Value.x;
            rotationDelta.x = joystick.Value.y;
            rotationDelta *= speed * Time.deltaTime;

            eulerRotation += rotationDelta;
            eulerRotation.x = Mathf.Clamp(eulerRotation.x, -90, 90);

            transform.rotation = Quaternion.Euler(eulerRotation);
        }
    }

} // namespace Serpent
