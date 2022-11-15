using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float _xRotation;
    private float _yRotation;
    private float _mouseX;
    private float _mouseY;
    [SerializeField]
    private float _sensitiveX;
    [SerializeField]
    private float _sensitiveY;

    private void SetLockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void SetVisibleCursor(bool state)
    {
        Cursor.visible = state;
    }

    private void GetMousePosition()
    {
        _mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _sensitiveX;
        _mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _sensitiveY;
    }

    private void CalcaluteXRotation()
    {
        _xRotation -= _mouseY;
        SetLockDegreesOnXRotation();
    }

    private void CalculateYRotation()
    {
        _yRotation += _mouseX;
    }

    private void UpdateCameraRotation()
    {
        transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
    }

    private void SetLockDegreesOnXRotation()
    {
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90);
    }

    private void Start()
    {
        SetLockCursor();
        SetVisibleCursor(false);   
    }

    private void Update()
    {
        GetMousePosition();
        CalculateYRotation();
        CalcaluteXRotation();
        UpdateCameraRotation();
    }
}
