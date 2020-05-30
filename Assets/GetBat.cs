using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBat : MonoBehaviour {

public HasBatTutorial finalpart;
public EndTutorial finalpart2;

	void OnEnable()
		{
			finalpart = GameObject.Find("GameControl").GetComponent<HasBatTutorial>();
			finalpart2 = GameObject.Find("Closet (Tutorial2)").GetComponent<EndTutorial>();
			finalpart.HasBat = true;
			finalpart2.HasBat = true;
		}
}
