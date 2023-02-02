using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private PlayerInput input;
    private PlayerStates state;
    private Rigidbody2D rb;

    public Vector2 directionVector;
    private float interactRadius;
    [SerializeField] private LayerMask isNPC;

    [SerializeField] private float maxDistanceForNPCCheck = 3;

    public string currentNPCSpeaker;
    public string[] currentNPCDialouge;
    public AudioClip currentNPCAudio;
    private void Start()
    {
        input = GetComponent<PlayerInput>();
        state = GetComponent<PlayerStates>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Talk();
        if(input.MoveVector != Vector2.zero)
        {

        directionVector = input.MoveVector.normalized;
        }
    }

    private void Talk()
    {
        
        if(input.InteractValue && state.playerStates == 0)
        {
            
            RaycastHit2D hitNPC = Physics2D.Raycast(transform.position, directionVector, maxDistanceForNPCCheck, isNPC);
            if (hitNPC)
            {
                print(hitNPC.transform.gameObject.name);
                currentNPCDialouge = hitNPC.transform.gameObject.GetComponent<NPCDialougeContainer>().Dialog;
                currentNPCSpeaker = hitNPC.transform.gameObject.GetComponent<NPCDialougeContainer>().Navn;
                currentNPCAudio = hitNPC.transform.gameObject.GetComponent<NPCDialougeContainer>().Lyd;
                DialougeGetScrub.StartDialouge();
                state.playerStates = 1;
                rb.velocity = Vector2.zero;
            }
            else
            {
                currentNPCDialouge = null;
                currentNPCSpeaker = null;
                currentNPCAudio = null;
}
        }
    }
}
