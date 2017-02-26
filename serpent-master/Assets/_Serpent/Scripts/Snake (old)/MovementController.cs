using UnityEngine;
using Zenject;

namespace Serpent {
    
    public class MovementController : MonoBehaviour {

        [NotNull] public Joystick joystick;

        public float rotationSpeed = 240; // Degrees per second
        public float moveSpeed = 10; // Meters per second
        public float offsetFromSurface = 1;
        public GameObject gameOverText;

        private MeshWalker walker;

        // This angle is in the space of current walker triangle,
        // so it needs to be updated when triangle changes
        private float targetAngle;
        
        [Inject]
        private void Init(LevelSurface levelSurface) {
            walker = levelSurface.CreateWalker();
            //walker.RespawnAtDefaultPlace();
            walker.RespawnNearPoint(transform.position);

            walker.OnTriangleChanged += (float deltaAngle) => {
                targetAngle += deltaAngle;
            };
        }

        void OnGUI() {
            if (GUI.Button(new Rect(10, 100, 100, 20), "Respawn")){
                walker.RespawnRandomly();
                Time.timeScale = 1;
                gameOverText.SetActive(false);
            }
        }
        
        void Update() {
            // Rotate
            {
                if (joystick.isPressed) {
                    // Update target angle

                    Vector3 worldDirection = Camera.main.cameraToWorldMatrix
                        .MultiplyVector(joystick.Direction);
                    /*Debug.DrawLine(transform.position, transform.position + worldDirection * 4,
                        Color.red, 0, false);*/

                    Vector2 surfaceDirection = walker.worldToSurface.MultiplyVector(worldDirection);
                    Vector3 pos = walker.SurfaceTransform_.localPosition;
                    /*walker.DrawLocalLine(pos, pos + (Vector3)surfaceDirection.normalized * 4,
                        Color.yellow);*/

                    targetAngle = surfaceDirection.GetAngle();
                }

                float currentAngle = walker.SurfaceTransform_.angle;

                // Debug draw
                /*{
                    Vector3 pos = walker.SurfaceTransform_.localPosition;

                    Vector2 currentDirection = MathUtils.AngleToDirection(currentAngle);
                    walker.DrawLocalLine(pos, pos + (Vector3)currentDirection * 4,
                        Color.magenta);

                    Vector2 targetDirection = MathUtils.AngleToDirection(targetAngle);
                    walker.DrawLocalLine(pos, pos + (Vector3)targetDirection * 4,
                        Color.cyan);
                }*/

                float step = rotationSpeed * Time.deltaTime;
                step = ApproachToAngle(targetAngle, currentAngle, step);
                walker.Rotate(step);
            }

            // Move
            {
                float distance = moveSpeed * Time.deltaTime;
                while (distance > 0) {
                    walker.StepUntilEdge(distance, out distance);
                }
            }

            walker.WriteToTransform(transform);
            transform.position += transform.up * offsetFromSurface;
        }

        /**
         * Calculates angle delta, not bigger than needed to reach target angle.
         * <param name="absoluteStep">Step without sign</param>
         */
        private static float ApproachToAngle(float target, float source, float absoluteStep) {
            float delta = Mathf.DeltaAngle(source, target);
            float sign = Mathf.Sign(delta);
            
            return sign * Mathf.Min(Mathf.Abs(delta), absoluteStep);
        }
    }

} // namespace Serpent
