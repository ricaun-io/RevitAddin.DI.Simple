using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Linq;

namespace RevitAddin.DI.Simple.Services
{
    public class RevitCommandService
    {
        private readonly UIApplication uiapp;
        private readonly IWallService wallService;

        public RevitCommandService(UIApplication uiapp, IWallService wallService)
        {
            this.uiapp = uiapp;
            this.wallService = wallService;
        }
        public void ShowVersion()
        {
            TaskDialog.Show("Revit", uiapp.Application.VersionName);
        }

        public void ShowWalls()
        {
            Document document = uiapp.ActiveUIDocument.Document;

            var walls = wallService.Select(document);

            TaskDialog.Show("Revit Walls", $"Walls count = {walls.Count()}");
        }
    }
}
