using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    private PlayerMovement move;

    public int playerStates;

    private void Start()
    {
        move = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        StateFunction();
    }

    private void StateFunction()
    {
        switch(playerStates)
        {
            case 0:

                break;

            case 1:
                break;
        }
    }
}
