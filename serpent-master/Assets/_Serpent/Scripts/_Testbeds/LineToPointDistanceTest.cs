#if UNITY_EDITOR

using UnityEngine;
using System.Collections;

namespace Serpent {

    public class LineToPointDistanceTest : MonoBehaviour {
        
        [NotNull] public Transform lineStartMarker;
        [NotNull] public Transform lineEndMarker;
        [NotNull] public Transform pointMarker;
        [NotNull] public Transform intersectionMarker;

        private float distance = 0;

        void Update() {
            Vector2 lineStart = lineStartMarker.position;
            Vector2 lineEnd = lineEndMarker.position;
            Vector2 point = pointMarker.position;
            Debug.DrawLine(lineStart, lineEnd, Color.blue);
            
            Vector2 lineDir = lineEnd - lineStart;
            Vector2 lineNormal = new Vector2(lineDir.y, -lineDir.x);
            Vector2 intersection = MathUtils.GetLinesIntersection(lineStart, lineEnd, point, point + lineNormal);

            intersectionMarker.position = intersection;
            Debug.DrawLine(intersection, point, Color.red);

            distance = (intersection - point).magnitude;
        }

        void OnGUI() {
            GUI.Box(new Rect(10, 10, 220, 220), "LineToPointDistance test");
            GUI.Label(new Rect(20, 40, 200, 20), $"Distance: {distance:N2}");
        }
    }

} // namespace Serpent

#endif // UNITY_EDITOR
