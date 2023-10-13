namespace U2Actividad2.Models.ViewModels
{
    public class IndexViewModel
    {
        public char[] ABC { get; set; } = null!;

        public ICollection<RazasPerroModel> RazasPerros { get; set; } = null!;

    }
    public class RazasPerroModel
    {
        public uint Id { get; set; }
        public string Nombre { get; set; } = null!;

    }
}
