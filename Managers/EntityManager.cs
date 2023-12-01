using Render_3D.Components;
using Render_3D.Core.Mathf;
using Render_3D.Core.Render;
using Render_3D.Entities;
using System.Collections.Generic;

namespace Render_3D.Managers
{
    public class EntityManager
    {
        public List<GameObject> GameObjects { get; private set; }

        public EntityManager()
        {
            GameObjects = new List<GameObject>();
        }

        public GameObject CreateEmptyGameObject(Vector3 position, Vector3 rotation, Vector3 scale, string name = "")
        {
            if (string.IsNullOrEmpty(name))
                name = "GameObject " + GameObjects.Count;

            GameObject gameObject = new GameObject(GameObjects.Count, name);
            gameObject.Transform.Position = position;
            gameObject.Transform.Rotation = rotation;
            gameObject.Transform.Scale = scale;
            gameObject.Enable = true;

            GameObjects.Add(gameObject);

            return gameObject;
        }

        public GameObject CreatePrimitiveGameObject(Vector3 position, Vector3 rotation, Vector3 scale, string name = "")
        {
            if (string.IsNullOrEmpty(name))
                name = "GameObject " + GameObjects.Count;

            GameObject gameObject = new GameObject(GameObjects.Count, name);
            gameObject.Transform.Position = position;
            gameObject.Transform.Rotation = rotation;
            gameObject.Transform.Scale = scale;
            gameObject.Enable = true;

            gameObject.AddComponent<Mesh>(new Mesh(GenerateMesh.Generate()));

            GameObjects.Add(gameObject);

            return gameObject;
        }
    }
}
