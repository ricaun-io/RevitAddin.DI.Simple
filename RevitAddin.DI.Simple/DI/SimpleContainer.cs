using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RevitAddin.DI.Simple
{
    public class SimpleContainer : IContainer
    {
        #region Constructors

        static SimpleContainer()
        {
            Container = new SimpleContainer();
        }

        private SimpleContainer()
        {
            this.Singleton<IContainer>(this);
        }

        #endregion

        #region Properties

        public static IContainer Container { get; }

        private static ConcurrentDictionary<Type, IEnumerable<PropertyInfo>> InjectableProperties { get; } =
            new ConcurrentDictionary<Type, IEnumerable<PropertyInfo>>();

        private Dictionary<Type, Func<object>> Registrations { get; } = new Dictionary<Type, Func<object>>();

        #endregion

        #region Interface Implementations

        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }

        /// <summary>
        ///     Inject the properties attributed with InjectAttribute
        /// </summary>
        /// <param name="instance">The instance</param>
        public void InjectProperties(object instance)
        {
            if (null == instance) return;
            GetInjectableProperties(instance)
                .ToList()
                .ForEach(property => { property.SetValue(instance, GetService(property.PropertyType), null); });
        }

        public void Register<TService>()
        {
            Register<TService, TService>();
        }

        public void Register<TService, TImpl>() where TImpl : TService
        {
            InternalRegister<TService>(() =>
            {
                var implType = typeof(TImpl);
                return typeof(TService) == implType
                            ? this.CreateInstance(implType)
                            : GetService(implType);
            });
        }

        public void Register<TService>(Func<TService> instanceCreator)
        {
            InternalRegister<TService>(() => instanceCreator());
        }

        public void Dispose()
        {
            Registrations.Clear();
        }

        public object GetService(Type serviceType)
        {
            if (Registrations.TryGetValue(serviceType, out var creator))
            {
                return creator();
            }

            if (!serviceType.IsAbstract)
            {
                return this.CreateInstance(serviceType);
            }

            throw new Exception($"No registration found for service : {serviceType}");
        }

        #endregion

        #region Others

        private static IEnumerable<PropertyInfo> GetInjectableProperties(object obj)
        {
            var type = obj.GetType();
            var properties = InjectableProperties.GetOrAdd(type,
                t =>
                {
                    return t.GetProperties(BindingFlags.Instance
                                            | BindingFlags.SetProperty
                                            | BindingFlags.NonPublic
                                            | BindingFlags.Public)
                            .Where(property =>
                                    property.GetCustomAttributes(typeof(InjectAttribute), false).Any())
                            .Where(property => property.GetValue(obj, null) == null).ToList();
                });
            return properties;
        }

        private void InternalRegister<TService>(Func<object> creator)
        {
            var key = typeof(TService);
            if (Registrations.ContainsKey(key))
                Registrations[key] = creator;
            else
                Registrations.Add(typeof(TService), creator);
        }

        #endregion
    }
}
