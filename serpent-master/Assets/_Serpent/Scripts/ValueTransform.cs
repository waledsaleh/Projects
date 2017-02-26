using UnityEngine;

namespace Serpent {

    /// Value type analog of Transform, without scale
    public struct ValueTransform {
        public Vector3 position;
        public Quaternion rotation;

        public ValueTransform(Vector3 position, Quaternion rotation) {
            this.position = position;
            this.rotation = rotation;
        }

        public ValueTransform(Transform transform) {
            position = transform.position;
            rotation = transform.rotation;
        }

        public static ValueTransform lerp(ValueTransform start, ValueTransform end, float factor) {
            return new ValueTransform(
                    Vector3.LerpUnclamped(start.position, end.position, factor),
                    Quaternion.LerpUnclamped(start.rotation, end.rotation, factor)
                );
        }

        public void SetTransform(Transform transform) {
            transform.position = position;
            transform.rotation = rotation;
        }
    }

} // namespace Serpent
