using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private Playerinputactions inputActions;

    public Vector2 MoveVector;
    public bool ThrowValue;
    public bool PlaceValue;
    public bool InteractValue;
    private void Awake() 
    {
        inputActions = new Playerinputactions(); 
    }

    private void Update()
    {
        MoveVector = inputActions.Player.Move.ReadValue<Vector2>();

        ThrowValue = inputActions.Player.PickUpThrow.triggered;
        PlaceValue = inputActions.Player.PickUpPlace.triggered;
        InteractValue = inputActions.Player.Interact.triggered;
    }
    private void OnEnable() { inputActions.Enable(); }
    private void OnDisable() { inputActions.Disable(); } 
}
