namespace Prueba.models
{
    public class MuestrasModel
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string nombrePaciente { get; set; }
        public int tipoMuestra { get; set; }
        public DateTime fechaToma { get; set; }
        public double temperatura { get; set; }
        public bool estado { get; set; }
        public string observaciones { get; set; }
    }

    public class TipoMuestra
    {
        public int id { get; set; }
        public string nombre { get; set; }
    }

    public class Status
    {
        public int id { get; set; }
        public bool estado { get; set; }
    }

    public class Response
    {
        public bool? Flag { get; set; }
        public int? Status { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}
