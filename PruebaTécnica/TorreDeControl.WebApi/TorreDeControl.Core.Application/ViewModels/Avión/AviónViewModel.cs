using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorreDeControl.Core.Application.ViewModels.Aeropuerto;

namespace TorreDeControl.Core.Application.ViewModels.Avión
{
    public class AviónViewModel
    {
        public int idAvión { get; set; }
        public string nombreAvión { get;set; } = string.Empty;
        public DateTime horaDeSalida { get; set; }
        public DateTime horaDeLlegada { get; set; }
        public string aeropuertoDeSalida { get; set; } = string.Empty;
        public string aeropuertoDeLlegada { get; set; } = string.Empty;
        public int límitePasajeros { get; set; }
        public int pesolímite { get; set; }
        public string estadoDelAvión { get; set; } = string.Empty;
        public int cantidadPasajero { get; set; }
        public int pesoTotalPasajero { get; set; }
        public int FKaeropuerto { get; set; }
        public AeropuertoViewModel aeropuerto { get; set; } 

    }
}
