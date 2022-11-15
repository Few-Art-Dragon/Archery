using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [SerializeField]
    private Arrow[] _arrowsPool;
    [SerializeField]
    private float _arrowSpeed;
    [SerializeField]
    private Transform _ropeTransform;
    [SerializeField]
    private Vector3 _ropeFarLocalPosition;
    private Vector3 _ropeNearLocalPosition;
    private float _tension;

    private int _arrowIndex=0;
    private Arrow _currentArrow;

    [SerializeField]
    PlayerInput input;

    private void AddTension()
    {
        if (_tension < 1f)
        {
            _tension += Time.deltaTime;
        }
        _ropeTransform.localPosition = Vector3.Lerp(_ropeNearLocalPosition, _ropeFarLocalPosition, _tension);
    }

    private void SetCurentArrow()
    {
        _currentArrow = CheckOnFreeArrow();
        _currentArrow.SetDefaultTransform(_ropeTransform);
    }

    private void PushCurrentArrow()
    {
        _currentArrow.Shot(_arrowSpeed * _tension);
        SetZeroOnTension();
    }

    private void SetZeroOnTension()
    {
        _tension = 0;
    }

    private Arrow CheckOnFreeArrow()
    {
        Arrow currentArrow = null;
        CheckArrowIndexOnMaxArrowIndex();
        for (int i = _arrowIndex; i<_arrowsPool.Length; i++)
        {
            if (!_arrowsPool[i].IsFlying)
            {
                _arrowIndex++;
                currentArrow = _arrowsPool[i];
                break;
            }
        }
        return currentArrow? currentArrow : CheckOnFreeArrow();
    }

    private void CheckArrowIndexOnMaxArrowIndex()
    {
        if (_arrowIndex >= _arrowsPool.Length)
        {
            _arrowIndex = 0;
        }
    }

    private void OnEnable()
    {
        input.OnPressedButtonEvent += SetCurentArrow;
        input.OnReleasedButtonEvent += PushCurrentArrow;
        input.OnHoldingButtonEvent += AddTension;
    }

    private void Start ()
    {
        _ropeNearLocalPosition = _ropeTransform.localPosition;
    }

    private void OnDisable()
    {
        input.OnPressedButtonEvent -= SetCurentArrow;
        input.OnReleasedButtonEvent -= PushCurrentArrow;
        input.OnHoldingButtonEvent -= AddTension;
    }
}
