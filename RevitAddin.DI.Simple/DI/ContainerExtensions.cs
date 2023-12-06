using System;

namespace RevitAddin.DI.Simple
{
    public static class ContainerExtensions
    {
        #region Others

        public static IContainer Singleton<TService>(this IContainer container, TService instance)
        {
            container.Register(() => instance);
            return container;
        }

        public static IContainer Singleton<TService>(this IContainer container, Func<TService> instanceCreator)
        {
            var lazy = new Lazy<TService>(instanceCreator);
            container.Register(() => lazy.Value);
            return container;
        }

        public static IContainer Singleton<TService, TImpl>(this IContainer container)
            where TImpl : TService
        {
            return container.Singleton<TService, TImpl>(() =>
                typeof(TService) == typeof(TImpl) ? container.CreateInstance<TImpl>() : container.GetService<TImpl>());
        }

        public static IContainer Singleton<TService, TImpl>(this IContainer container, Func<TImpl> instanceCreator)
            where TImpl : TService
        {
            var lazy = new Lazy<TImpl>(instanceCreator);
            container.Register<TService>(() => lazy.Value);
            return container;
        }

        public static IContainer Singleton<TService1, TService2, TImpl>(this IContainer container)
            where TImpl : TService1, TService2
        {
            var implType = typeof(TImpl);
            return container.Singleton<TService1, TService2, TImpl>(() => typeof(TService1) == implType ||
                                                                            typeof(TService2) == implType
                                                                                ? container.CreateInstance<TImpl>()
                                                                                : container.GetService<TImpl>());
        }

        public static IContainer Singleton<TService1, TService2, TImpl>(this IContainer container, Func<TImpl> instanceCreator)
            where TImpl : TService1, TService2
        {
            var lazy = new Lazy<TImpl>(instanceCreator);
            container.Register<TService1>(() => lazy.Value);
            container.Register<TService2>(() => lazy.Value);
            return container;
        }

        public static IContainer Singleton<TService1, TService2, TService3, TImpl>(this IContainer container)
            where TImpl : TService1, TService2, TService3
        {
            var implType = typeof(TImpl);
            return container.Singleton<TService1, TService2, TImpl>(() => typeof(TService1) == implType ||
                                                                            typeof(TService2) == implType ||
                                                                            typeof(TService3) == implType
                                                                                ? container.CreateInstance<TImpl>()
                                                                                : container.GetService<TImpl>());
        }

        public static IContainer Singleton<TService1, TService2, TService3, TImpl>(this IContainer container, Func<TImpl> instanceCreator)
            where TImpl : TService1, TService2, TService3
        {
            var lazy = new Lazy<TImpl>(instanceCreator);
            container.Register<TService1>(() => lazy.Value);
            container.Register<TService2>(() => lazy.Value);
            container.Register<TService3>(() => lazy.Value);
            return container;
        }

        public static IContainer Singleton<TService1, TService2, TService3, TService4, TImpl>(this IContainer container)
            where TImpl : TService1, TService2, TService3, TService4
        {
            var implType = typeof(TImpl);
            return container.Singleton<TService1, TService2, TImpl>(() => typeof(TService1) == implType ||
                                                                            typeof(TService2) == implType ||
                                                                            typeof(TService3) == implType ||
                                                                            typeof(TService4) == implType
                                                                                ? container.CreateInstance<TImpl>()
                                                                                : container.GetService<TImpl>());
        }

        public static IContainer Singleton<TService1, TService2, TService3, TService4, TImpl>(this IContainer container, Func<TImpl> instanceCreator)
            where TImpl : TService1, TService2, TService3, TService4
        {
            var lazy = new Lazy<TImpl>(instanceCreator);
            container.Register<TService1>(() => lazy.Value);
            container.Register<TService2>(() => lazy.Value);
            container.Register<TService3>(() => lazy.Value);
            container.Register<TService4>(() => lazy.Value);
            return container;
        }

        #endregion
    }
}
