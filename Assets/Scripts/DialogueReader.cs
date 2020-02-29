using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueReader : MonoBehaviour
{
    public string[] row, data;
    //This array hold all objects that are in the scene
    public ObjectDataCache[] interactables;

    // Use this for initialization
    void Start()
    {
        interactables = FindObjectsOfType<ObjectDataCache>();
        TextAsset inrctblData = Resources.Load<TextAsset>("Text Files/demoInfoSheet");

        //Split csv file into new element when enountering a new line
        row = inrctblData.text.Split(new char[] { '\n' });
        for (int i = 1; i < row.Length; i++)
        {
            //Split line into new element when encountering a comma
            data = row[i].Split(new char[] { ',' });

            //When encountering a (?) in the FIRST point, replace with blank text and add the corresponding tag
            if (data[0].Contains("(M)"))
            {
                data[0] = data[0].Replace("(M)", "");
                data[3] = "Material"; //material
            }
            if (data[0].Contains("(T)"))
            {
                data[0] = data[0].Replace("(T)", "");
                data[3] = "Tool"; //tool
            }
            if (data[0].Contains("(P)"))
            {
                data[0] = data[0].Replace("(P)", "");
                data[3] = "Puzzle"; //puzzle
            }
            if (data[0].Contains("(E)"))
            {
                data[0] = data[0].Replace("(E)", "");
                data[3] = "Environment"; //environment
            }

            //When encounterng a @ in the SECOND point, replace with a comma
            if (data[1].Contains("@"))
            {
                data[1] = data[1].Replace('@', ',');
            }

            //For each interactable in the scene, put this information in its "thisObject" field
            foreach (var interactable in interactables)
            {
                if (interactable.gameObject.name == data[0])
                {
                    interactable.thisObject.myName = data[0];
                    interactable.thisObject.myDesc = data[1];
                    interactable.thisObject.mySprite = data[2];
                    interactable.gameObject.tag = data[3];
                }
            }
        }
    }
}