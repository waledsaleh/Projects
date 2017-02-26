using UnityEngine;
using System.Collections;

namespace Serpent {

    public enum SnakeSpace {
        FromHead,
        FromTail,
        FromStart
    }

    public class IntegerPath<T> : IEnumerable {
        public readonly float interval;

        public int Size => buffer.Count;
        public float Length => Mathf.Max(0, (Size - 1) * interval);
        public int stepsPassed { get; private set; }
        public float Mileage => stepsPassed * interval;

        public T Last => buffer.Last;

        // TODO: make buffer "infinite"
        private readonly CircularBuffer<T> buffer = new CircularBuffer<T>(512);

        public IntegerPath(float interval) {
            this.interval = interval;
        }

        public void PushToEnd(T value) {
            buffer.Enqueue(value);
        }

        public void PushToEnd(T[] values) {
            buffer.Enqueue(values);
        }

        public void PopFromStart() {
            buffer.Dequeue();
            stepsPassed++;
        }

        public T GetValueAt(int index, SnakeSpace space = SnakeSpace.FromTail) {
            switch (space) {
                case SnakeSpace.FromTail:
                    return buffer[index];
                case SnakeSpace.FromHead:
                    return buffer[Size - 1 - index];
                case SnakeSpace.FromStart:
                    return buffer[index - stepsPassed];
            }
            return default(T);
        }

        public T this[int index] => GetValueAt(index);

        public IEnumerator GetEnumerator() => buffer.GetEnumerator();
    }

} // namespace Serpent
