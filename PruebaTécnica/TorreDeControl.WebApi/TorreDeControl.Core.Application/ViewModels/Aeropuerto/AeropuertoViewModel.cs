using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorreDeControl.Core.Application.ViewModels.Aeropuerto
{
    public class AeropuertoViewModel
    {
        public int idAeropuerto { get; set; }
        public string nombreAeropuerto { get; set; } = string.Empty;
        public int límiteAviónes { get; set;}
    }
}
