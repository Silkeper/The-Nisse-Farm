using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private PlayerInput input;
    private PlayerStates state;

    public Vector2 directionVector;
    private float interactRadius;
    [SerializeField] private LayerMask isNPC;

    private float maxDistanceForNPCCheck = 3;

    public string[] currentNPCSpeaker;
    public string[] currentNPCDialouge;
    private void Start()
    {
        input = GetComponent<PlayerInput>();
        state = GetComponent<PlayerStates>();
    }

    private void Update()
    {
        Talk();
        directionVector = input.MoveVector.normalized;
    }

    private void Talk()
    {
        
        if(input.InteractValue)
        {
            
            RaycastHit2D hitNPC = Physics2D.Raycast(transform.position, directionVector, maxDistanceForNPCCheck, isNPC);
            if (hitNPC)
            {
                print(hitNPC.transform.gameObject.name);
                currentNPCDialouge = hitNPC.transform.gameObject.GetComponent<NPCDialougeContainer>().Dialog;
                currentNPCSpeaker = hitNPC.transform.gameObject.GetComponent<NPCDialougeContainer>().Navn;
                DialougeGetScrub.StartDialouge();
            }
            else
            {
                currentNPCDialouge = null;
                currentNPCSpeaker = null;
            }
        }
    }
}
