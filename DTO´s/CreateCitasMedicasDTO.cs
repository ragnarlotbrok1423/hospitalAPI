namespace campusCareAPI.Models
{
    public class CreateCitasMedicasDTO
    {
        public DateOnly Fecha { get; set; }
        public sbyte CertificadoBuenaSalud { get; set; }

        public float Peso { get; set; }

        public int? Inhaloterapias { get; set; }

        public string? Inyecciones { get; set; }
        
        public float? GlisemiaCapilar { get; set; }
        public string? ReferenciaMedica { get; set; }
        public string TipoConsulta { get; set; } = null!;
        public int IdUsuario { get; set; }
        public int IdDoctor { get; set; }
    }
}
                                