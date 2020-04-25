using UnityEngine;
using UnityEngine.EventSystems;
using VrVektoren.Utilities;

namespace VrVektoren.Behaviours
{
    public abstract class BaseButtonBehaviour: 
        MonoBehaviour, 
        IPointerEnterHandler, 
        IPointerExitHandler, 
        IPointerDownHandler, 
        IPointerUpHandler,
        IPointerClickHandler
    {
        protected Color standardColor;
        protected Color focusColor;

        protected GameObject objectWithRenderer;

        private bool isPointerDown;

        protected virtual void Start()
        {
            if (objectWithRenderer == null)
            {
                objectWithRenderer = this.gameObject;
            }

            this.standardColor = GameObjectColorHelper.GetGameObjectColor(this.objectWithRenderer);
            this.focusColor = this.standardColor * 0.5f;
        }

        protected virtual void Update()
        {
            if (this.isPointerDown)
            {
                this.WhileTriggering();
            }
        }

        protected virtual void Focus()
        {
            GameObjectColorHelper.SetGameObjectColor(this.objectWithRenderer, this.focusColor);
        }

        protected virtual void Unfocus()
        {
            GameObjectColorHelper.SetGameObjectColor(this.objectWithRenderer, this.standardColor);
        }

        protected virtual void Trigger()
        {

        }

        protected virtual void WhileTriggering()
        {

        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            this.isPointerDown = eventData.clickCount > 0;
            this.Focus();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            this.isPointerDown = false;
            this.Unfocus();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            this.isPointerDown = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            this.isPointerDown = false;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            this.Trigger();
        }
    }
}
