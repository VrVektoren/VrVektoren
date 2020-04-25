namespace VrVektoren.Behaviours
{
    public class RotationArrowBehaviour : BaseButtonBehaviour
    {
        //Attributes for editor
        public RotationDirection RotationDirection = RotationDirection.Clockwise;
        public TurnTableBehaviour TurnTableBehaviour;

        protected override void Update()
        {
            base.Update();
        }
                
        protected override void WhileTriggering()
        {
            var angle = 1f;

            if (this.RotationDirection == RotationDirection.CounterClockwise)
            {
                angle = -angle;
            }

            this.TurnTableBehaviour.Rotate(angle);
        }
    }
}
