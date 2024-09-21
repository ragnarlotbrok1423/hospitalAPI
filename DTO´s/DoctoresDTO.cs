using campusCareAPI.Models;

namespace campusCareAPI.DTO_s
{
    public class DoctoresDTO
    {
        public int IdDoctores { get; set; }

        public string NombreCompleto { get; set; } = null!;

        public string Cedula { get; set; } = null!;

        public string Contraseña { get; set; } = null!;

        public string Especialidad { get; set; } = null!;

        public string Diploma { get; set; } = null!;

        public string Perfil { get; set; } = null!;

       public InformacionMedicaDTO InformacionMedica { get; set; } = null!;
       
        
        
    }

}
