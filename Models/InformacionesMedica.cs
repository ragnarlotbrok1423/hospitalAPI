using System;
using System.Collections.Generic;

namespace campusCareAPI.Models;

public partial class InformacionesMedica
{
    public int IdinformacionesMedicas { get; set; }

    public string? Alergia { get; set; }

    public string NumeroSecundario { get; set; } = null!;

    public int Tipaje { get; set; }

    public virtual ICollection<Doctores> Doctores { get; set; } = new List<Doctores>();

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();

    public virtual TipajesSanguineo TipajeNavigation { get; set; } = null!;
}
