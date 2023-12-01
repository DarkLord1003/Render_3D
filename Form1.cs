using Render_3D.Core.Editor;
using Render_3D.Core.Mathf;
using Render_3D.Core.Render;
using Render_3D.Systems;
using System.Windows.Forms;

namespace Render_3D
{
    public partial class Form1 : Form
    {
        Camera camera;
        public Form1()
        {
            InitializeComponent();
            Scene scene = new Scene(this, "ssss", 1);
            scene.EntityManager.CreatePrimitiveGameObject(new Vector3(), new Vector3(), new Vector3());

            scene.Start();
            camera = scene.SystemManager.GetSystem<RenderSystem>().Camera;

        }
    }
}
