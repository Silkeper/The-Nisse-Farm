using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePointScript : MonoBehaviour
{
    private PlayerPickPlaceThrow pick;
    [SerializeField] private float PlaceRange = 30;
    // Start is called before the first frame update
    void Start()
    {
        pick = GetComponentInParent<PlayerPickPlaceThrow>();
    }

    // Update is called once per frame
    
    private void Update()
    {

        
        transform.localPosition = pick.directionVector.normalized * PlaceRange;

    }
}
