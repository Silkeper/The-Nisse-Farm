using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerPickPlaceThrow : MonoBehaviour
{
    private PlayerInput input;

    private float currentThrowSpeed;
    private float startThrowSpeed;
    private float throwspeedDecay;

    private float maxDistanceForObjectCeck = 3;

    private int itemHoldstate;

    [SerializeField] private LayerMask isObject;
    private GameObject currentObject;
    [SerializeField] private Transform itemHoldPosition;
    private void Start()
    {
        itemHoldstate = 1;
        input = GetComponent<PlayerInput>();
    }
    private void Update()
    {
        PickUp();
        HoldState();
    }

    private void HoldState()
    {
        switch(itemHoldstate)
        {
            case 1:
                PickUp();
                if(currentObject)
                {
                    itemHoldstate = 2;
                }
                break;
                case 2:
                if (currentObject)
                {
                    currentObject.GetComponent<Collider2D>().isTrigger = true;
                    currentObject.transform.position = itemHoldPosition.position;
                }
                if(!currentObject)
                {
                    itemHoldstate = 1;
                }
                Place();
                break;
        }
    }
    private void PickUp()
    {
        if(input.PlaceValue || input.ThrowValue && !currentObject)
        {

            Debug.DrawRay(transform.position, transform.up);
            
            RaycastHit2D hitObject = Physics2D.Raycast(transform.position, transform.up, maxDistanceForObjectCeck, isObject);
            {
                print(hitObject.transform.gameObject.name);
                currentObject = hitObject.transform.gameObject;
                
            }
        } 
    }
    private void Place()
    {
        if (input.PlaceValue || input.ThrowValue && currentObject)
        {
            currentObject = null;
        }
    }
}
