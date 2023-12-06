namespace RevitAddin.DI.Simple
{
    /// <summary>
    ///     A base object which can automatically inject properties attributed with <see cref="InjectAttribute" /> from the
    ///     <see cref="IContainer" />
    /// </summary>
    public abstract class ContainerObject
    {
        #region Constructors

        // ReSharper disable once UnusedMember.Global
        protected ContainerObject()
        {
            InjectProperties();
        }

        #endregion

        #region Properties

        protected IContainer Container => SimpleContainer.Container;

        #endregion

        #region Others

        protected void InjectProperties()
        {
            Container?.InjectProperties(this);
        }

        #endregion
    }
}
