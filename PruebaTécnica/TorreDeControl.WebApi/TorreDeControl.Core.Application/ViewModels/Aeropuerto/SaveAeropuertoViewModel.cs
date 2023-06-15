using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorreDeControl.Core.Application.ViewModels.Aeropuerto
{
    public class SaveAeropuertoViewModel
    {
        public int idAeropuerto {  get; set; }
        [Required(ErrorMessage = "Debe colocar el nombre del aeropuerto")]
        public string nombreAeropuerto { get; set; } = string.Empty;
        [Required(ErrorMessage = "Debe indicar la cantidad de aviones que soporta el aeropuerto")]
        public int límiteAviones { get; set; }
    }
}
