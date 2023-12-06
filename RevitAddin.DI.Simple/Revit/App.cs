using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ricaun.Revit.UI;
using System;

namespace RevitAddin.DI.Simple.Revit
{
    [AppLoader]
    public class App : IExternalApplication
    {
        private static RibbonPanel ribbonPanel;
        public Result OnStartup(UIControlledApplication application)
        {
            ribbonPanel = application.CreatePanel("RevitAddin.DI.Simple");
            ribbonPanel.CreatePushButton<Commands.Command>()
                .SetLargeImage("Resources/Revit.ico");
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            ribbonPanel?.Remove();
            return Result.Succeeded;
        }
    }

}