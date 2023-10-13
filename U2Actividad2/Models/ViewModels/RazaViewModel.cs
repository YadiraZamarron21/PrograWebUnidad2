﻿namespace U2Actividad2.Models.ViewModels
{
    public class RazaViewModel
    {
        public uint Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string OtrosNombres { get; set; } = null!;
        public string Pais { get; set; } = null!;
        public float PesoMinimo { get; set; }
        public float PesoMaximo { get; set; }
        public float AlturaMinima { get; set; }
        public float AlturaMaxima { get; set; }
        public uint EsperanzaVida { get; set; }
        public EstadisticasModel estadisticas { get; set; } = null!;
        public CaracteristicasModel caracteristicas { get; set; } = null!;
        public ICollection<OtrosPerros> OtrosPerros { get; set; } = null!;
    }
    public class EstadisticasModel
    {
        public uint NivelEnergia { get; set; }
        public uint FacilidadEntrenamiento { get; set; }
        public uint EjercicioObligatorio { get; set; }
        public uint AmistadDesconocidos { get; set; }
        public uint AmistadPerros { get; set; }
        public uint NecesidadCepillado { get; set; }
    }
    public class CaracteristicasModel
    {
        public string Patas { get; set; } = null!;
        public string Cola { get; set; } = null!;
        public string Hocico { get; set; } = null!;
        public string Pelo { get; set; } = null!;
        public string Color { get; set; } = null!;
    }
    public class OtrosPerros
    {
        public uint Id { get; set; }
        public string Nombre { get; set; } = null!;
    }
}
