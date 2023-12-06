using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitAddin.DI.Simple.Services;
using ricaun.Revit.UI;
using System;

namespace RevitAddin.DI.Simple.Revit
{
    [AppLoader]
    public class App : IExternalApplication, IContainerObject
    {
        private static RibbonPanel ribbonPanel;
        public Result OnStartup(UIControlledApplication application)
        {
            ribbonPanel = application.CreatePanel("DI.Simple");
            ribbonPanel.CreatePushButton<Commands.Command>("Version")
                .SetLargeImage("Resources/Revit.ico");

            ribbonPanel.CreatePushButton<Commands.CommandWalls>("Walls")
                .SetLargeImage("Resources/Revit.ico");

            var container = this.GetContainer();

            container.Singleton<UIControlledApplication>(application);
            container.Singleton<UIApplication>(application.GetUIApplication());

            container.Singleton<RevitCommandService>();
            container.Singleton<IWallService, WallService>();

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            ribbonPanel?.Remove();
            this.GetContainer()?.Dispose();
            return Result.Succeeded;
        }
    }

}