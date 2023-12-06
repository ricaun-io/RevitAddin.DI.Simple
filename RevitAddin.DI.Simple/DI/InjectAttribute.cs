using System;

namespace RevitAddin.DI.Simple
{
    /// <summary>
    ///     Inject an object to a property from the <see cref="IContainer" />, the property should always have a setter
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class InjectAttribute : Attribute
    {
    }
}
