using System.Collections.Generic;
using Render_3D.Core.Mathf;

namespace Render_3D.Core.Render
{
    public static class GenerateMesh
    {
        public static List<Polygon> Generate()
        {
            List<Polygon> result = new List<Polygon>();

            result.Add(new Polygon(new Vector3(0f, 0f, 0f), new Vector3(0f, 1f, 0f), new Vector3(1f, 1f, 0f)));
            result.Add(new Polygon(new Vector3(0f, 0f, 0f), new Vector3(1f, 1f, 0f), new Vector3(1f, 0f, 0f)));

            result.Add(new Polygon(new Vector3(1f, 0f, 0f), new Vector3(1f, 1f, 0f), new Vector3(0f, 1f, 1f)));
            result.Add(new Polygon(new Vector3(1f, 0f, 0f), new Vector3(0f, 1f, 0f), new Vector3(0f, 0f, 1f)));

            result.Add(new Polygon(new Vector3(1f, 0f, 1f), new Vector3(1f, 1f, 1f), new Vector3(0f, 1f, 1f)));
            result.Add(new Polygon(new Vector3(1f, 0f, 1f), new Vector3(0f, 1f, 1f), new Vector3(0f, 0f, 1f)));

            result.Add(new Polygon(new Vector3(0f, 0f, 1f), new Vector3(0f, 1f, 1f), new Vector3(0f, 1f, 0f)));
            result.Add(new Polygon(new Vector3(0f, 0f, 1f), new Vector3(0f, 1f, 0f), new Vector3(0f, 0f, 0f)));

            result.Add(new Polygon(new Vector3(0f, 1f, 0f), new Vector3(0f, 1f, 1f), new Vector3(1f, 1f, 1f)));
            result.Add(new Polygon(new Vector3(0f, 1f, 0f), new Vector3(1f, 1f, 1f), new Vector3(1f, 1f, 0f)));

            result.Add(new Polygon(new Vector3(1f, 0f, 1f), new Vector3(0f, 0f, 1f), new Vector3(0f, 0f, 0f)));
            result.Add(new Polygon(new Vector3(1f, 0f, 1f), new Vector3(0f, 0f, 0f), new Vector3(1f, 0f, 0f)));

            return result;
        }
    }
}
