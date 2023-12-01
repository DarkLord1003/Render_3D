using Render_3D.Core.Mathf;
using System;

namespace Render_3D.Components
{
    public class Transform : Component
    {
        private Vector3 _position;
        private Vector3 _rotation;
        private Vector3 _scale;

        public Vector3 Position
        {
            get { return _position; }
            set
            {
                if(value == null)
                    throw new ArgumentNullException("value");

                _position = value;
            }
        }

        public Vector3 Rotation
        {
            get { return _rotation; }
            set
            {
                if(value == null)
                    throw new ArgumentNullException("value");

                _rotation = value;
            }
        }

        public Vector3 Scale
        {
            get { return _scale; }
            set
            {
                if(value == null)
                    throw new ArgumentNullException("value");

                _scale = value;
            }
        }

        public Transform() : this(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(1f, 1f, 1f)) { }

        public Transform(Vector3 position, Vector3 rotation, Vector3 scale)
        {
            Position = position;
            Rotation = rotation;
            Scale = scale;
        }

    }
}
