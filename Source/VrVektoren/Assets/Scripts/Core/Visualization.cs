using VrVektoren.Utilities;

namespace VrVektoren.Core
{
    public class Vizualization
    {
        private readonly Step[] steps;

        public Vizualization(
            int id,
            string name,
            Vector[] vectors,
            Step[] steps)
        {
            Guard.IsNotNull(name);
            Guard.IsNotNull(vectors);
            Guard.IsNotNull(steps);
            
            this.Id = id;
            this.Name = name;
            this.Vectors = vectors;
            this.steps = steps;
            this.CurrentStepNumber = 1;
            this.Activate();
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public Vector[] Vectors { get; private set; }
        public int CurrentStepNumber { get; private set; }
        
        public int StepCount
        { 
            get
            {
                return this.steps.Length;
            }
        }
        
        public bool IsAtFirstStep
        {
            get
            {
                return this.CurrentStepNumber <= 1;
            }
        }

        public bool IsAtLastStep
        {
            get
            {
                return this.CurrentStepNumber >= this.StepCount;
            }
        }

        public void GotoFirstStep()
        {
            this.GotoStep(1);
        }

        public void GotoNextStep()
        {
            this.GotoStep(this.CurrentStepNumber + 1);
        }

        public void GotoPreviousStep()
        {
            this.GotoStep(this.CurrentStepNumber - 1);
        }

        private void GotoStep(int stepNumber)
        {
            if (stepNumber > 0 && stepNumber <= this.StepCount)
            {
                this.CurrentStepNumber = stepNumber;
                this.Activate();
            }
        }

        private void Activate()
        {
            this.steps[this.CurrentStepNumber - 1].Activate();
        }
    }
}
