namespace RevitAddin.DI.Simple
{
    /// <summary>
    /// IContainerObject
    /// </summary>
    public interface IContainerObject
    {

    }

    /// <summary>
    /// IContainerObject Extensions
    /// </summary>
    public static class IContainerObjectExtensions
    {
        public static IContainer GetContainer(this IContainerObject containerObject)
        {
            return SimpleContainer.Container;
        }

        public static TService GetService<TService>(this IContainerObject containerObject)
        {
            return containerObject
                .GetContainer()
                .GetService<TService>();
        }
    }
}
