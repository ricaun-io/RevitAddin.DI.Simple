using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace RevitAddin.DI.Simple.Services.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class RevitCommand<T> : IContainerObject, IExternalCommand where T : ICommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            this.GetService<T>().Execute();
            return Result.Succeeded;
        }
    }

}
