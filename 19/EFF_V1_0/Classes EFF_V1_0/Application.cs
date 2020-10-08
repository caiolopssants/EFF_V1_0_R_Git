using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.Creation;
using Autodesk.Revit.UI.Events;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.DB.ExtensibleStorage;
using Autodesk.Revit.UI.Mechanical;
using Autodesk.Revit.UI.Plumbing;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.DB.Visual;

using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace TemplateDllLibraryProgram.Classes__Nome_do_programa_
{
    class Application
    {
        public Result OnStartup(UIControlledApplication uIControlledApplication)
        {
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication uIControlledApplication)
        {
            return Result.Succeeded;
        }
    }
}
