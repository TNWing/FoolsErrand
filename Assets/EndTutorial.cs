using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTutorial : MonoBehaviour {

public bool HasBat;
public GameObject Chores;
public GameObject[] items;
public GameObject[] Tutorialitems;
	
	void OnEnable()
	{
		if (HasBat)
		{
			for (int i = 0; i < Tutorialitems.Length; i++)
			{
				Tutorialitems[i].SetActive(false);
			}

			for (int i = 0; i < items.Length; i++)
			{
				items[i].GetComponent<PickUp>().Tutorial = false;
				items[i].GetComponent<PickUp>().enabled = false;
			}

			Chores.SetActive(true);
		}
		
		this.enabled = false;
	}

}
