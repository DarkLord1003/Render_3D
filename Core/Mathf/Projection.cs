using System;

namespace Render_3D.Core.Mathf
{
    public static class Projection
    {
        public static Matrix GetPerspectiveWithCVV(float near, float far, float width, float height, float fov)
        {
            fov = (float)(fov * Math.PI / 180f);
            float tan = (float)Math.Tan(fov / 2f);
            float aspect = width / height;
            float lef = -near * tan * aspect;
            float right = near * tan * aspect;
            float bottom = -near * tan;
            float top = near * tan;

            Matrix perspective = Matrix.GetUnitMatrix(4, 4);

            perspective[0, 0] = (2f * near) / right - lef;
            perspective[1, 1] = (2f * near) / top - bottom;
            perspective[0, 2] = (right + lef) / (right - lef);
            perspective[1, 2] = (top + bottom) / (top - bottom);
            perspective[2, 2] = (-far + near) / (far - near);
            perspective[2, 3] = (-2f * near * far) / (far - near);
            perspective[3, 2] = -1f;

            return perspective;
        }
    }
}
