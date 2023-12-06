using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitAddin.DI.Simple.Services;
using System;

namespace RevitAddin.DI.Simple.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand, IContainerObject
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            this.GetService<RevitService>()
                .ShowVersion();

            return Result.Succeeded;
        }
    }
}
