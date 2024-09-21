using System;
using System.Collections.Generic;

namespace campusCareAPI.Models;

public partial class TipajesSanguineo
{
    public int IdtipajesSanguineos { get; set; }

    public string TipoSanguineo { get; set; } = null!;

    public virtual ICollection<InformacionesMedica> InformacionesMedicas { get; set; } = new List<InformacionesMedica>();
}
