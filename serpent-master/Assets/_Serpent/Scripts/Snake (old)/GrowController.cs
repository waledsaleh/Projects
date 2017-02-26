using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;
using Zenject;

namespace Serpent {

    /// Continuously growing path
    /// (as opposite to growing by discrete steps, like SnakeBase)
    public interface IGrowablePath {
        void Grow(ValueTransform valTrans);
        void ShrinkToLength(float targetLength);
        float ComputeLength();

        /// Called after combination of Grow() and ShrinkToLength() has been run
        void ApplyChanges();
    }

    public class GrowController : MonoBehaviour {

        [NotNull] public Transform walker;
        [NotNull] public MonoBehaviour growable_;
        public float targetLength;
        public float simulatedLag = 0; // For debug

        private IGrowablePath growable;

        [Inject]
        public void Init() {
            // Scale must be (1; 1; 1) because mesh normals depend on walker
            // transformation matrix and they need to be uniform
            Assert.AreEqual(walker.localScale, Vector3.one);

            growable = growable_ as IGrowablePath;
            Assert.IsNotNull(growable);
            
            
            if (simulatedLag > 0)
                StartCoroutine(UpdateCoroutine());
        }

        void Update() {
            if (simulatedLag == 0)
                MaintainLength();
        }

        private IEnumerator UpdateCoroutine() {
            for (;;) {
                MaintainLength();
                yield return new WaitForSeconds(simulatedLag);
            }
        }

        // Pulls the snake to the MovementController position
        private void MaintainLength() {
            growable.Grow(new ValueTransform(walker));

            float currentLength = growable.ComputeLength();
            float shrinkLength = currentLength - targetLength;
            if (shrinkLength > 0)
                growable.ShrinkToLength(targetLength);

            growable.ApplyChanges();

        }
    }

} // namespace Serpent
