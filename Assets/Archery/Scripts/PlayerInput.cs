using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IInput
{
    private bool _pressed;
    public event IInput.PressedButtonHandler OnPressedButtonEvent;
    public event IInput.ReleasedButtonHandler OnReleasedButtonEvent;
    public event IInput.HoldingButtonHandler OnHoldingButtonEvent;

    private void CheckPressedLeftMouseButton()
    {
        if (_pressed)
        {
            OnHoldingButtonEvent?.Invoke();      
        }
    }

    private void CheckOnPressedButton()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SetStatePressed(true);
            OnPressedButtonEvent?.Invoke();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            SetStatePressed(false);
            OnReleasedButtonEvent?.Invoke();
        }
    }

    private void SetStatePressed(bool state)
    {
        _pressed = state;
    }

    private void Update()
    {
        CheckOnPressedButton();
        CheckPressedLeftMouseButton();
    }
}
