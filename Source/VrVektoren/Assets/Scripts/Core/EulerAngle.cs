namespace VrVektoren.Core
{
    public class EulerAngle
    {
        public EulerAngle(double xAngle, double yAngle, double zAngle)
        {
            this.XAngle = xAngle % 360;
            this.YAngle = yAngle % 360;
            this.ZAngle = zAngle % 360;
        }
        
        public double XAngle { get; private set; }
        public double YAngle { get; private set; }
        public double ZAngle { get; private set; }
    }
}
