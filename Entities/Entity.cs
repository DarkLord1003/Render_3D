using Render_3D.Components;
using System;
using System.Collections.Generic;

namespace Render_3D.Entities
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Enable {  get; set; }

        private Dictionary<Type, Component> _components;

        public Entity(int id, string name)
        {
            Id = id;
            Name = name;
            _components = new Dictionary<Type, Component>();
        }

        public T AddComponent<T>(Component component) where T : Component
        {
            if (component == null)
                throw new ArgumentNullException("component");

            if (!_components.ContainsKey(component.GetType()))
            {
                component.Entity = this;
                _components.Add(component.GetType(), component);
            }

            return _components[component.GetType()] as T;
        }

        public T GetComponent<T>() where T : Component
        {
            if(_components.TryGetValue(typeof(T), out var component))
                return component as T;

            return null;
        }

        public bool RemoveComponent<T>() where T : Component
        {
            if (_components.ContainsKey(typeof(T)))
            {
                _components.Remove(typeof(T));
                return true;
            }

            return false;
        }
    }
}
