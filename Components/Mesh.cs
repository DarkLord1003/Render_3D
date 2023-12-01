using Render_3D.Core.Render;
using System;
using System.Collections.Generic;

namespace Render_3D.Components
{
    public class Mesh : Component
    {
        public List<Polygon> Polygons { get; private set; }

        public Mesh() : this(new List<Polygon>()) { }

        public Mesh(List<Polygon> polygons)
        {
            if (polygons == null)
                throw new ArgumentNullException("polygons");

            Polygons = polygons;
        }
    }
}
