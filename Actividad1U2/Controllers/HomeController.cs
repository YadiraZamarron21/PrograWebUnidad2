using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using U2Actividad1.Models.Entities;
using U2Actividad1.Models.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace U2Actividad1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            AnimalesContext context = new();
            var datos = context.Clase.OrderBy(x => x.Nombre).Select(x => new IndexViewModel
            {
                Id = x.Id,
                Nombre = x.Nombre ?? "",
                Descripcion = x.Descripcion ?? "",
            }).AsEnumerable();

            return View(datos);
        }

        public IActionResult Especies(string id)
        {
            AnimalesContext context = new();

            var claseEspecies = context.Clase.Include(x => x.Especies).Select(x => new EspeciesViewModel
            {
                Id = x.Id,
                Nombre = x.Nombre ?? "",
                ListaEspecies = x.Especies
            }).FirstOrDefault(x => x.Nombre == id.Replace("-", " "));
           

            return View(claseEspecies);

        }

        public IActionResult Especie(string id)
        {
            AnimalesContext context = new();
            id = id.Replace("-"," ");
            var animal = context.Especies.Include(x => x.IdClaseNavigation).
                Where(x => x.Especie.ToLower() == id.ToLower()).FirstOrDefault();

            if (animal == null)
            {
                return RedirectToAction("Especies");
            }
            else
            {
                EspecieViewModel vm = new()
                {
                    Id = animal.Id,
                    Clase = animal.IdClaseNavigation !=null ? animal.IdClaseNavigation.Nombre ?? "":"",
                    Nombre = animal.Especie,
                    Peso = (double)(animal.Peso ?? 0),
                    Habitat = animal.Habitat ?? "",
                    Tamaño = animal.Tamaño ?? 0,
                    Descripcion = animal.Observaciones ?? "Sin descripcion"
                };
                return View(vm);
            }
        }

    }
}
