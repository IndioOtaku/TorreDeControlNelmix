using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorreDeControl.Core.Domain.Entities
{
    public class Aeropuerto
    {
        public virtual int idAeropuerto { get; set; } 
        public string nombreAeropuerto { get; set; } = string.Empty;
        public int límiteAviones { get; set; }

        //navigation property
        public ICollection<Avión>? Aviones { get; set; }

    }
}
