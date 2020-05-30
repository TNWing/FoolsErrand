using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasBatTutorial : MonoBehaviour {

	public GameObject[] items;
	public GameObject[] newitems;
	public bool HasBat;
	public ActivateDialogueAtLine closet;
	public GameObject TutorialPart2;

	// Use this for initialization
	void Start () 
	{
		closet = GameObject.Find("Closet (Tutorial)").GetComponent<ActivateDialogueAtLine>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (HasBat)
		{
			for (int i = 0; i < items.Length; i++)
			{
				items[i].GetComponent<ActivateDialogueAtLine>().StartLine = 6;
				items[i].GetComponent<ActivateDialogueAtLine>().EndLine = 6;
			}
			closet.StartLine = 7;
			closet.EndLine = 7;
			closet.off = 1;
			HasBat = false;
		}
	}
}
