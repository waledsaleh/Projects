using UnityEngine;
using System.Collections;

namespace Snake3D {

    public class LevelInitializer : MonoBehaviour {

        public GameObject[] objectsToActivate;

        void Start() {
            if (objectsToActivate.Length == 0)
                Debug.LogError("Please set objectsToActivate to Cameras and UI");

            foreach (GameObject obj in objectsToActivate)
                obj.SetActive(true);
        }

        void Update() {

        }
    }

} // namespace Snake3D
