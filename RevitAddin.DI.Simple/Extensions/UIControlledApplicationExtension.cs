namespace Autodesk.Revit.UI
{
    using System;
    using System.Linq;
    using System.Reflection;
    /// <summary>
    /// UIControlledApplicationExtension
    /// </summary>
    public static class UIControlledApplicationExtension
    {
        /// <summary>
        /// Get <see cref="UIApplication"/> using the <paramref name="application"/>
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public static UIApplication GetUIApplication(this UIControlledApplication application)
        {
            var type = typeof(UIControlledApplication);

            var propertie = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(e => e.FieldType == typeof(UIApplication));

            return propertie?.GetValue(application) as UIApplication;
        }

        /// <summary>
        /// Get <see cref="UIControlledApplication"/> using the <paramref name="application"/>
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public static UIControlledApplication GetControlledApplication(this UIApplication application)
        {
            var type = typeof(UIControlledApplication);

            var constructor = type.GetConstructor(
                BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { application.GetType() }, null);

            return constructor?.Invoke(new object[] { application }) as UIControlledApplication;
        }
    }
}
