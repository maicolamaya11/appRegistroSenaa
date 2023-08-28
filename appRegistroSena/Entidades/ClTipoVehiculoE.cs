using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appRegistroSena.Entidades
{
    public class ClTipoVehiculoE
    {
        public int idTipoVehiculo { get; set; }
        public string tipoVehiculo { get; set; }
        public string placa { get; set; }
        public string color { get; set; }
        public string marca { get; set; }
        public int idRegistro { get; set; }
    }
}