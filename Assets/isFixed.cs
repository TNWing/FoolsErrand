using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class isFixed : MonoBehaviour {
    public GameObject Chore;

	void Start () {
        StartCoroutine(Strike());
	}
	
    IEnumerator Strike()
    {
        yield return new WaitUntil(()=>Chore.GetComponent<TaskInteraction>().issolved);
        GetComponent<TextMeshPro>().fontStyle = FontStyles.Strikethrough;
    }
}
