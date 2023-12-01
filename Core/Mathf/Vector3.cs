using System;

namespace Render_3D.Core.Mathf
{
    public class Vector3
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float W { get; set; }

        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
            }
        }

        public static Vector3 Zero
        {
            get
            {
                return new Vector3();
            }
        }

        public Vector3() : this(0f, 0f, 0f) { }

        public Vector3(float x, float y, float z, float w = 1)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            if (v1 == null || v2 == null)
                return null;

            Vector3 result = new Vector3();

            result.X = v1.X + v2.X;
            result.Y = v1.Y + v2.Y;
            result.Z = v1.Z + v2.Z;

            return result;
        }   
        
        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            if (v1 == null || v2 == null)
                return null;

            Vector3 result = new Vector3();

            result.X = v1.X - v2.X;
            result.Y = v1.Y - v2.Y;
            result.Z = v1.Z - v2.Z;

            return result;
        }

        public static Vector3 operator *(Vector3 v, float scalar)
        {
            if(v == null) 
                return null;

            Vector3 result = new Vector3();
            result.X = v.X * scalar;
            result.Y = v.Y * scalar;
            result.Z = v.Z * scalar;

            return result;
        }

        public static float? operator *(Vector3 v1, Vector3 v2)
        {
            if(v1 == null || v2 == null)
                return null;

            float? result = v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;

            return result;
        }

        public static Vector3 operator *(Vector3 v, Matrix m)
        {
            if(v == null || m == null)
                return null;

            Matrix m2 = v.ToRowMatrix();

            Matrix result = m2 * m;
            Vector3 resultVector = new Vector3(result[0, 0], result[0, 1], result[0, 2], result[0, 3]);

            if(resultVector.W != 0)
            {
                resultVector.X /= resultVector.W;
                resultVector.Y /= resultVector.W;
                resultVector.Z /= resultVector.W;
                resultVector.W /= resultVector.W;
            }

            return resultVector;
        }

        public static float? Angle(Vector3 v1, Vector3 v2)
        {
            if(v1 == null || v2 == null)
                return null;

            float mag1 = v1.Magnitude;
            float mag2 = v2.Magnitude;
            float prod = (float)(v1 * v2);
            float result = prod / (mag1 * mag2);
            result = (float)Math.Acos(result);
            result = (float)(result * 180 / Math.PI);

            return result;
        }

        public static Vector3 CrossProduct(Vector3 v1, Vector3 v2)
        {
            if( v1 == null || v2 == null)
                return null;

            Vector3 result = new Vector3();

            result.X = v1.Y * v2.Z - v1.Z * v2.Y;
            result.Y = v1.Z * v2.X - v1.X * v2.Z;
            result.Z = v1.X * v2.Y - v1.Y * v2.X;

            return result;
        }

        public void Normalize()
        {
            X /= Magnitude;
            Y /= Magnitude;
            Z /= Magnitude;
        }

        public Vector3 Normalized()
        {
            Vector3 result = new Vector3();

            result.X = X / Magnitude;
            result.Y = Y / Magnitude;
            result.Z = Z / Magnitude;

            return result;
        }

        public Matrix ToRowMatrix()
        {
            Matrix result = new Matrix(1, 4);

            result[0, 0] = X;
            result[0, 1] = Y;
            result[0, 2] = Z;
            result[0, 3] = W;

            return result;
        }

        public override string ToString()
        {
            return $"[ X: {X}, Y: {Y}, Z: {Z}, W: {W} ]";
        }
    }
}
