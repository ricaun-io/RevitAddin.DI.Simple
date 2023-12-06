using System;

namespace RevitAddin.DI.Simple
{
    /// <summary>
    ///     Use to manage instances and the creation of instances
    /// </summary>
    public interface IContainer : IDisposable, IServiceProvider
    {
        #region Others

        /// <summary>
        ///     Get an instance of a specific service
        /// </summary>
        /// <typeparam name="TService">The type of the service</typeparam>
        /// <returns>The instance of the service</returns>
        TService GetService<TService>();

        /// <summary>
        ///     Inject the instance properties from the <see cref="IContainer" />
        /// </summary>
        /// <param name="instance">The instance to inject</param>
        void InjectProperties(object instance);

        /// <summary>
        ///     Register the type of the service to the container
        /// </summary>
        /// <typeparam name="TService">The type of the service</typeparam>
        void Register<TService>();

        /// <summary>
        ///     Register the type of the service to the container with the implementation type
        /// </summary>
        /// <typeparam name="TService">The type of the service</typeparam>
        /// <typeparam name="TImpl">The implementation type</typeparam>
        void Register<TService, TImpl>() where TImpl : TService;

        /// <summary>
        ///     Register the type of the service to the container with a delegate to create the instance
        /// </summary>
        /// <typeparam name="TService">The type of the service</typeparam>
        /// <param name="instanceCreator">The delegate to create the service instance</param>
        void Register<TService>(Func<TService> instanceCreator);

        #endregion
    }
}
