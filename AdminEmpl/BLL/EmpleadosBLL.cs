using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminEmpl.BLL
{
    internal class EmpleadosBLL
    {
        public int ID { get; set; }
        public string NombreEmpleado { get; set; }
        public string PrimerApellidp { get; set; }
        public string SegundoApellido { get; set; }
        public int Departamento { get; set; }
        public string Correo { get; set; }
        public byte[] FotoEmpleado { get; set; }
}
}
