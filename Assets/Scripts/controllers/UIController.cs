using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region enums

public enum ButtonTypeComponent
{
    None,
    LeftMove,
    RightMove,
    Jump,
    SwordAttack,
    BowAttack
}

#endregion enums

public class UIController : MonoBehaviour
{
    #region Inspector variables

    [SerializeField] private Button leftMovingButton;
    [SerializeField] private Button rightMovingButton;
    [SerializeField] private Button jumpButton;
    [SerializeField] private Button swordAttackButton;
    [SerializeField] private Button bowAttackButton;
    [SerializeField, Space] private GameObject buttonsGameObject;
    [SerializeField] private GameObject circleGameObject;

    #endregion Inspector variables
    
    #region private variables

    private Dictionary<ButtonTypeComponent, Button> dictionaryButton = new Dictionary<ButtonTypeComponent, Button>();

    #endregion private variables

    #region Unity functions

    private void Awake()
    {
        SetDictionaryValues();
    }

    #endregion Unity functions

    #region public functions

    public Button GetButtonFromDictionary(ButtonTypeComponent buttonTypeComponent)
    {
        return dictionaryButton[buttonTypeComponent];
    }

    public void ChangeUIVisible()
    {
        buttonsGameObject.SetActive(!buttonsGameObject.activeSelf);
        circleGameObject.SetActive(!buttonsGameObject.activeSelf);
    }

    #endregion public functions
    
    #region private functions

    private void SetDictionaryValues()
    {
        dictionaryButton.Add(ButtonTypeComponent.LeftMove, leftMovingButton);
        dictionaryButton.Add(ButtonTypeComponent.RightMove, rightMovingButton);
        dictionaryButton.Add(ButtonTypeComponent.SwordAttack, swordAttackButton);
        dictionaryButton.Add(ButtonTypeComponent.BowAttack, bowAttackButton);
        dictionaryButton.Add(ButtonTypeComponent.Jump, jumpButton);
    }

    #endregion private functions
    
    
}
