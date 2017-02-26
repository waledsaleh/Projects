# Mesh processing framework

```
/**

*/
public class MeshWrapper {
    public Vector3[] Vertices { get; set; }
    public IndexedTriangle[] IndexedTriangles { get; set; }
    // Normals, UVs, ...

    public MeshWrapper() {}
    public MeshWrapper(Mesh rawMesh) {}

    public RawTriangle GetRawTriangle(int index) {}
    public IndexedEdge GetTriangleEdge(int triangleIndex, int edge) {}
}

public delegate void ModifyMeshDelegate(MeshWrapper mesh);
```

Modifiers:
    - ApplyTransform
    - Flatten
    - SubdivideIcosphere
    - (?) FlipNormals
