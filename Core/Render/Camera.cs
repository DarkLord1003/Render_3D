using Render_3D.Core.Mathf;
using System;

namespace Render_3D.Core.Render
{
    public class Camera
    {
        public float Near {  get; set; }
        public float Far { get; set; }
        public float FieldOfView {  get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public Vector3 LookDirection { get; set; }

        public Camera(float near, float far, float fieldOfView)
        {
            if (near < 0.1f)
                near = 0.1f;

            if(far < 100)
                far = 100;

            if(fieldOfView < 10)
                fieldOfView = 10;

            Near = near;
            Far = far;
            FieldOfView = fieldOfView;

            Position = new Vector3();
            Rotation = new Vector3();
        }

    }
}
