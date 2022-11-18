using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region enums

public enum TypeMovement
{
    None,
    MoveLeft,
    MoveRight,
    Move,
    Jump
}

#endregion enums

public class InputController : MonoBehaviour
{
    #region Inspector variables

    [SerializeField] private float modSpeed;
    [SerializeField] private float modJump;

    #endregion Inspector variables
    
    #region private variables

    private Vector2 velocity;

    #endregion private variables

    #region public functions

    public void SetVelocity(Vector2 newVelocity)
    {
        velocity = newVelocity;
    }
    
    public Vector2 GetVelocity()
    {
        return velocity;
    }

    public void SetVelocityByType(TypeMovement typeMovement)
    {
        switch (typeMovement)
        {
            case TypeMovement.MoveLeft: MoveLeft(); break;
            case TypeMovement.MoveRight: MoveRight(); break;
            case TypeMovement.Move: Move(); break;
            case TypeMovement.Jump: Jump(); break;
            default: break;
        }
    }

    #endregion public functions
    
    #region private functions

    private void MoveLeft()
    {
        velocity = Vector2.left * modSpeed * Time.deltaTime;
    }

    private void MoveRight()
    {
        velocity = Vector2.right * modSpeed * Time.deltaTime;
    }

    private void Move()
    {
        velocity *= Time.deltaTime;
    }
    
    private void Jump()
    {
        velocity = Vector2.up * modJump * Time.deltaTime;
    }

    #endregion private functions
}
