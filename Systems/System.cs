using Render_3D.Entities;
using System.Collections.Generic;

namespace Render_3D.Systems
{
    public abstract class System
    {
        public bool Enable {  get; set; }
        public virtual async void Update(List<GameObject> entities)
        {

        }
    }
}
