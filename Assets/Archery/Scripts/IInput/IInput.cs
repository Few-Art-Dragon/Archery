using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput
{
    public delegate void PressedButtonHandler();
    public event PressedButtonHandler OnPressedButtonEvent;
    public delegate void ReleasedButtonHandler();
    public event ReleasedButtonHandler OnReleasedButtonEvent;
    public delegate void HoldingButtonHandler();
    public event HoldingButtonHandler OnHoldingButtonEvent;
}
