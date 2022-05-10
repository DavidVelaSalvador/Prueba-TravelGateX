using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prueba_TravelGateX
{
    class Log_Manager
    {
        public string Buffer = "";
        public void Append(string Texto)
        {
            DateTime Hora = DateTime.Now;
            Buffer+= Environment.NewLine + Hora + ": " + Texto;
        }
    }
}
