using System;
using VrVektoren.Core;
using VrVektoren.Utilities;

namespace VrVektoren.Core
{
    // Optional not needed for normal Workflow
    public class QRCodeScanner : Scene
    {
        public override bool Closed { get; protected set; } = true;
        public bool IsScanning {get; private set;} = false;
        public String QRCode 
        {
            get
            {
                if(this.QRCode != null) 
                {
                    return this.QRCode;
                }
                else 
                {
                    return "";
                }
            }
            set
            {
                Guard.IsNotNull(value);
                this.QRCode = value;
            }
        }

        public override void Load()
        {
            Guard.IsTrue(Closed);
            this.Closed = false;
            this.IsScanning = true;

            // TODO display scene list
        }

        public override void Close()
        {
            Guard.IsFalse(Closed);
            this.Closed = true;
            this.IsScanning = false;

            // TODO implement
        }

        public void FinishScanning()
        {
            this.IsScanning = false;

            // TODO implement
        }
    }
}
