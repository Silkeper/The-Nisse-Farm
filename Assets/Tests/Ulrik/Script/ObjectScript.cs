using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    public Vector2 ObjectDirectionVector;
    public bool isObjectTrigger;
    public bool isThrown;

    private Rigidbody2D rb;

    public float ThrowSpeed;
    public float currentThrowSpeed;
    [SerializeField] private float ThrowSpeedDecay = 100;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Thrown();
    }

    private void Thrown()
    {
        if(isThrown)
        {
            rb.velocity = ObjectDirectionVector * currentThrowSpeed;
            currentThrowSpeed -= ThrowSpeedDecay;
        }
        if (currentThrowSpeed <= 0)
        {
            isThrown = false;
            rb.velocity = Vector2.zero;
        }
        
    }
}
