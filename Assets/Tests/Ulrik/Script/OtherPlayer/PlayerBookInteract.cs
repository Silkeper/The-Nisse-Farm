using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBookInteract : MonoBehaviour
{
    PlayerInput input;
    PlayerStates state;

    private Rigidbody2D rb;

    private Vector2 directionVector;
    [SerializeField] private LayerMask isBook;
    private float maxDistanceForBookCheck = 1.8f;

    [SerializeField] private GameObject book;

    private int currentPage;

    [SerializeField] private Sprite Page1;
    [SerializeField] private Sprite Page2;

    private void Start()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        currentPage = 0;
        state = GetComponent<PlayerStates>();
    }
    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Book"))
        {

            if (input.InteractValue && book.GetComponent<SpriteRenderer>().enabled == false)
            {
                book.GetComponent<SpriteRenderer>().enabled = true;
                book.GetComponent<SpriteRenderer>().sprite = Page1;
                currentPage = 1;
            }
            if (input.InteractValue && book.GetComponent<SpriteRenderer>().enabled == true && currentPage == 1)
            {
                book.GetComponent<SpriteRenderer>().sprite = Page1;
                currentPage = 2;
            }
            if (input.InteractValue && book.GetComponent<SpriteRenderer>().enabled == true && currentPage == 2)
            {
                book.GetComponent<SpriteRenderer>().enabled = false;
                currentPage = 0;
            }

        }
    }
    */

    private void Update()
    {
        BookInteract();
        if(input.MoveVector != Vector2.zero)
        {
            directionVector = input.MoveVector.normalized;
        }
    }

    private void BookInteract()
    {
        if (input.InteractValue && state.playerStates == 0)
        {

            RaycastHit2D hitBook = Physics2D.Raycast(transform.position, directionVector, maxDistanceForBookCheck, isBook);
            if (hitBook)
            {
                if (input.InteractValue && book.GetComponent<SpriteRenderer>().enabled == false)
                {
                    book.GetComponent<SpriteRenderer>().enabled = true;
                    book.GetComponent<SpriteRenderer>().sprite = Page1;
                    currentPage = 1;
                    state.playerStates = 1;
                    rb.velocity = Vector2.zero;
                }
            }
        }
        if (input.InteractValue && book.GetComponent<SpriteRenderer>().enabled == true && currentPage == 1)
        {
            book.GetComponent<SpriteRenderer>().sprite = Page1;
            currentPage = 2;
        }
        if (input.InteractValue && book.GetComponent<SpriteRenderer>().enabled == true && currentPage == 2)
        {
            book.GetComponent<SpriteRenderer>().enabled = false;
            currentPage = 0;
            state.playerStates = 0;
        }
        else
        {
            
        }
    }
}
