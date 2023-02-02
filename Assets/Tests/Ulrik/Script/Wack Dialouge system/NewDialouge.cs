using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using System.Xml.Serialization;

public class NewDialouge : MonoBehaviour
{
    private PlayerInput input;
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private TextMeshProUGUI speakerText;
    [HideInInspector] public string[] dialouge;
    [HideInInspector] public string[] speaker;
    [SerializeField] private float textSpeed;

    private AudioSource audio;
    [HideInInspector] public AudioClip soundClip;

    private Vector3 activeposition;
    private Vector3 notActivePosition;

    private RectTransform transform;

    private int index;

    private void Start()
    {
        transform = GetComponent<RectTransform>();
        activeposition = new Vector3(0, 0, 0);
        notActivePosition = new Vector3(0, 0, 0);
        speakerText.text = speaker[index];
        input = GetComponent<PlayerInput>();
        audio = GetComponent<AudioSource>();

        textMesh.text = string.Empty;
        transform.localScale = new Vector3(0, 0, 0);
    }
    private void OnEnable()
    {
        speakerText.text = speaker[index];
        input = GetComponent<PlayerInput>();
        audio = GetComponent<AudioSource>();

        textMesh.text = string.Empty;
    }
    private void Update()
    {
        if(input.InteractValue)
        {
            if(textMesh.text == dialouge[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textMesh.text = dialouge[index];
                
            }
        }
    }
    public void AlmostStartDialouge()
    {
        StartDialouge();
    }
    public void StartDialouge()
    {
        audio.PlayOneShot(soundClip);
        transform.localScale =  new Vector3(2.4125f, 1, 1);
        index = 0;
        StartCoroutine(TypeLine());
        print(dialouge);
        print(speaker);
    }

    IEnumerator TypeLine()
    {
        foreach (var c in dialouge[index].ToCharArray())
        {
            
            textMesh.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < dialouge.Length - 1)
        {
            audio.PlayOneShot(soundClip);
            index++;
            textMesh.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            transform.localScale = new Vector3(0, 0, 0);
            GameObject.Find("Vetle").GetComponent<PlayerStates>().playerStates = 0;
        }
    }
}
