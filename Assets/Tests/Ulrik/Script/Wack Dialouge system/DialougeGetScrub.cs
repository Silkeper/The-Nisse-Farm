using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class DialougeGetScrub : ScriptableObject
{
    public string[] speaker;
    public string[] dialouge;

    public static void StartDialouge()
    {
        GameObject.Find("DialougeBox").GetComponent<NewDialouge>().dialouge = GameObject.Find("Vetle").GetComponent<PlayerInteract>().currentNPCDialouge;
        GameObject.Find("DialougeBox").GetComponent<NewDialouge>().speaker = GameObject.Find("Vetle").GetComponent<PlayerInteract>().currentNPCSpeaker;
        GameObject.Find("DialougeBox").GetComponent<NewDialouge>().soundClip = GameObject.Find("Vetle").GetComponent<PlayerInteract>().currentNPCAudio;

        GameObject.Find("DialougeBox").GetComponent<NewDialouge>().AlmostStartDialouge();

        
    }
}
