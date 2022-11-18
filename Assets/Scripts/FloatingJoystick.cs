using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingJoystick : MonoBehaviour
{
    [SerializeField] private RectTransform knobGameObject;
    private RectTransform rectTransform;

    public RectTransform RectTransform => rectTransform;
    public RectTransform Knob => knobGameObject;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
}
