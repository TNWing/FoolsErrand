using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ChoreList : MonoBehaviour {
    public List<string> Chores = new List<string>();
    public List<bool> ChoreDone = new List<bool>();//strikesthr: <s> </s>

    //public TMP_;
	void Start () {
		
	}

	void Update () {
        GetComponent<TextMeshPro>().text = "Chores";
       // GetComponent<TextMeshPro>().fontStyle = Strike;
    }
}
