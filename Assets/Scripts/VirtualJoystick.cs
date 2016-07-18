using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

namespace Assets.Scripts
{
    public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        public Vector3 InputDirection { get; set; }

        [Tooltip("Its only view parameter which determines offset relatively real clicked for joystick position on x-axis")]
        [SerializeField]
        int xJoystickOffsetSmoothing = 3;
        [Tooltip("Its only view parameter which determines offset relatively real clicked for joystick position on y-axis")]
        [SerializeField]
        int yJoystickOffsetSmoothing = 3;
        Image background;
        Image joystick;

        void Start()
        {
            background = GetComponent<Image>();
            joystick = transform.GetChild(0).GetComponent<Image>();
            InputDirection = Vector3.zero;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 position = Vector2.zero;
            if(RectTransformUtility.ScreenPointToLocalPointInRectangle(
                background.rectTransform, eventData.position, 
                eventData.pressEventCamera, out position))
            {
                position.x = (position.x / background.rectTransform.sizeDelta.x);
                position.y = (position.y / background.rectTransform.sizeDelta.y);
                float x = (background.rectTransform.pivot.x == 1) ? (position.x * 2 + 1) : (position.x * 2 - 1);
                float y = (background.rectTransform.pivot.y == 1) ? (position.y * 2 + 1) : (position.y * 2 - 1);
                InputDirection = new Vector3(x, 0, y);
                InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;
                joystick.rectTransform.anchoredPosition = new Vector3(
                    InputDirection.x * (background.rectTransform.sizeDelta.x / xJoystickOffsetSmoothing),
                    InputDirection.z * (background.rectTransform.sizeDelta.y / yJoystickOffsetSmoothing));
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            InputDirection = Vector3.zero;
            joystick.rectTransform.anchoredPosition = Vector3.zero;
        }
    }
}
