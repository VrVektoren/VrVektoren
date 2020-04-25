using System.Linq;
using VrVektoren.Core;
using VrVektoren.Services;

namespace VrVektoren.Behaviours
{
    class VisualizationNavigationButtonBehaviour : NavigationButtonBehaviour
    {
        public int VisualizationId = 0;
        private Vizualization visualization;

        protected override void Start()
        {
            this.visualization = VisualizationService.GetVisualizations().Single(p => p.Id == VisualizationId);
            this.text = this.visualization.Name;

            base.Start();
        }

        protected override void Trigger()
        {
            SceneService.OpenVectorVisualizer(visualization.Id);
        }
    }
}
