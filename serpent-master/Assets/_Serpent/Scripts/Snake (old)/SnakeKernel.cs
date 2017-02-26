using UnityEngine;
using Zenject;

namespace Serpent {

    public delegate void KernelChangeDelegate(ValueTransform ring);

    public interface ISnakeKernel {
        void PushToEnd(ValueTransform ring);
        void PopFromStart();

        ICircularBuffer<ValueTransform> Path { get; }
        KernelChangeDelegate OnPopFromStart { get; set; }
        int RingsAdded { get; }
    }

    public class SnakeKernel : MonoBehaviour, ISnakeKernel {

        public int pointsNum = 64;
        public bool showDebugInfo = false;

        public ICircularBuffer<ValueTransform> Path { get; private set; }
        public int RingsAdded { get; private set; }

        public KernelChangeDelegate OnPopFromStart { get; set; }

#if UNITY_EDITOR
        void Update() {
            DebugDraw();
        }
#endif

        [Inject]
        public void Init() {
            Path = new CircularBuffer<ValueTransform>(pointsNum);
        }

        public void PushToEnd(ValueTransform dest) {
            Path.Enqueue(dest);
            RingsAdded++;
        }

        public void PopFromStart() {
            ValueTransform popped = Path.Dequeue();
            OnPopFromStart?.Invoke(popped);
        }

#if UNITY_EDITOR
        private void DebugDraw() {
            if (!showDebugInfo)
                return;

            int count = Path.Count;
            int capacity = Path.Capacity;

            for (int i = 0; i < count - 1; ++i) {
                float factor;
                {
                    // In circular buffer space
                    /*if (count - 2 == 0)
                        factor = 0;
                    else
                        factor = (float)i / (count - 2);*/

                    // In raw buffer space
                    factor = (float)Path.RawPosition(i) / (capacity - 1);
                }

                var color = Color.Lerp(Color.green, Color.red, factor);
                Debug.DrawLine(Path[i].position, Path[i + 1].position, color);
            }
        }
#endif // UNITY_EDITOR
    }

} // namespace Serpent
