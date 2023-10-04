using U2Actividad1.Models.Entities;

namespace U2Actividad1.Models.ViewModels
{     
        public class EspeciesViewModel
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = null!;

            public ICollection<Especies> ListaEspecies { get; set; } = null!;
        }
    }

