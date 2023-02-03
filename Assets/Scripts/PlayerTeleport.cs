using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Port"))
        {
            transform.position = collision.gameObject.GetComponent<PortConnector>().portalPoint.position;
        }
    }
}
