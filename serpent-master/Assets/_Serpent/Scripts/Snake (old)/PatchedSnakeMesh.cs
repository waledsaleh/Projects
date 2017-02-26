using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Serpent {

/// Continuous snake mesh made of discrete middle part (SnakeBase) and patches
public class PatchedSnakeMesh : MonoBehaviour, IGrowablePath {

    [NotNull] public MonoBehaviour snakeMesh_;
    public float interval = 0.25f;
    public bool animateUv = true;

    public ISnakeMesh snakeMesh;
    [NotNull] public Transform tail;
    
    private ValueTransform lastPoppedRing;
    private ISnakeMesh headPatch;
    private ISnakeMesh tailPatch;
    private Material tailMaterial; // TODO: make separate
    private Vector2 baseTailOffset; // Tail UV offset without sliding animation

    [Inject]
    public void Init() {
        snakeMesh = snakeMesh_ as ISnakeMesh;
        Assert.IsNotNull(snakeMesh);

        headPatch = InitPatch("Head Patch");
        tailPatch = InitPatch("Tail Patch");
        
        tailMaterial = tail.GetChild(0).GetRequiredComponent<MeshRenderer>().material;

        // Add first ring
        // TODO: replace by more sane mechanism (incorrect ring here)
        {
            ValueTransform ring = new ValueTransform(tail);

            GrowBaseMesh(ring, true);
            lastPoppedRing = ring;

            float distanceTraveled = 0;
            headPatch.PushToEnd(ring, distanceTraveled);
            headPatch.PushToEnd(ring, distanceTraveled);
            tailPatch.PushToEnd(ring, distanceTraveled);
            tailPatch.PushToEnd(ring, distanceTraveled);
        }

        snakeMesh.Kernel.OnPopFromStart += (ring) => {
            lastPoppedRing = ring;
        };
    }
    
    public void Grow(ValueTransform ring) {
        GrowBaseMesh(ring);
        UpdateHeadPatch(ring);
        
    }
    
    public void ShrinkToLength(float targetLength) {
        // Base mesh
        {
            // How many rings to remove
            float headPatchLength = GetPatchLength(headPatch);
            int targetRings = (int)((targetLength - headPatchLength) / interval) + 1;

            // Leave at least one ring
            targetRings = Mathf.Max(targetRings, 1);

            while (snakeMesh.Count > targetRings)
                snakeMesh.PopFromStart();
        }

        // Tail position
        {
            float tailPatchLength = targetLength - GetPatchLength(headPatch) - baseLength;
            float factor = tailPatchLength / interval;

            ValueTransform tailRing = ValueTransform.lerp(snakeMesh.Kernel.Path[0], lastPoppedRing, factor);
            tailRing.SetTransform(tail);
            UpdateTailPatch(tailRing);


            // UV offset
            float distanceTraveled = baseDistanceTraveled - baseLength - tailPatchLength;
            baseTailOffset = tailMaterial.GetUnscaledTextureOffset();
            baseTailOffset.y = distanceTraveled / snakeMesh.RingLength;
            tailMaterial.SetUnscaledTextureOffset(baseTailOffset);
        }
    }
    
    public float ComputeLength() =>
            baseLength + GetPatchLength(headPatch) + GetPatchLength(tailPatch);
    
    public void ApplyChanges() {
       // Debug.Log(ComputeLength());
        if (animateUv)
            AnimateUV();
    }

    #region Private

    private float baseLength => (snakeMesh.Count - 1) * interval;
    private float baseDistanceTraveled =>
            //Mathf.Max(0, (snakeMesh.Kernel.RingsAdded - 1) * interval);
            (snakeMesh.Kernel.RingsAdded - 1) * interval;
        
    
    private ISnakeMesh InitPatch(string gameObjectName) {
        Transform patchTransform = transform.Find(gameObjectName);
        Assert.IsNotNull(patchTransform);

        ISnakeMesh patch = patchTransform.GetRequiredComponent<SnakeMesh>();
        return patch;
    }

    private float GetPatchLength(ISnakeMesh patch) {
        var path = patch.Kernel.Path;
        float result = (path[0].position - path[1].position).magnitude;
        //Assert.IsTrue(result <= interval);
        return result;
    }

    // Grows base mesh if needed in current frame.
    //
    // TODO: remove "force" argument
    private void GrowBaseMesh(ValueTransform ring, bool force = false) {
        Vector3 lastGrowPoint;
        if (force)
            lastGrowPoint = ring.position;
        else
            lastGrowPoint = snakeMesh.Kernel.Path.Last.position;

        Vector3 delta = ring.position - lastGrowPoint;
        if (delta.magnitude >= interval || force) {
            // Grow
            //lastGrowPoint += delta.normalized * interval;
            float distanceTraveled = baseDistanceTraveled + interval;
            snakeMesh.PushToEnd(ring, distanceTraveled);
        }
    }

    // TODO: remove duplicate code in UpdateHeadPatch() and UpdateTailPatch()
    private void UpdateHeadPatch(ValueTransform headRing) {
        headPatch.PopFromStart();
        headPatch.PopFromStart();

        ValueTransform baseRing = snakeMesh.Kernel.Path.Last;
        float patchLength = (headRing.position - baseRing.position).magnitude;

        headPatch.PushToEnd(baseRing, baseDistanceTraveled);
        headPatch.PushToEnd(headRing, baseDistanceTraveled + patchLength);
    }

    private void UpdateTailPatch(ValueTransform tailRing) {
        tailPatch.PopFromStart();
        tailPatch.PopFromStart();

        ValueTransform baseRing = snakeMesh.Kernel.Path[0];
        float baseDistance = baseDistanceTraveled - baseLength;
        float tailPatchLength = (tailRing.position - baseRing.position).magnitude;

        tailPatch.PushToEnd(tailRing, baseDistance - tailPatchLength);
        tailPatch.PushToEnd(baseRing, baseDistance);
    }

    private void AnimateUV() {
        Vector2 offset = snakeMesh.TextureOffset;
        float distanceTraveled = baseDistanceTraveled + GetPatchLength(headPatch);
        offset.y = -distanceTraveled / snakeMesh.RingLength;
        snakeMesh.TextureOffset = offset;
        headPatch.TextureOffset = offset;
        tailPatch.TextureOffset = offset;

        // Tail
        Vector2 tailOffset = baseTailOffset;
        tailOffset.y += offset.y;
        tailMaterial.SetUnscaledTextureOffset(tailOffset);
    }

    #endregion Private
}

} // namespace Serpent