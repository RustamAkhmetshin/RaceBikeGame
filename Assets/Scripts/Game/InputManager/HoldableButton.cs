using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class HoldableButton : Button, IPointerDownHandler,IPointerUpHandler
    {
        public Action<bool> OnPressed;
    
        public override void OnPointerDown(PointerEventData eventData)
        {
            OnPressed?.Invoke(true);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            OnPressed?.Invoke(false);
        }
    }
}