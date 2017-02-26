using UnityEngine;
using System.Collections;

namespace Serpent {
    
    public struct RawTriangle {
        public Vector3 v1, v2, v3;

        public RawTriangle(Vector3 v1, Vector3 v2, Vector3 v3) {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }
    }

    public struct IndexedTriangle {
        public int i1, i2, i3;

        public IndexedTriangle(int i1, int i2, int i3) {
            this.i1 = i1;
            this.i2 = i2;
            this.i3 = i3;
        }

        public int this[int index] {
            get {
                switch (index) {
                    case 0: return i1;
                    case 1: return i2;
                    case 2: return i3;
                    default: throw new System.IndexOutOfRangeException();
                }
            }

            set {
                switch (index) {
                    case 0: i1 = value; return;
                    case 1: i2 = value; return;
                    case 2: i3 = value; return;
                    default: throw new System.IndexOutOfRangeException();
                }
            }
        }

        public int Length => 3;
        public override string ToString() => $"{{{i1}, {i2}, {i3}}}";
        public IndexedTriangle Reversed => new IndexedTriangle(i3, i2, i1);
    }

    /// A proxy for handy reading/writing of triangles from/to the triangle array.
    public struct TriangleArray {
        private int[] rawTriangles;

        public TriangleArray(int[] rawArray) {
            rawTriangles = rawArray;
        }

        public static explicit operator int[] (TriangleArray triangleArray) {
            return triangleArray.rawTriangles;
        }

        public void ReverseTriangles() {
            for (int i = 0; i < Length; ++i) {
                this[i] = this[i].Reversed;
            }
        }

        public IndexedTriangle this[int index] {
            get {
                int offset = index * 3;
                return new IndexedTriangle(
                    rawTriangles[offset + 0],
                    rawTriangles[offset + 1],
                    rawTriangles[offset + 2]
                    );
            }
            set {
                int offset = index * 3;
                rawTriangles[offset + 0] = value.i1;
                rawTriangles[offset + 1] = value.i2;
                rawTriangles[offset + 2] = value.i3;
            }
        }

        // TODO
        //public IEnumerator GetEnumerator() => rawTriangles.GetEnumerator();

        public int Length => rawTriangles.Length / 3;
    }

    public struct IndexedEdge {
        public ushort start, end;

        public IndexedEdge(int start, int end) {
            this.start = (ushort)start;
            this.end = (ushort)end;
        }
    }

} // namespace Serpent
