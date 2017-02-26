using UnityEngine;
using System.Collections;

namespace Serpent {

    public class ContinuousPath {

        private readonly float interval;
        private readonly IntegerPath<ValueTransform> intPath;

        public ContinuousPath(float interval) {
            this.interval = interval;
            intPath = new IntegerPath<ValueTransform>(interval);
        }

        public void Grow(ValueTransform value, bool force=false) {
            // TEST; TODO: remove

            float distance = 0;
            if (intPath.Size == 0)
                force = true;
            else
                distance = (value.position - intPath.Last.position).magnitude;

            if (force || distance >= interval)
                intPath.PushToEnd(value);




        }

        public void DebugDraw() {
            // Avoid division by zero
            float factorDenominator = Mathf.Max(1, intPath.Size - 2);

            for (int i = 0; i < intPath.Size - 1; ++i) {
                var color = Color.Lerp(Color.green, Color.red, i / factorDenominator);

                Debug.DrawLine(intPath[i].position, intPath[i + 1].position, color);
            }
        }
    }

} // namespace Serpent
