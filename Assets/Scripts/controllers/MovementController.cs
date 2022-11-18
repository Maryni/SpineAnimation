using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    #region Inspector variables 

    [SerializeField] private GameObject playerGameObject;

    #endregion Inspector variables

    #region public functions

    public void SetVelocityToPlayer(Vector2 velocity)
    { 
        CheckPlayerAndChangeRotation(velocity);
        var rig2D = playerGameObject.GetComponent<Rigidbody2D>();
        rig2D.velocity = Vector2.zero;
        rig2D.AddForce(velocity, ForceMode2D.Force);
    }
    

    #endregion public functions

    #region private functions

    private void CheckPlayerAndChangeRotation(Vector2 velocity)
    {
        if (velocity.x < 0)
        {
            playerGameObject.transform.rotation = Quaternion.Euler(0f,180f,0f);  
        }
        else if( velocity.x > 0)
        {
            playerGameObject.transform.rotation = Quaternion.Euler(0f,0f,0f);   
        }
    }

    #endregion private functions
}
