namespace campusCareAPI.Models
{
    public class ServiciosDTO
    {
        public sbyte CertificadoBuenaSalud { get; set; }

        public float Peso { get; set; }

        public int? Inhaloterapias { get; set; }

        public string? Inyecciones { get; set; }

        public float? GlisemiaCapilar { get; set; }

        public string? ReferenciaMedica { get; set; }
    }
}
