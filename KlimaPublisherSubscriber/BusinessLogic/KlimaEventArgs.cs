using System;

namespace KlimaPublisherSubscriber.BusinessLogic
{

        public class KlimaEventArgs : EventArgs
        {
            public readonly StanjeKlime status;
            public KlimaEventArgs(StanjeKlime status)
            {
                this.status = status;
            }
        }
    
}
