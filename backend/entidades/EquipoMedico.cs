namespace backend.entidades
{
    public class EquipoMedico : Common
    {
        public int Id{get; set;}
        public string NombreEquipo{get; set;}
        public string DescripcionProblema{get; set;}
        public string EstadoReparacion{get; set;}
    }
}