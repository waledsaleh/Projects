using UnityEngine;
using System.Collections;

namespace Serpent {

    public class CameraFollow : MonoBehaviour {

        public Transform objectToFollow;

        private Vector3 offset;

        void Start() {
            offset = transform.position - objectToFollow.position;
        }

        void Update() {
            transform.position = objectToFollow.position + offset;
        }
    }

} // namespace Serpent
