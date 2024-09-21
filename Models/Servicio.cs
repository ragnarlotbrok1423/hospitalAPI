using System;
using System.Collections.Generic;

namespace campusCareAPI.Models;

public partial class Servicio
{
    public int Idservicios { get; set; }

    public sbyte CertificadoBuenaSalud { get; set; }

    public float Peso { get; set; }

    public int? Inhaloterapias { get; set; }

    public string? Inyecciones { get; set; }

    public float? GlisemiaCapilar { get; set; }

    public string? ReferenciaMedica { get; set; }

    public virtual ICollection<CitasMedica> CitasMedicas { get; set; } = new List<CitasMedica>();
}
