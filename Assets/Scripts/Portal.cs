using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    #region private variables

    private event Action OnPortalClose;
    private Coroutine portalCoroutine;

    #endregion private variables

    #region public functions

    public void ClosePortal()
    {
        portalCoroutine = StartCoroutine(DisablePortal());
    }
    
    public void AddActionToOnPortalClose(params Action[] actions)
    {
        foreach (var action in actions)
        {
            OnPortalClose += action;
        }
    }
    
    #endregion public functions

    #region private functions

    private IEnumerator DisablePortal()
    {
        float time = GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).Length;
        yield return new WaitForSeconds(time);
        StopCoroutine(portalCoroutine);
        portalCoroutine = null;
        gameObject.SetActive(false);
        OnPortalClose();
    }

    #endregion private functions
}
