using UnityEngine;
using System.Collections;

namespace Serpent {

    public class Rotator : MonoBehaviour {

        public float degreesPerSecond = 30;

        void Update() {
            transform.Rotate(0, 0, degreesPerSecond * Time.deltaTime);
        }
    }

} // namespace Serpent
