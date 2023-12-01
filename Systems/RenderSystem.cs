using Render_3D.Components;
using Render_3D.Core.Mathf;
using Render_3D.Core.Render;
using Render_3D.Entities;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using View = Render_3D.Core.Mathf.View;

namespace Render_3D.Systems
{
    public class RenderSystem : System
    {
        private Graphics _canvas;
        private Matrix _projection;

        public Form Window { get; set; }
        public Camera Camera { get; private set; }

        public RenderSystem(Form window)
        {
            if (window == null)
                throw new ArgumentNullException("window");

            Window = window;
            Window.Resize += Resize;
            _canvas = Window.CreateGraphics();
            Camera = new Camera(0.1f, 1000f, 90f);
            _projection = Projection.GetPerspectiveWithCVV(Camera.Near, Camera.Far, Window.ClientSize.Width,
                                                           Window.ClientSize.Height, Camera.FieldOfView);
        }

        private void Resize(object sender, EventArgs e)
        {
            _canvas = Window.CreateGraphics();
            _projection = Projection.GetPerspectiveWithCVV(Camera.Near, Camera.Far, Window.ClientSize.Width,
                                                           Window.ClientSize.Height, Camera.FieldOfView);
        }

        public override async void Update(List<GameObject> entities)
        {
            while(Enable)
            {
                if (Camera == null)
                    return;

                _canvas.Clear(Color.White);

                Vector3 up = new Vector3(0f, 1f, 0f);
                Vector3 target = new Vector3(0f, 0f, 1f);
                Matrix rotY = Transformation.GetRotateAroundYMAtrix(Camera.Rotation.Y);
                Camera.LookDirection = target * rotY;
                target = Camera.LookDirection + Camera.Position;

                Matrix camera = View.GetPointAtMatrix(Camera.Position, target, up);

                Matrix view = camera.GetInverseMatrix();

                foreach(GameObject entity in entities)
                {
                    if (!entity.Enable)
                        continue;

                    var mesh = entity.GetComponent<Mesh>();

                    if(mesh == null)
                        continue;

                    Polygon screen = new Polygon();
                    Polygon projected = new Polygon();
                    Polygon transformed = new Polygon();
                    Polygon viewed = new Polygon();

                    foreach(Polygon polygon in mesh.Polygons)
                    {
                        transformed[0] = Transformation.Translate(polygon[0], new Vector3(1f, 1f, -5f));
                        transformed[1] = Transformation.Translate(polygon[1], new Vector3(1f, 1f, -5f));
                        transformed[2] = Transformation.Translate(polygon[2], new Vector3(1f, 1f, -5f));

                        viewed[0] = transformed[0] * view;
                        viewed[1] = transformed[1] * view;
                        viewed[2] = transformed[2] * view;

                        projected[0] = viewed[0] * _projection;
                        projected[1] = viewed[1] * _projection;
                        projected[2] = viewed[2] * _projection;

                        screen[0].X = projected[0].X * 0.2f * Window.ClientSize.Width;
                        screen[0].Y = projected[0].Y * 0.2f * Window.ClientSize.Height;
                        screen[1].X = projected[1].X * 0.2f * Window.ClientSize.Width;
                        screen[1].Y = projected[1].Y * 0.2f * Window.ClientSize.Height;
                        screen[2].X = projected[2].X * 0.2f * Window.ClientSize.Width;
                        screen[2].Y = projected[2].Y * 0.2f * Window.ClientSize.Height;

                        _canvas.DrawPolygon(new Pen(Color.Blue), new PointF[] {new PointF(screen[0].X, screen[0].Y),
                                                                               new PointF(screen[1].X, screen[1].Y),
                                                                               new PointF(screen[2].X, screen[2].Y)});
                    }
                   
                }

                await Task.Delay(10);
            }
        }
    }
}
