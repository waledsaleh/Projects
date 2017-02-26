using UnityEngine;
using UnityEngine.Assertions;

namespace Serpent {

    // Utility extension methods for Unity classes
    public static class UnityUtils {

        // GameObject

        public static T GetRequiredComponent<T>(this GameObject gameObject) where T : Component {
            T component = gameObject.GetComponent<T>();
            Assert.IsNotNull(component);

            return component;
        }


        // Component

        public static T GetRequiredComponent<T>(this Component component) where T : Component {
            return component.gameObject.GetRequiredComponent<T>();
        }


        // Transform

        public static void ResetTransform(this Transform transform) {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }

        public static T FindNearestParentWithComponent<T>(this Transform trans) where T : Component {
            for (; trans != null; trans = trans.parent) {
                T component = trans.GetComponent<T>();
                if (component != null)
                    return component;
            }

            return null;
        }


        // Material

        public static Vector2 GetUnscaledTextureOffset(this Material material) {
            Vector2 result = material.mainTextureOffset;
            Vector2 scale = material.mainTextureScale;
            result.x /= scale.x;
            result.y /= scale.y;
            return result;
        }

        public static void SetUnscaledTextureOffset(this Material material, Vector2 offset) {
            Vector2 result = offset;
            result.Scale(material.mainTextureScale);
            material.mainTextureOffset = result;
        }
    }

} // namespace Serpent
