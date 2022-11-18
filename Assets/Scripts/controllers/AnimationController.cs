using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;
using Animation = UnityEngine.Animation;
using AnimationState = Spine.AnimationState;

#region enums

public enum TypeAnimation
{
    None,
    Idle,
    IdleAsEnd,
    JumpNormal,
    JumpStart,
    JumpLoop,
    AttackSword,
    AttackBow,
    Running,
    Die
}

#endregion enums

public class AnimationController : MonoBehaviour
{
    #region Inspector variable

    [SerializeField] private GameObject portalGameObject;
    [SpineAnimation] public string idleAnimationName;
    [SpineAnimation] public string jumpStartAnimationName;
    [SpineAnimation] public string jumpLoopAnimationName;
    [SpineAnimation] public string attackSwordAnimationName;
    [SpineAnimation] public string attackBowAnimationName;
    [SpineAnimation] public string runningAnimationName;
    [SpineAnimation] public string dieAnimationName;

    #endregion Inspector variable

    #region private variables
    
    private SkeletonAnimation skeletonAnimation;
    private AnimationState spineAnimationState;
    private Skeleton skeleton;

    #endregion private variables

    #region Unity functions

    private void Start()
    {
        SetVariables();
    }

    #endregion Unity functions

    #region public functions

    public void StartAnimationByType(TypeAnimation typeAnimation)
    {
        switch (typeAnimation)
        {
            case TypeAnimation.Idle : StartIdleAnimation(); break;
            case TypeAnimation.IdleAsEnd: StartIdleAfterAnimation(); break;
            case TypeAnimation.JumpNormal: StartNormalJumpAnimation(); break;
            case TypeAnimation.JumpStart: StartJumpStartAnimation(); break;
            case TypeAnimation.JumpLoop: StartJumpLoopAnimation(); break;
            case TypeAnimation.AttackSword: StartSwordAttackAnimation(); break;
            case TypeAnimation.AttackBow: StartBowAttackAnimation(); break;
            case TypeAnimation.Running: StartRunningAnimation(); break;
            case TypeAnimation.Die: StartDieAnimation(); break;
            default: break;
        }
    }

    #endregion public functions
    
    #region private functions

    private void SetVariables()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        spineAnimationState = skeletonAnimation.AnimationState;
        skeleton = skeletonAnimation.Skeleton;
    }

    private void StartIdleAnimation()
    {
        spineAnimationState.SetAnimation(0, idleAnimationName, true);
    }
    
    private void StartJumpStartAnimation()
    {
        spineAnimationState.SetAnimation(0, jumpStartAnimationName, false);
    }

    private void StartNormalJumpAnimation()
    {
        spineAnimationState.SetAnimation(0, jumpStartAnimationName, false);
        spineAnimationState.AddAnimation(0, jumpLoopAnimationName, true, 0);
    }
    
    private void StartJumpLoopAnimation()
    {
        spineAnimationState.SetAnimation(0, jumpLoopAnimationName, true);
    }
    
    private void StartSwordAttackAnimation()
    {
        spineAnimationState.SetAnimation(0, attackSwordAnimationName, false);
    }
    
    private void StartBowAttackAnimation()
    {
        spineAnimationState.SetAnimation(0, attackBowAnimationName, false);
    }
    
    private void StartRunningAnimation()
    {
        spineAnimationState.SetAnimation(0, runningAnimationName, false);
    }
    
    private void StartDieAnimation()
    {
        spineAnimationState.SetAnimation(0, dieAnimationName, false);
    }

    private void StartIdleAfterAnimation()
    {
        spineAnimationState.AddAnimation(0, idleAnimationName, false, 0); 
    }

    private void StopAllAnimation()
    {
        spineAnimationState.ClearTracks();
    }

    #endregion private functions
    
    
}
