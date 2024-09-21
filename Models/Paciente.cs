using System;
using System.Collections.Generic;

namespace campusCareAPI.Models;

public partial class Paciente
{
    public int IdUsuarios { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Cedula { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public string NombreUsuario { get; set; } = null!;

    public int InformacionMedica { get; set; }

    public sbyte Visible { get; set; }

    public virtual ICollection<CitasMedica> CitasMedicas { get; set; } = new List<CitasMedica>();

    public virtual InformacionesMedica InformacionMedicaNavigation { get; set; } = null!;
}
