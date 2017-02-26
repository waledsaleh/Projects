using UnityEngine;
using System.Collections;

namespace Serpent {

    /*
     * Class for CPU-side cube map projections.
     * For detailed info about calculations used here, see any modern OpenGL specification.
     */

    public static class CubemapProjections {

        public static Vector3 GetRadiusVectorFromFace(CubemapFace face, Vector2 uv) {
            Vector3 radius = new Vector3();
            uv = uv * 2 - Vector2.one;

            switch (face) {
                case CubemapFace.PositiveX:
                    radius.Set(1, -uv.y, -uv.x);
                    break;
                case CubemapFace.PositiveY:
                    radius.Set(uv.x, 1, uv.y);
                    break;
                case CubemapFace.PositiveZ:
                    radius.Set(uv.x, -uv.y, 1);
                    break;

                case CubemapFace.NegativeX:
                    radius.Set(-1, -uv.y, uv.x);
                    break;
                case CubemapFace.NegativeY:
                    radius.Set(uv.x, -1, -uv.y);
                    break;
                case CubemapFace.NegativeZ:
                    radius.Set(-uv.x, -uv.y, -1);
                    break;
            }

            return radius.normalized;
        }

        public static Vector2 GetFaceCoordsFromRadiusVector(Vector3 r, out CubemapFace face) {
            Vector2 uv = new Vector2();

            Vector3 absR = new Vector3(Mathf.Abs(r.x), Mathf.Abs(r.y), Mathf.Abs(r.z));
            float majorAxis;

            if (absR.x >= absR.y && absR.x >= absR.z) {
                majorAxis = absR.x;
                if (r.x >= 0) {
                    // +X
                    face = CubemapFace.PositiveX;
                    uv.Set(-r.z, -r.y);
                } else {
                    // -X
                    face = CubemapFace.NegativeX;
                    uv.Set(r.z, -r.y);
                }
            } else if (absR.y >= absR.x && absR.y >= absR.z) {
                majorAxis = absR.y;
                if (r.y >= 0) {
                    // +Y
                    face = CubemapFace.PositiveY;
                    uv.Set(r.x, r.z);
                } else {
                    // -Y
                    face = CubemapFace.NegativeY;
                    uv.Set(r.x, -r.z);
                }
            } else {
                majorAxis = absR.z;
                if (r.z >= 0) {
                    // +Z
                    face = CubemapFace.PositiveZ;
                    uv.Set(r.x, -r.y);
                } else {
                    // -Z
                    face = CubemapFace.NegativeZ;
                    uv.Set(-r.x, -r.y);
                }
            }

            uv = ((uv / majorAxis) + Vector2.one) * 0.5f;

            return uv;
        }

        public static Color ReadPixel(Cubemap cubemap, Vector3 radius) {
            CubemapFace face;
            Vector2 uv = GetFaceCoordsFromRadiusVector(radius, out face);
            int sizeMinusOne = cubemap.width - 1;
            int x = (int)(uv.x * sizeMinusOne);
            int y = (int)(uv.y * sizeMinusOne);
            return cubemap.GetPixel(face, x, y);
        }
    }

} // namespace Serpent
