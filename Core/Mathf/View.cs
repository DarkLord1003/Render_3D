using System;
using System.Collections.Generic;

namespace Render_3D.Core.Mathf
{
    public static class View
    {
        public static Matrix GetPointAtMatrix(Vector3 position, Vector3 target, Vector3 up)
        {
            if (position == null || target == null || up == null)
                return null;

            Vector3 direction = target - position;
            direction.Normalize();

            Vector3 right = Vector3.CrossProduct(up, direction);
            right.Normalize();

            Vector3 newUp = Vector3.CrossProduct(direction, right);

            Matrix pointAt = Matrix.GetUnitMatrix(4, 4);

            pointAt[0, 0] = right.X;
            pointAt[1, 0] = right.Y;
            pointAt[2, 0] = right.Z;
            pointAt[3, 0] = 0f;

            pointAt[0, 1] = newUp.X;
            pointAt[1, 1] = newUp.Y;
            pointAt[2, 1] = newUp.Z;
            pointAt[3, 1] = 0f;

            pointAt[0, 2] = direction.X;
            pointAt[1, 2] = direction.Y;
            pointAt[2, 2] = direction.Z;
            pointAt[3, 2] = 0f;

            return pointAt;
        }

        public static Matrix GetViewMatrix(Vector3 position, Vector3 target, Vector3 up)
        {
            if (position == null || target == null || up == null)
                return null;

            Matrix pointAt = GetPointAtMatrix(position, target, up);

            return pointAt.GetInverseMatrix();
        }
    }
}
