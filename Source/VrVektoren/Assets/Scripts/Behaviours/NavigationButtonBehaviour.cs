using UnityEngine;

namespace VrVektoren.Behaviours
{
    public class NavigationButtonBehaviour : BaseButtonBehaviour
    {
        public TextMesh TextMesh;
        public GameObject Button;

        protected string text;

        protected override void Start()
        {
            this.objectWithRenderer = Button;

            base.Start();

            if (this.text == null)
            {
                this.text = "Button";
            }

            this.TextMesh.text = text;

            var size = this.TextMesh.GetComponent<Renderer>().bounds.size;
            var buttonScale = this.Button.transform.localScale;
            buttonScale.x = buttonScale.y * ( size.x + 0.33f ) / (size.y * 1.2f);
            this.Button.transform.localScale = buttonScale;
        }
    }
}
