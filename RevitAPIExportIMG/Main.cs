using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPIExportIMG
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;
            ImageExportOptions imgExportOptions = new ImageExportOptions
            {
                ZoomType = ZoomFitType.FitToPage,
                PixelSize = 1024,
                FilePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\123img.jpeg",
                FitDirection = FitDirectionType.Horizontal,
                HLRandWFViewsFileType = ImageFileType.JPEGLossless,
                ImageResolution = ImageResolution.DPI_600,
                ExportRange = ExportRange.CurrentView,
            };
            doc.ExportImage(imgExportOptions);

            TaskDialog.Show("Экспорт", "Экспорт прошел удачно");
            return Result.Succeeded;
        }
    }
}
