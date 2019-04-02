using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlimaPublisherSubscriber.BusinessLogic
{
    public class TemperaturaEventArgs : EventArgs
    {
        public double Temperatura { get; set; }
    }
}
