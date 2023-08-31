namespace backend.entidades
{
    public class OrdenReparacion : Common
    {
        public int Id{get; set;}
        public string NumeroOrden{get; set;}
        public int CostoEstimado{get; set;}
        public int IdEquipoMedico{get; set;}
        public int IdUsuario{get; set;}
    }
}