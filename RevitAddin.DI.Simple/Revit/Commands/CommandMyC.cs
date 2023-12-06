using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitAddin.DI.Simple.Services.My;

namespace RevitAddin.DI.Simple.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class CommandMyC : IExternalCommand, IContainerObject
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;

            this.GetService<IMyServiceC>()
                .Method();

            return Result.Succeeded;
        }
    }
}
