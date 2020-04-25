using System;
using VrVektoren.Utilities;

namespace VrVektoren.Core
{
    public class SceneSelection : Scene
    {
        public override bool Closed { get; protected set; } = true;
        public override void Load()
        {
            Guard.IsTrue(Closed);
            this.Closed = false;

            // TODO implement
        }

        public override void Close()
        {
            Guard.IsFalse(Closed);
            this.Closed = true;
            
            // TODO implement
        }

        public void OpenQRCodeScanner()
        {
            // TODO implement
        }

        public void OpenVectorVisualizer(int sceneId)
        {
            // TODO implement
        }
    }
}
