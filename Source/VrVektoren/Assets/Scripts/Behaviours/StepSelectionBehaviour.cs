using UnityEngine;
using UnityEngine.UI;
using VrVektoren.Core;
using VrVektoren.Services;

namespace VrVektoren.Behaviours
{
    public class StepSelectionBehaviour : MonoBehaviour
    {
        public TextMesh TextMesh;

        private Vizualization visualization;

        void Start()
        {
            this.visualization = SceneService.VectorVisualizer.Vizualization;
            this.SetDisplay();
        }

        void Update()
        {
        }
        
        public void GotoNextStep()
        {
            this.visualization.GotoNextStep();
            this.SetDisplay();
        }

        public void GotoPreviousStep()
        {
            this.visualization.GotoPreviousStep();
            this.SetDisplay();
        }

        private void SetDisplay()
        {
            this.TextMesh.text = $"{this.visualization.CurrentStepNumber}/{this.visualization.StepCount}";
        }
    }
}
