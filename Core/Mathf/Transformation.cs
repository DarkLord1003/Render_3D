using System;


namespace Render_3D.Core.Mathf
{
    public static class Transformation
    {
        public static Vector3 Translate(Vector3 point, Vector3 transformFactor)
        {
            if(point == null || transformFactor == null)
                return null;

            Matrix translate = GetTranslateMatrix(transformFactor);
            Vector3 result = point * translate;

            return result;
        }

        public static Vector3 RotateAroundXYZ(Vector3 point, Vector3 rotateFactor)
        {
            if(point == null || rotateFactor == null)
                return null;

            Matrix rotateXYZ = GetRotateAroundXYZMatrix(rotateFactor);
            Vector3 result = point * rotateXYZ;

            return result;
        }

        public static Matrix GetWorldMatrix(Vector3 translateFactor, Vector3 rotateFactor, Vector3 scaleFactor)
        {
            if(translateFactor == null || rotateFactor == null || scaleFactor == null)
                return null;

            Matrix translate = GetTranslateMatrix(translateFactor);
            Matrix rotate = GetRotateAroundXYZMatrix(rotateFactor);
            Matrix scale = GetLocalScaleMatrix(scaleFactor);

            Matrix result = translate * rotate * scale;

            return result;
        }

        public static Matrix GetRotateAroundXYZMatrix(Vector3 transformFactor)
        {
            if(transformFactor == null)
                return null;

            Matrix rotateX = GetRotateAroundXMatrix(transformFactor.X);
            Matrix rotateY = GetRotateAroundYMAtrix(transformFactor.Y);
            Matrix rotateZ = GetRotateAroundZMatrix(transformFactor.Z);

            Matrix result = rotateX * rotateY * rotateZ;

            return result;
        }

        public static Vector3 RotateAroundY(Vector3 point, float angle)
        {
            if(point == null)
                return null;

            Vector3 result = point * GetRotateAroundYMAtrix(angle);

            return result;
        }

        public static Vector3 RotateAroundX(Vector3 point, float angle)
        {
            if(point == null)
                return null;

            Vector3 result = point * GetRotateAroundXMatrix(angle);

            return result;
        } 
        
        public static Vector3 RotateAroundZ(Vector3 point, float angle)
        {
            if(point == null)
                return null;

            Vector3 result = point * GetRotateAroundZMatrix(angle);

            return result;
        }

        public static Matrix GetRotateAroundZMatrix(float angle)
        {
            angle = (float)(angle * Math.PI / 180f);

            Matrix rotate = Matrix.GetUnitMatrix(4, 4);

            rotate[0, 0] = (float)Math.Cos(angle);
            rotate[1, 0] = -(float)Math.Sin(angle);
            rotate[0, 1] = (float)Math.Sin(angle);
            rotate[1, 1] = (float)Math.Cos(angle);

            return rotate;
        }

        public static Matrix GetRotateAroundXMatrix(float angle)
        {
            angle = (float)(angle * Math.PI / 180f);

            Matrix rotate = Matrix.GetUnitMatrix(4, 4);

            rotate[1, 1] = (float)Math.Cos(angle);
            rotate[1, 2] = (float)Math.Sin(angle);
            rotate[2, 1] = -(float)Math.Sin(angle);
            rotate[2, 2] = (float)Math.Cos(angle);

            return rotate;
        }

        public static Matrix GetRotateAroundYMAtrix(float angle)
        {
            angle = (float)(angle * Math.PI / 180f);

            Matrix rotate = Matrix.GetUnitMatrix(4, 4);

            rotate[0, 0] = (float)Math.Cos(angle);
            rotate[2, 0] = (float)Math.Sin(angle);
            rotate[0, 2] = -(float)Math.Sin(angle);
            rotate[2, 2] = (float)Math.Cos(angle);

            return rotate;
        }

        public static Matrix GetTranslateMatrix(Vector3 translateFactor)
        {
            if (translateFactor == null)
                return null;

            Matrix translate = Matrix.GetUnitMatrix(4, 4);

            translate[3, 0] = translateFactor.X;
            translate[3, 1] = translateFactor.Y;
            translate[3, 2] = translateFactor.Z;

            return translate;
        }

        public static Matrix GetLocalScaleMatrix(Vector3 scaleFactor)
        {
            if(scaleFactor == null)
                return null;

            Matrix scale = Matrix.GetUnitMatrix(4, 4);

            scale[0, 0] = scaleFactor.X;
            scale[1, 1] = scaleFactor.Y;
            scale[2, 2] = scaleFactor.Z;

            return scale;
        }
    }
}
