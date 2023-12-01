using Render_3D.Components;

namespace Render_3D.Entities
{
    public class GameObject : Entity
    {
        public Transform Transform { get; private set; }

        public GameObject(int id, string name) : base(id, name)
        {
            Transform = AddComponent<Transform>(new Transform());
        }
    }
}
