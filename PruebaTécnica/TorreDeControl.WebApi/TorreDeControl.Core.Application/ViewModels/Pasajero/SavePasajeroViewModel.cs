using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorreDeControl.Core.Application.ViewModels.Aeropuerto;
using TorreDeControl.Core.Application.ViewModels.Avión;

namespace TorreDeControl.Core.Application.ViewModels.Pasajero
{
    public class SavePasajeroViewModel
    {
        public int idPasajero { get; set; }
        [Required(ErrorMessage = "Debe escribir el nombre del pasajero")]
        public string nombrePasajero { get; set; } = string.Empty;
        [Required(ErrorMessage = "Debe indicar el peso del pasajero")]
        [DataType(DataType.Currency)]
        public int pesoPasajero { get;set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe colocar el avión")]
        public int FKavión { get; set; }
        public List<AviónViewModel> Avión { get; set; }
    }
}
