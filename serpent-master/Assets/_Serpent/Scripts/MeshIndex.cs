using UnityEngine;
using System.Collections.Generic;
using Zenject;

namespace Serpent {
    
    public class MeshIndex {
        
        private readonly Dictionary<IndexedEdge, int> edgeToTriangleMap = new Dictionary<IndexedEdge, int>();
      
        public MeshIndex(Mesh mesh) {
            GenerateIndex(mesh);
        }
        int count = 4;
        public int FindTriangleByEdge(IndexedEdge edge1)
        {
            if (edgeToTriangleMap.ContainsKey(edge1)) return edgeToTriangleMap[edge1];

            SnakeHead.gameOver = true;
            Time.timeScale = 0;

            var edge = new IndexedEdge(
                      ++count,
                       count % 3
                       );
            edgeToTriangleMap.Add(edge, 50);
            return edgeToTriangleMap[edge];
        }

        private void GenerateIndex(Mesh mesh) {
            TriangleArray triangles = mesh.GetSaneTriangles(0);

            for (int i = 0; i < triangles.Length; ++i) {
                IndexedTriangle triangle = triangles[i];

                for (int j = 0; j < 3; ++j) {
                    var edge = new IndexedEdge(
                        triangle[j],
                        triangle[(j + 1) % 3]
                        );
                    edgeToTriangleMap.Add(edge, i);
                }
            }
        }
    }

} // namespace Serpent
