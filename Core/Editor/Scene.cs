using Render_3D.Managers;
using Render_3D.Systems;
using System;
using System.Windows.Forms;

namespace Render_3D.Core.Editor
{
    public class Scene
    {
        public Form Window { get; set; }
        public string SceneName { get; set; }
        public int SceneID { get; private set; }
        public EntityManager EntityManager { get; private set; }
        public SystemManager SystemManager { get; private set; }

        public Scene(Form window, string sceneName, int sceneID)
        {
            if (window == null)
                throw new ArgumentNullException("window");

            if (string.IsNullOrEmpty(sceneName))
                sceneName = "SapmleScene";

            Window = window;
            SceneName = sceneName;
            SceneID = sceneID;

            EntityManager = new EntityManager();
            SystemManager = new SystemManager();

            SystemManager.AddSystem<RenderSystem>(new RenderSystem(Window));
            SystemManager.AddSystem<MovementSystem>(new MovementSystem());
            SystemManager.AddSystem<RotateSystem>(new RotateSystem());
        }

        public void Start()
        {
            SystemManager.ActivateAllSystems(EntityManager.GameObjects);
        }
    }
}
