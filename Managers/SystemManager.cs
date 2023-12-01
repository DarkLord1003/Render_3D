using Render_3D.Entities;
using System;
using System.Collections.Generic;

namespace Render_3D.Managers
{
    public class SystemManager
    {
        private Dictionary<Type, Systems.System> _systems;

        public SystemManager()
        {
            _systems = new Dictionary<Type, Systems.System>();
        }

        public T AddSystem<T>(Systems.System system) where T : Systems.System
        {
            if (system == null) 
                throw new ArgumentNullException("system");

            if (!_systems.ContainsKey(system.GetType()))
            {
                _systems.Add(system.GetType(), system);
                return system as T;
            }

            return _systems[system.GetType()] as T;
        }

        public T GetSystem<T>() where T : Systems.System
        {
            if(_systems.TryGetValue(typeof(T), out var system))
            {
                return system as T;
            }

            return null;
        }

        public bool RemoveSystem<T>() where T : Systems.System
        {
            if (_systems.ContainsKey(typeof(T)))
            {
                _systems.Remove(typeof(T));
                return true;
            }

            return false;
        }

        public bool ActivateSyste<T>(List<GameObject> entities) where T : Systems.System
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            if(_systems.TryGetValue(typeof(T), out var system))
            {
                system.Enable = true;
                system.Update(entities);
                return true;
            }

            return false;
        }

        public bool DeactivateSystem<T>() where T : Systems.System
        {
            if(_systems.TryGetValue(_systems.GetType(), out var system))
            {
                system.Enable = false;
                return true;
            }

            return false;
        }

        public void ActivateAllSystems(List<GameObject> entities)
        {
            foreach(var system in _systems.Values)
            {
                system.Enable = true;
                system.Update(entities);
            }
        }
    }
}
