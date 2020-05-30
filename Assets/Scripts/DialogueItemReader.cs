using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueItemReader : MonoBehaviour
{
    public ObjectDataCache[] interactables;
    public TextAsset materialData, toolData, puzzleData, environmentData;
    //TextAsset toolData = Resources.Load<TextAsset>("Text Files/demoInfoSheet");

    void Update()
    {
        interactables = FindObjectsOfType<ObjectDataCache>();
        AssignMaterialData();
        AssignToolData();
        AssignPuzzleData();
        AssignEnvironmentData();
    }

    void AssignMaterialData()
    {
        string[] row;
        string[] data = new string[4];
        row = materialData.text.Split(new char[] { '\n' });
        for (int i = 1; i < row.Length; i++)
        {
            data = row[i].Split(new char[] { ',' });
            data[3] = "Material";
            if (data[1].Contains("@"))
            {
                data[1] = data[1].Replace('@', ',');
            }
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

    void AssignToolData()
    {
        string[] row;
        string[] data = new string[4];
        row = toolData.text.Split(new char[] { '\n' });
        for (int i = 1; i < row.Length; i++)
        {
            data = row[i].Split(new char[] { ',' });
            data[3] = "Tool";
            if (data[1].Contains("@"))
            {
                data[1] = data[1].Replace('@', ',');
            }
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

    void AssignPuzzleData()
    {
        string[] row;
        string[] data = new string[4];
        row = puzzleData.text.Split(new char[] { '\n' });
        for (int i = 1; i < row.Length; i++)
        {
            data = row[i].Split(new char[] { ',' });
            data[3] = "Tool";
            if (data[1].Contains("@"))
            {
                data[1] = data[1].Replace('@', ',');
            }
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

    void AssignEnvironmentData()
    {
        string[] row;
        string[] data = new string[4];
        row = environmentData.text.Split(new char[] { '\n' });
        for (int i = 1; i < row.Length; i++)
        {
            data = row[i].Split(new char[] { ',' });
            data[3] = "Tool";
            if (data[1].Contains("@"))
            {
                data[1] = data[1].Replace('@', ',');
            }
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