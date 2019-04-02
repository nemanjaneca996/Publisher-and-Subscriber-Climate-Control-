using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlimaPublisherSubscriber.BusinessLogic
{

    public enum StanjeKlime{Off,Hladjenje,Grejanje}

    public partial class Klima
    {
        public string Naziv { get; set; }

        private double hladjenje;

        private double grejanje;

        public StanjeKlime stanje;

        public delegate void KlimaEventHandler(Klima sender, KlimaEventArgs e);

        public event KlimaEventHandler changedStatus;

        public virtual void OnChangedStatus()
        {
            if(changedStatus != null)
                this.changedStatus(this, new KlimaEventArgs(this.stanje));
        }


        public Klima(double hladjenje, double grejanje)
        {
            this.hladjenje = hladjenje;
            this.grejanje = grejanje;  
        }


        public void promenaTemperature(Termometar sender, TemperaturaEventArgs e)
        {
            if (e.Temperatura <= grejanje)
            {
                stanje = StanjeKlime.Grejanje;
                OnChangedStatus();
            }

            else if (e.Temperatura >= hladjenje)
            {
                stanje = StanjeKlime.Hladjenje;
                OnChangedStatus();
            }
            else
            {
                stanje = StanjeKlime.Off;
                OnChangedStatus();
            }
        }

    }
}
