using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Linq;

namespace RevitAddin.DI.Simple.Services
{
    public class WallService : IWallService
    {
        public IEnumerable<Wall> Select(Document document)
        {
            return new FilteredElementCollector(document)
                .WhereElementIsNotElementType()
                .OfClass(typeof(Wall))
                .OfType<Wall>();
        }
    }
}
