using VrVektoren.Utilities;

namespace VrVektoren.Core
{
    public class Visualizer : Scene
    {
        public override bool Closed { get; protected set; } = true;
        public Vizualization Vizualization { get; set; }

        public override void Load()
        {
            Guard.IsTrue(Closed);
            Guard.IsNotNull(this.Vizualization);
            this.Closed = false;
        }

        public override void Close()
        {
            Guard.IsFalse(Closed);
            this.Closed = true;

            this.Vizualization.GotoFirstStep();
        }
    }
}
