using System;
using UnityEngine;
using VrVektoren.Utilities;

namespace VrVektoren.Core
{
    public class Vector
    {
        private VectorPosition position;

        public Vector(Color color, bool hasHead = true)
        {
            Guard.IsNotNull(color);

            this.Color = color;
            this.HasHead = hasHead;

            this.position = new VectorPosition(
                false,
                new Point(0, 0, 0),
                new EulerAngle(0, 0, 0),
                0);
        }

        public bool HasHead { get; private set; }
        public Color Color { get; private set; }
        public VectorPosition Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
                this.PositionChanged?.Invoke(this, new EventArgs());
            }
        }

        public event EventHandler PositionChanged;
    }
}
