using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class NewDialouge : MonoBehaviour
{
    private PlayerInput input;
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private TextMeshProUGUI speakerText;
    [SerializeField] private string[] lines;
    [SerializeField] private string[] speaker;
    [SerializeField] private float textSpeed;

    private AudioSource audio;
    [SerializeField] private AudioClip sans;

    private int index;

    private void Start()
    {
        speakerText.text = speaker[index];
        input = GetComponent<PlayerInput>();
        audio = GetComponent<AudioSource>();

        textMesh.text = string.Empty;
        StartDialouge();
    }
    private void Update()
    {
        if(input.InteractValue)
        {
            if(textMesh.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textMesh.text = lines[index];
            }
        }
    }
    private void StartDialouge()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (var c in lines[index].ToCharArray())
        {
            audio.PlayOneShot(sans);
            textMesh.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textMesh.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
