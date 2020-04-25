using System;
using VrVektoren.Utilities;

namespace VrVektoren.Core
{
    public class Step
    {
        private readonly Tuple<Vector, VectorPosition>[] vectorChanges;
        private readonly Tuple<Angle, bool>[] angleChanges;

        public Step(
            Tuple<Vector, VectorPosition>[] vectorChanges,
            Tuple<Angle, bool>[] angleChanges)
        {
            Guard.IsNotNull(vectorChanges);
            Guard.IsNotNull(angleChanges);

            this.vectorChanges = vectorChanges;
            this.angleChanges = angleChanges;
        }
        
        public void Activate()
        {
            foreach (var vectorChange in this.vectorChanges)
            {
                vectorChange.Item1.Position = vectorChange.Item2;
            }

            foreach (var angleChange in this.angleChanges)
            {
                angleChange.Item1.IsVisible = angleChange.Item2;
            }
        }
    }
}
