using Render_3D.Core.Mathf;
using System;
using System.Collections.Generic;

namespace Render_3D.Core.Render
{
    public class Polygon
    {
        public Vector3[] Points { get; private set; }

        public Vector3 this[int index]
        {
            get
            {
                if(index < 0 || index >= Points.Length)
                    throw new ArgumentOutOfRangeException("index");

                return Points[index];
            }

            set
            {
                if (index < 0 || index >= Points.Length)
                    throw new ArgumentOutOfRangeException("index");

                if(value == null)
                    throw new ArgumentNullException("value");

                Points[index] = value;
            }
        }

        public Polygon() : this(new Vector3(), new Vector3(), new Vector3()) { }

        public Polygon(Vector3 a, Vector3 b, Vector3 c)
        {
            if (a == null || b == null || c == null)
                throw new ArgumentNullException("a or b or c");

            Points = new Vector3[3];
            Points[0] = a;
            Points[1] = b;
            Points[2] = c;
        }
    }
}
