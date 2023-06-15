using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorreDeControl.Core.Application.ViewModels.Aeropuerto;

namespace TorreDeControl.Core.Application.ViewModels.Avión
{
    public class SaveAviónViewModel
    {
        public int idAvión { get; set; }
        [Required(ErrorMessage = "Debe colocar el nombre del avión")]
        public string nombreAvión { get;set; } = string.Empty;
        public DateTime? horaDeLlegada { get; set; }
        public DateTime? horaDeSalida { get; set; }

        [Required(ErrorMessage = "Debe ingresar el aeropuerto de salida")]
        public string aeropuertoDeSalida { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe ingresar el aeropuerto de llegada")]
        public string aeropuertoDeLlegada { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe ingresar el límite de pasajeros")]
        [DataType(DataType.Currency)]
        public int límitePasajeros { get; set; }

        [Required(ErrorMessage = "Debe ingresar el peso límite del avión")]
        [DataType(DataType.Currency)]
        public int pesoLímite { get; set; }
        public string estadoDelAvión { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Debe colocar el aeropuerto")]
        public int FKaeropuerto { get; set; }
        public List<AeropuertoViewModel> Aeropuertos { get; set; }
    }
}
