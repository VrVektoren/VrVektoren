using System;
using UnityEngine;
using VrVektoren.Utilities;

namespace VrVektoren.Core
{
    public class Angle
    {
        private bool isVisible;

        public Angle(
            Vector vector1,
            Vector vector2,
            bool isReflexAngle,
            double radius,
            Color color,
            bool isVisible)
        {
            Guard.IsNotNull(vector1);
            Guard.IsNotNull(vector2);
            Guard.IsNotNull(color);

            this.Vector1 = vector1;
            this.Vector2 = vector2;
            this.IsReflexAngle = isReflexAngle;
            this.Radius = radius;
            this.Color = color;
            this.isVisible = isVisible;
        }

        public Vector Vector1 { get; private set; }
        public Vector Vector2 { get; private set; }        
        public bool IsReflexAngle { get; private set; }
        public double Radius { get; private set; }
        public Color Color { get; private set; }
        public bool IsVisible
        {
            get
            {
                return this.isVisible;
            }
            set
            {
                this.isVisible = value;
                IsVisibleChanged?.Invoke(this, new EventArgs());
            }
        }

        public event EventHandler IsVisibleChanged;
    }
}
