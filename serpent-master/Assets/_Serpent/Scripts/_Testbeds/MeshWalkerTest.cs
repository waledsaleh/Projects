#if UNITY_EDITOR

using UnityEngine;
using Zenject;

namespace Serpent {
    
    public class MeshWalkerTest : MonoBehaviour {

        [NotNull] public Transform intersectionMarker;
        [NotNull] public Transform startMarker;

        public float maxDistance = 64;

        private MeshWalker walker;
        private float angle, distance = 1;
        private Vector2 coords;
        private int steps;

        [Inject]
        private void Init(LevelSurface levelSurface) {
            walker = levelSurface.CreateWalker();

            walker.debugDrawEnabled = true;
            walker.RespawnNearPoint(startMarker.position + transform.position);
        }
        
        void OnGUI() {
            GUI.Box(new Rect(10, 10, 220, 220), "MeshWalker test");
            GUI.Label(new Rect(20, 40, 100, 20), "Angle");
            angle = GUI.HorizontalSlider(new Rect(120, 40, 100, 20), angle, 0, 360);
            GUI.Label(new Rect(20, 60, 100, 20), "X");
            coords.x = GUI.HorizontalSlider(new Rect(120, 60, 100, 20), coords.x, 0, 10);
            GUI.Label(new Rect(20, 80, 100, 20), "Y");
            coords.y = GUI.HorizontalSlider(new Rect(120, 80, 100, 20), coords.y, 0, 10);
            GUI.Label(new Rect(20, 100, 100, 20), "Distance");
            distance = GUI.HorizontalSlider(new Rect(120, 100, 100, 20), distance, 0, maxDistance);
            
            GUI.Label(new Rect(20, 120, 200, 20), $"Steps: {steps}");
        }

        void Update() {
            walker.RespawnAtTriangle(701, angle, coords);
            walker.WriteToTransform(startMarker);

            float distanceLeft = distance;
            const int kMaxSteps = 16;
            int i;
            for (i = 0; i < kMaxSteps && distanceLeft > 0; i++) {
                walker.StepUntilEdge(distanceLeft, out distanceLeft);
                walker.WriteToTransform(intersectionMarker);
            }
            steps = i;

            walker.DebugDrawAxes();
        }
    }

} // namespace Serpent

#endif // UNITY_EDITOR
