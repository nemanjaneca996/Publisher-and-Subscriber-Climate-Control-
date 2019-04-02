using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlimaPublisherSubscriber.BusinessLogic
{
    public class Termometar
    {
        public delegate void TermometarEventHandler(Termometar sender, TemperaturaEventArgs e);

        public event TermometarEventHandler promenaTemperature;

        private double temperatura;

        public void Add(Klima klima)
        {
            promenaTemperature += klima.promenaTemperature;
        }

        public double Temperatura
        {
            get => temperatura;

            set
            {
                if (temperatura != value)
                {
                    this.temperatura = value;
                    if(promenaTemperature != null)
                        this.promenaTemperature(this,new TemperaturaEventArgs(){Temperatura = value});
                }
            }
        }


    }
}
