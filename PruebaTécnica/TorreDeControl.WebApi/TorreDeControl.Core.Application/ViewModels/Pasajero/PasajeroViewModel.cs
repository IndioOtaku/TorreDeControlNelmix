using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorreDeControl.Core.Application.ViewModels.Avión;

namespace TorreDeControl.Core.Application.ViewModels.Pasajero
{
    public class PasajeroViewModel
    {
        public int idPasajero { get; set; }
        public string nombrePasajero { get; set; } = string.Empty;
        public int pesoPasajero { get; set; }
        public string nombreAvión { get; set; } = string.Empty;
        public int FKavión { get; set; }
        public AviónViewModel Avión { get; set; }
    }
}
