using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Inspector variables

    [SerializeField] private GameObject playerGameObject;

    #endregion Inspector variables

    #region public functions

    public void ShowPlayer()
    {
        playerGameObject.SetActive(true);
    }

    public void HidePlayer()
    {
        playerGameObject.SetActive(false);
    }

    #endregion public functions
}
