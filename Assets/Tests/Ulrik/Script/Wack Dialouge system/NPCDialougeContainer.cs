using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialougeContainer : MonoBehaviour
{
    public string[] Navn;
    public string[] Dialog;
    public AudioClip Lyd;

    //Dialog systemet vil fungere slik:
    //Player Interact scriptet henter strings ifra dette scriptet, gir det over til Scruben imens den aktiverer en funskjon på Scruben
    //Som skal aktivere dialog systemet på canvaset og endre stringene dens til de som scruben hentet ifra dette scriptet
}
