using VrVektoren.Services;

namespace VrVektoren.Behaviours
{
    public class SceneSelectionNavigationButtonBehaviour : NavigationButtonBehaviour
    {
        protected override void Start()
        {
            this.text = "Übersicht";

            base.Start();
        }

        protected override void Trigger()
        {
            SceneService.OpenSceneSelection();
        }
    }
}
