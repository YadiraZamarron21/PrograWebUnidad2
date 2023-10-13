namespace U2Actividad2.Models.ViewModels
{
    public class PaisViewModel
    {
        public string Nombre { get; set; } = null!;
        public ICollection<RazasPModel> Razasperros { get; set; } = null!;
    }
    public class RazasPModel
    {
        public uint Id { get; set; }
        public string Nombre { get; set; } = null!;
    }
}
