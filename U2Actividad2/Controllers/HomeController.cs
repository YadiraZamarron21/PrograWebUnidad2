using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using U2Actividad2.Models.Entities;
using U2Actividad2.Models.ViewModels;

namespace U2Actividad2.Controllers
{
    public class HomeController : Controller
    {
        Random R = new();
        public HomeController()
        {
            LlenarAbece();
        }
    
        private readonly char[] abece = new char[26];
        List<OtrosPerros> ListaPerros { get; set; } = new();
        private void LlenarAbece()
        {
            byte b = 65;
            for (int i = 0; i < 26; i++)
            {
                abece[i] += (char)b;
                b++;
            }
        }
        public IActionResult Index()
        {
            PerrosContext context = new();

            var datos = context.Razas.OrderBy(x => x.Nombre).Select(x => new RazasPerroModel
            {
                Id = x.Id,
                Nombre = x.Nombre
            }).ToList();

            IndexViewModel vm = new()
            {
                RazasPerros = datos,
                ABC = abece
            };
            return View(vm);
        }


        [Route("/Perro/{Id}")]
        public IActionResult Raza(string Id)
        {
            PerrosContext context = new();

            Id = Id.Replace("-", " ");
            var datos = context.Razas.
                Where(x => x.Nombre == Id).Select(x => new RazaViewModel
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    OtrosNombres = x.OtrosNombres ?? "Sin nombre",
                    Descripcion = x.Descripcion ?? "Sin descripcion",
                    AlturaMaxima = x.AlturaMax,
                    AlturaMinima = x.AlturaMin,
                    EsperanzaVida = x.EsperanzaVida,
                    Pais = x.IdPaisNavigation != null ? (x.IdPaisNavigation.Nombre ?? "Sin pais") : "",
                    PesoMaximo = x.PesoMax,
                    PesoMinimo = x.PesoMin,

                    estadisticas = new EstadisticasModel
                    {
                        AmistadDesconocidos = x.Estadisticasraza != null ? x.Estadisticasraza.AmistadDesconocidos : 0,
                        AmistadPerros = x.Estadisticasraza != null ? x.Estadisticasraza.AmistadPerros : 0,
                        EjercicioObligatorio = x.Estadisticasraza != null ? x.Estadisticasraza.EjercicioObligatorio : 0,
                        FacilidadEntrenamiento = x.Estadisticasraza != null ? x.Estadisticasraza.FacilidadEntrenamiento : 0,
                        NecesidadCepillado = x.Estadisticasraza != null ? x.Estadisticasraza.NecesidadCepillado : 0,
                        NivelEnergia = x.Estadisticasraza != null ? x.Estadisticasraza.NivelEnergia : 0
                    },
                    caracteristicas = new CaracteristicasModel
                    {
                        Cola = x.Caracteristicasfisicas != null ? x.Caracteristicasfisicas.Cola ?? "" : "",
                        Color = x.Caracteristicasfisicas != null ? x.Caracteristicasfisicas.Color ?? "" : "",
                        Hocico = x.Caracteristicasfisicas != null ? x.Caracteristicasfisicas.Hocico ?? "" : "",
                        Patas = x.Caracteristicasfisicas != null ? x.Caracteristicasfisicas.Patas ?? "" : "",
                        Pelo = x.Caracteristicasfisicas != null ? x.Caracteristicasfisicas.Pelo ?? "" : "",
                    },
                    OtrosPerros = null!
                }).First();
            LlenarPerrrosAleatorios(Id);
            datos.OtrosPerros = ListaPerros;
            return View(datos);

        }

        public void LlenarPerrrosAleatorios(string nombre)
        {
            PerrosContext context = new();
            ListaPerros.Clear();
            var datos = context.Razas.Where(x => x.Nombre != nombre).Select(x => new OtrosPerros
            {
                Id = x.Id,
                Nombre = x.Nombre
            }).ToList();

            for (int i = 0; i < 4; i++)
            {
                int a = R.Next(0, datos.Count);
                OtrosPerros otros = datos[a];
                if (!ListaPerros.Contains(otros))
                {
                    ListaPerros.Add(otros);
                }
                    
            }
        }

        [Route("/{filtrar}")]
        public IActionResult Index(string filtrar)
        {
            PerrosContext context = new();

            var datos = context.Razas.Where(x => x.Nombre.StartsWith(filtrar)).
                OrderBy(x => x.Nombre).Select(x => new RazasPerroModel
                {
                    Id = x.Id,
                    Nombre = x.Nombre
                }).ToList();

            IndexViewModel vm = new()
            {
                RazasPerros = datos,
                ABC = abece
            };
            return View(vm);
        }

        [Route("/Paises")]
        public IActionResult Paises()
        {
            PerrosContext context = new();
            var datos = context.Paises.OrderBy(x => x.Nombre).Select(x => new PaisViewModel
            {
                Nombre = x.Nombre ?? "",
                Razasperros = x.Razas.OrderBy(r => r.Nombre).Select(r => new RazasPModel
                {
                    Id = r.Id,
                    Nombre = r.Nombre

                }).ToList()
            }).AsEnumerable();

            return View(datos);
        }

    }
}
