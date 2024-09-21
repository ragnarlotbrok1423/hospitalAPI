using System;
using System.Collections.Generic;

namespace campusCareAPI.Models;

public partial class CitasMedica
{
    public int IdcitasMedicas { get; set; }

    public DateOnly Fecha { get; set; }

    public int Servicio { get; set; }

    public int TipoConsulta { get; set; }

    public int Paciente { get; set; }

    public int Doctor { get; set; }

    public sbyte Visible { get; set; }

    public virtual Doctores DoctorNavigation { get; set; } = null!;

    public virtual Paciente PacienteNavigation { get; set; } = null!;

    public virtual Servicio ServicioNavigation { get; set; } = null!;

    public virtual TiposConsulta TipoConsultaNavigation { get; set; } = null!;
}
