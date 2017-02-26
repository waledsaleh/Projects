using UnityEngine;
using System.Collections;

namespace Serpent {

    public static class DebugUtils {

        public static void DrawGradientLine(Vector3 start, Vector3 end, Color startColor, Color endColor,
            bool depthTest = false, float duration = 0) {

            const int kSteps = 8;
            Vector3 direction = end - start;

            for (int i = 0; i < kSteps; i++) {
                float factor = (float)i / (kSteps - 1);
                Color color = Color.Lerp(startColor, endColor, factor);

                Vector3 a = start + direction * ((float)i / kSteps);
                Vector3 b = start + direction * ((float)(i + 1) / kSteps);
                Debug.DrawLine(a, b, color);
            }
        }
        
        // TODO: implement mesh.GetRawTriangle(int index)
        public static void DrawTriangle(this Mesh mesh, int index, Color color) {
            IndexedTriangle triangle = mesh.GetSaneTriangles(0)[index];
            Vector3[] vertices = mesh.vertices;

            for (int i = 0; i < 3; ++i) {
                Vector3 start = vertices[triangle[i]];
                Vector3 end = vertices[triangle[(i + 1) % 3]];
                Debug.DrawLine(start, end, color, 0, false);
            }
        }
    }

} // namespace Serpent
