using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using PruebaPsi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaPsi.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<List<Usuarios>> Import(IFormFile file)
        {

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var list = new List<Usuarios>();
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowcount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= rowcount; row++)
                    {
                        list.Add(new Usuarios {
                            Id=worksheet.Cells[row,1].Value.ToString().Trim(),
                            Nombres=worksheet.Cells[row, 2].Value.ToString().Trim(),
                            Apellidos=worksheet.Cells[row, 3].Value.ToString().Trim(),
                            Identificaccion=worksheet.Cells[row, 4].Value.ToString().Trim(),
                            Celular=worksheet.Cells[row, 5].Value.ToString().Trim(),
                            Direccion=worksheet.Cells[row, 6].Value.ToString().Trim(),
                            Ciudad=worksheet.Cells[row, 7].Value.ToString().Trim(),
                            Correo=worksheet.Cells[row, 8].Value.ToString().Trim(),
                        });
                    }
                }                   
            }
            return list;
        }

    }
}
