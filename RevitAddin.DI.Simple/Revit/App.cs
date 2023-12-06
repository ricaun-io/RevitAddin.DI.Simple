using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitAddin.DI.Simple.Revit.Commands;
using RevitAddin.DI.Simple.Services;
using RevitAddin.DI.Simple.Services.Commands;
using RevitAddin.DI.Simple.Services.My;
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
            ribbonPanel.CreatePushButton<Command>("Version")
                .SetLargeImage("Resources/Revit.ico");

            ribbonPanel.CreatePushButton<CommandWalls>("Walls")
                .SetLargeImage("Resources/Revit.ico");

            ribbonPanel.RowStackedItems(
                ribbonPanel.CreatePushButton<CommandMyA>("My A")
                    .SetLargeImage("Resources/Revit.ico"),
                ribbonPanel.CreatePushButton<CommandMyB>("My B")
                    .SetLargeImage("Resources/Revit.ico"),
                ribbonPanel.CreatePushButton<CommandMyC>("My C")
                    .SetLargeImage("Resources/Revit.ico")
                );

            ribbonPanel.RowStackedItems(
               ribbonPanel.CreatePushButton<RevitCommand<CommandA>>("Command A")
                   .SetLargeImage("Resources/Revit.ico"),
               ribbonPanel.CreatePushButton<RevitCommand<CommandB>>("Command B")
                   .SetLargeImage("Resources/Revit.ico"),
               ribbonPanel.CreatePushButton<RevitCommand<CommandC>>("Command C")
                   .SetLargeImage("Resources/Revit.ico")
               );

            // Register services
            {
                var container = this.GetContainer();
                container.Singleton<UIControlledApplication>(application);
                container.Singleton<UIApplication>(application.GetUIApplication());

                container.Singleton<RevitCommandService>();
                container.Singleton<IWallService, WallService>();

                container.Singleton<IMyServiceA, MyServiceA>();
                container.Singleton<IMyServiceB, MyServiceB>();
                container.Singleton<IMyServiceC, MyServiceC>();

                container.Singleton<CommandA>();
                container.Singleton<CommandB>();
                container.Singleton<CommandC>();
            }

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