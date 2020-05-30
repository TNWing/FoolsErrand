using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueText : MonoBehaviour
{
    public TextAsset DialogueFile;
    public string[] DialogueLines;

    void Start()
    {
        if (DialogueFile != null)
        {
            DialogueLines = (DialogueFile.text.Split('\n'));
        }
    }
}
