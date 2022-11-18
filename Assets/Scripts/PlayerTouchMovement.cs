using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

public class PlayerTouchMovement : MonoBehaviour
{
    #region Inspector variables

    [SerializeField] private Vector2 joystickSize = new Vector2(200f,200f);
    [SerializeField] private FloatingJoystick floatingJoystick;

    #endregion Inspector variables

    #region private variables

    private Finger movementFinger;
    private Vector2 movementAmount;
    private event Action OnFingerMove;

    #endregion private variables

    #region properties

    public Vector2 MovementAmount => movementAmount;

    #endregion properties
    
    #region Unity functions

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        ETouch.Touch.onFingerDown += HandleFingerDown;
        ETouch.Touch.onFingerMove += HandleFingerMove;
        ETouch.Touch.onFingerUp += HandleLoseFinger;
    }

    private void OnDisable()
    {
        ETouch.Touch.onFingerUp += HandleLoseFinger;
        ETouch.Touch.onFingerMove += HandleFingerMove;
        ETouch.Touch.onFingerDown += HandleFingerDown;
        EnhancedTouchSupport.Disable();
    }

    #endregion Unity functions

    #region public functions

    public void AddActionToOnFingerMove(params Action[] actions)
    {
        foreach (var action in actions)
        {
            OnFingerMove += action;
        }
    }

    #endregion public functions

    #region private functions

    private void HandleFingerMove(Finger movedFinger)
    {
        if (movedFinger == movementFinger)
        {
            Vector2 knobPosition;
            float maxMovement = joystickSize.x / 2f;
            ETouch.Touch currentTouch = movedFinger.currentTouch;

            if (Vector2.Distance(
                    currentTouch.screenPosition,
                    floatingJoystick.RectTransform.anchoredPosition)
                > maxMovement)
            {
                knobPosition = (currentTouch.screenPosition - floatingJoystick.RectTransform.anchoredPosition).normalized * maxMovement;
            }
            else
            {
                knobPosition = currentTouch.screenPosition - floatingJoystick.RectTransform.anchoredPosition;
            }

            floatingJoystick.Knob.anchoredPosition = knobPosition;
            movementAmount = knobPosition / maxMovement;
            movementAmount.y = 0; //hard stop

            OnFingerMove();
        }
    }

    private void HandleLoseFinger(Finger lostFinger)
    {
        if (lostFinger == movementFinger)
        {
            movementFinger = null;
            floatingJoystick.Knob.anchoredPosition = Vector2.zero;
            floatingJoystick.gameObject.SetActive(false);
            movementAmount = Vector2.zero;
        }
    }

    private void HandleFingerDown(Finger touchFinger)
    {
        if (movementFinger == null && touchFinger.screenPosition.x <= Screen.width / 2f)
        {
            movementFinger = touchFinger;
            movementAmount = Vector2.zero;
            floatingJoystick.gameObject.SetActive(true);
            floatingJoystick.RectTransform.sizeDelta = joystickSize;
            floatingJoystick.RectTransform.anchoredPosition = ClampStartPosition(touchFinger.screenPosition);
        }
    }

    private Vector2 ClampStartPosition(Vector2 startPosition)
    {
        if (startPosition.x < joystickSize.x / 2)
        {
            startPosition.x = joystickSize.x / 2;
        }
        
        if (startPosition.y < joystickSize.y / 2)
        {
            startPosition.y = joystickSize.y / 2;
        }
        else if (startPosition.y > Screen.height - joystickSize.y / 2)
        {
            startPosition.y = Screen.height - joystickSize.y / 2;
        }

        return startPosition;
    }

    #endregion private functions


    
}
