using Autodesk.Revit.DB;
using System.Collections.Generic;

namespace RevitAddin.DI.Simple.Services
{
    public interface IWallService
    {
        IEnumerable<Wall> Select(Document document);
    }
}