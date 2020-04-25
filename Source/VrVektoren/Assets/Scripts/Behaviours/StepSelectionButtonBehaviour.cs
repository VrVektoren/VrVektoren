namespace VrVektoren.Behaviours
{
    public class StepSelectionButtonBehaviour : BaseButtonBehaviour
    {
        public StepSelectionBehaviour StepSelectionBehaviour;
        public bool GotoPreviousStep;

        protected override void Trigger()
        {
            if (this.GotoPreviousStep)
            {
                this.StepSelectionBehaviour.GotoPreviousStep();
            }
            else
            {
                this.StepSelectionBehaviour.GotoNextStep();
            }
        }
    }
}
