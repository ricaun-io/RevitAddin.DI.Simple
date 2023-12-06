using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitAddin.DI.Simple.Services.My;

namespace RevitAddin.DI.Simple.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class CommandMyB : ContainerObject, IExternalCommand
    {
        [Inject]
        private IMyServiceB ServiceB { get; set; }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;

            ServiceB.Method();

            return Result.Succeeded;
        }
    }

}
