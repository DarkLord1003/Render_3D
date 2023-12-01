using Render_3D.Components;
using Render_3D.Core.Mathf;
using Render_3D.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Render_3D.Systems
{
    public class MovementSystem : Systems.System
    {
        public override async void Update(List<GameObject> entities)
        {
            if (entities == null)
                return;

            while (Enable)
            {
                foreach (var entity in entities)
                {
                    if (!entity.Enable)
                        continue;

                    var mesh = entity.GetComponent<Mesh>();

                    if(mesh == null)
                        continue;

                    foreach(var polygon in mesh.Polygons)
                    {
                        foreach(var point in polygon.Points)
                        {
                            //var newPos = Transformation.Translate(point, new Vector3(0f, 0f, 0.01f));

                            //point.X = newPos.X;
                            //point.Y = newPos.Y;
                            //point.Z = newPos.Z;
                        }
                    }
                }

                await Task.Delay(10);
            }
        }
    }
}
