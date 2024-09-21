using System;
using System.Collections.Generic;

namespace campusCareAPI.Models;

public partial class TiposConsulta
{
    public int IdtiposConsultas { get; set; }

    public string TipoConsulta { get; set; } = null!;

    public virtual ICollection<CitasMedica> CitasMedicas { get; set; } = new List<CitasMedica>();
}
