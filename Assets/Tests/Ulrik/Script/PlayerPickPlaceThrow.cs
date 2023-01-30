using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerPickPlaceThrow : MonoBehaviour
{
    private PlayerInput input;
    private PlacePointScript placePointScript;

    private float currentThrowSpeed;
    private float startThrowSpeed;
    private float throwspeedDecay;

    private float maxDistanceForObjectCeck = 3;
    [SerializeField] private float PlaceRange = 30;

    private int itemHoldstate;

    public Vector2 directionVector;

    [SerializeField] private Transform placePoint;
    [SerializeField] private LayerMask isObject;
    private GameObject currentObject;
    [SerializeField] private Transform itemHoldPosition;
    private void Start()
    {
        itemHoldstate = 1;
        input = GetComponent<PlayerInput>();
        placePointScript = GetComponentInChildren<PlacePointScript>();
    }
    private void Update()
    {
        PickUp();
        HoldState();
        DirectionSave();
    }

    private void HoldState()
    {
        switch(itemHoldstate)
        {
            case 1:
                PickUp();
                placePoint.GetComponent<SpriteRenderer>().enabled = false;
                if(currentObject)
                {
                    itemHoldstate = 2;
                }
                break;
                case 2:
                if (currentObject)
                {
                    placePoint.GetComponent<SpriteRenderer>().enabled = true;
                    currentObject.GetComponent<Collider2D>().isTrigger = true;
                    currentObject.transform.position = itemHoldPosition.position;
                    PlacePointRotation();
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
            
            RaycastHit2D hitObject = Physics2D.Raycast(transform.position, directionVector, maxDistanceForObjectCeck, isObject);
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
            //placePointScript.PlacePositionDirectionSetter();
            currentObject.transform.position = placePoint.position;
            currentObject = null;
        }
    }

    private void DirectionSave()
    {
        if(input.MoveVector != Vector2.zero)
        {
            directionVector = input.MoveVector;
        }
    }
    public static float GetAngleFromVectorXZ(Vector3 direction)
    {
        direction = direction.normalized;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
        if (angle < 0) angle += 360;

        return angle;
    }

    private void PlacePointRotation()
    {
        placePoint.transform.localPosition = directionVector.normalized * PlaceRange;
    }
}
