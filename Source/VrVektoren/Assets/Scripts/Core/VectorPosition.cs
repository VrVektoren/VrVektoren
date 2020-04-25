using VrVektoren.Utilities;

namespace VrVektoren.Core
{
    public class VectorPosition
    {
        public VectorPosition(
            bool isVisible, 
            Point point, 
            EulerAngle angle, 
            double lenght)
        {
            Guard.IsNotNull(point);
            Guard.IsNotNull(angle);

            this.IsVisible = isVisible;
            this.Point = point;
            this.Angle = angle;
            this.Lenght = lenght;
        }

        public bool IsVisible { get; private set; }
        public Point Point { get; private set; }
        public EulerAngle Angle { get; private set; }
        public double Lenght { get; private set; }
    }
}
