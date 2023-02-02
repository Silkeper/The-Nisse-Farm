using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMovement : MonoBehaviour
{ 
    private PlayerInput input;
    private PlayerStates state;
 [Tooltip("The acceleration and max moveSpeed of the player character")]
        [SerializeField] private float moveSpeed = 7f;
private float _movementMultiplier = 10f; // a multiplier to the moveSpeed in order to keep the numbers relatively low and manageable
[Tooltip("An array of the clones rigidbodies, it has to be in the same order as the clone list from split. Otherwise it will not work properly")]
private Rigidbody2D rb;
[Tooltip("The amount of slowdown on the player. Contributes to how quickly the player stops moving after you stop pressing the direction")]
[SerializeField] private float drag = 15f;

    private void Start()
    {
        input = GetComponent<PlayerInput>();
        state = GetComponent<PlayerStates>();

        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
{
        if(state.playerStates == 0)
        {
            MoveMain();
            Drag(); // in fixed update to keep it moving at the same speed as the physicsSteps
        }
    
}
private void Drag()
{

    { // Gets the velocity of every single clone, checks if they are active, and applies less drag to dead clones
        Vector2 velocity = transform.InverseTransformDirection(rb.velocity);
        float forceX;
        float forceY;

        forceX = -drag * velocity.x;
        forceY = -drag * velocity.y;
        rb.AddRelativeForce(new Vector2(forceX, forceY)); // adds "negative force" to the player, as to work as drag
    }
}
// Called from PlayerController, The act of adding force in the direction gotten from the actionMap
public void MoveMain()
{
    rb.AddForce(input.MoveVector.normalized * (moveSpeed * _movementMultiplier), ForceMode2D.Force);
}
    
}
