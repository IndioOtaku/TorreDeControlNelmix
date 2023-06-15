using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorreDeControl.Core.Domain.Entities
{
    public class Pasajero
    {
        public virtual int idPasajero { get; set; }
        public string nombrePasajero { get; set; } = string.Empty;
        public int pesoPasajero { get; set; }
        public int FKavión { get; set; }
        //Navigation Property
        public Avión Avión { get; set; }
    }
}
