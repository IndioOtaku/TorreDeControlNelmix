using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorreDeControl.Core.Domain.Entities
{
    public class Avión
    {
        public virtual int idAvión { get; set; }
        public string nombreAvión { get; set; } = string.Empty;
        public DateTime horaDeSalida { get; set; }
        public DateTime horaDeLlegada { get; set;}
        public string aeropuertoDeSalida { get; set; } = string.Empty;
        public string aeropuertoDeLlegada { get; set; } = string.Empty;
        public int límitePasajeros { get; set; }
        public int pesoLímite { get; set; }
        public string estadoDelAvión { get; set; } = string.Empty;
        public int FKaeropuerto { get; set; }

        //Navigation Property
        public Aeropuerto Aeropuerto { get; set; }
        //navigation property
        public ICollection<Pasajero> Pasajeros { get; set; }
    }
}
