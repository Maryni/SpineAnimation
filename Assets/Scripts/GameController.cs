using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameController : MonoBehaviour
{
    #region private variables

    [Inject] private UIController uiController;
    [Inject] private AnimationController animationController;
    [Inject] private InputController inputController;
    [Inject] private MovementController movementController;
    
    #endregion private variables

    #region Unity functions

    private void Start()
    {
        SetActionsOnClick();
    }

    #endregion Unity functions

    #region private functions

    private void SetActionsOnClick()
    {
        SetLeftAction();
        SetRightAction();
        SetSwordAction();
        SetBowAction();
        SetJumpAction();
    }

    private void SetLeftAction()
    {
        Button left = uiController.GetButtonFromDictionary(ButtonTypeComponent.LeftMove);
        left.onClick.AddListener(() => animationController.StartAnimationByType(TypeAnimation.Running));
        left.onClick.AddListener(() => inputController.SetVelocityByType(TypeMovement.MoveLeft));
        left.onClick.AddListener(() => movementController.SetVelocityToPlayer(inputController.GetVelocity()));
        left.onClick.AddListener(() => animationController.StartAnimationByType(TypeAnimation.IdleAsEnd));
    }
    
    private void SetRightAction()
    {
        Button right = uiController.GetButtonFromDictionary(ButtonTypeComponent.RightMove);
        right.onClick.AddListener(() => animationController.StartAnimationByType(TypeAnimation.Running));
        right.onClick.AddListener(() => inputController.SetVelocityByType(TypeMovement.MoveRight));
        right.onClick.AddListener(() => movementController.SetVelocityToPlayer(inputController.GetVelocity()));
        right.onClick.AddListener(() => animationController.StartAnimationByType(TypeAnimation.IdleAsEnd));
    }
    
    private void SetSwordAction()
    {
        Button sword = uiController.GetButtonFromDictionary(ButtonTypeComponent.SwordAttack);
        sword.onClick.AddListener( () =>animationController.StartAnimationByType(TypeAnimation.AttackSword));
        sword.onClick.AddListener(() => animationController.StartAnimationByType(TypeAnimation.IdleAsEnd));
    }
    
    private void SetBowAction()
    {
        Button bow = uiController.GetButtonFromDictionary(ButtonTypeComponent.BowAttack);
        bow.onClick.AddListener( () =>animationController.StartAnimationByType(TypeAnimation.AttackBow));
    }
    
    private void SetJumpAction()
    {
        Button jump = uiController.GetButtonFromDictionary(ButtonTypeComponent.Jump);
        jump.onClick.AddListener(() => animationController.StartAnimationByType(TypeAnimation.JumpNormal));
        jump.onClick.AddListener(() => inputController.SetVelocityByType(TypeMovement.Jump));
        jump.onClick.AddListener(() => movementController.SetVelocityToPlayer(inputController.GetVelocity()));
        jump.onClick.AddListener(() => animationController.StartAnimationByType(TypeAnimation.IdleAsEnd));
    }

    #endregion private functions
    
}
