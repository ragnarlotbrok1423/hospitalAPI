using System;
using System.Collections.Generic;

namespace campusCareAPI.Models;

public partial class Doctores
{
    public int IdDoctores { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public string Cedula { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public string Especialidad { get; set; } = null!;

    public string Diploma { get; set; } = null!;

    public string Perfil { get; set; } = null!;

    public int InformacionMedica { get; set; }

    public virtual ICollection<CitasMedica> CitasMedicas { get; set; } = new List<CitasMedica>();

    public virtual InformacionesMedica InformacionMedicaNavigation { get; set; } = null!;
}
