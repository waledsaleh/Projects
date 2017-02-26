/* Source: http://geekswithblogs.net/blackrob/archive/2014/09/01/circular-buffer-in-c.aspx */

using System;
using System.Collections;
using System.Collections.Generic;

namespace Serpent {
    public interface ICircularBuffer<T> {
        int Count { get; }
        int Capacity { get; set; }
        T Enqueue(T item);
        T Dequeue();
        void Dequeue(int count);
        void Clear();
        T this[int index] { get; set; }
        int IndexOf(T item);
        void Insert(int index, T item);
        void RemoveAt(int index);

        void Enqueue(T[] items);
        int RawPosition(int index);
        T[] RawBuffer { get; }
        int Head { get; }
        int Tail { get; }
        T Last { get; }
    }

    public class BufferOverflowException : Exception {
        public override string Message
            => "Attempt to push to full circular buffer";
    }

    public class CircularBuffer<T> : ICircularBuffer<T>, IEnumerable<T> {

        public int Count { get; private set; }
        public T[] RawBuffer { get; private set; }
        public int Head { get; private set; }
        public int Tail { get; private set; }

        public CircularBuffer(int capacity) {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException("capacity", "must be positive");
            RawBuffer = new T[capacity];
            Head = capacity - 1;
        }

        public int Capacity {
            get { return RawBuffer.Length; }
            set {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", "must be positive");

                if (value == RawBuffer.Length)
                    return;

                var buffer = new T[value];
                var count = 0;
                while (Count > 0 && count < value)
                    buffer[count++] = Dequeue();

                RawBuffer = buffer;
                Count = count;
                Head = count - 1;
                Tail = 0;
            }
        }

        public T Last {
            get {
                if (Count == 0)
                    throw new InvalidOperationException();

                return this[Count - 1];
            }
        }

        public T Enqueue(T item) {
            if (Count == Capacity)
                throw new BufferOverflowException();

            ++Count;
            Head = (Head + 1) % Capacity;
            var overwritten = RawBuffer[Head];
            RawBuffer[Head] = item;
            return overwritten;
        }

        public T Dequeue() {
            if (Count == 0)
                throw new InvalidOperationException("queue exhausted");

            var dequeued = RawBuffer[Tail];
            RawBuffer[Tail] = default(T);
            Tail = (Tail + 1) % Capacity;
            --Count;
            return dequeued;
        }

        public void Clear() {
            Head = Capacity - 1;
            Tail = 0;
            Count = 0;
        }

        public T this[int index] {
            get {
                EnsureIndexIsCorrect(index);
                return RawBuffer[RawPosition(index)];
            }
            set {
                EnsureIndexIsCorrect(index);
                RawBuffer[RawPosition(index)] = value;
            }
        }

        public int IndexOf(T item) {
            for (var i = 0; i < Count; ++i)
                if (Equals(item, this[i]))
                    return i;
            return -1;
        }

        public void Insert(int index, T item) {
            EnsureIndexIsCorrect(index);

            if (Count == index)
                Enqueue(item);
            else {
                var last = this[Count - 1];
                for (var i = index; i < Count - 2; ++i)
                    this[i + 1] = this[i];
                this[index] = item;
                Enqueue(last);
            }
        }

        public void RemoveAt(int index) {
            EnsureIndexIsCorrect(index);

            for (var i = index; i > 0; --i)
                this[i] = this[i - 1];
            Dequeue();
        }

        public IEnumerator<T> GetEnumerator() {
            if (Count == 0 || Capacity == 0)
                yield break;

            for (var i = 0; i < Count; ++i)
                yield return this[i];
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public void Dequeue(int removeCount) {
            if (Count < removeCount)
                throw new InvalidOperationException("queue exhausted");

            Tail = (Tail + removeCount) % Capacity;
            Count -= removeCount;
        }

        public void Enqueue(T[] items) {
            if (items == null)
                throw new ArgumentNullException();

            if (Count + items.Length > Capacity)
                throw new BufferOverflowException();

            Count += items.Length;

            for (int i = 0; i < items.Length; ++i) {
                Head = (Head + 1) % Capacity;
                RawBuffer[Head] = items[i];
            }
        }

        public int RawPosition(int index)
            => (Tail + index) % Capacity;

        private void EnsureIndexIsCorrect(int index) {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();
        }
    }
} // namespace Serpent
