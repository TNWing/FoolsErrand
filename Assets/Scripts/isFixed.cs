using System.Collections;
using UnityEngine;
using TMPro;
public class isFixed : MonoBehaviour {
    public GameObject Chore;
    public string chorename;//backup if Chore isn't assigned
	void Start () {
        if (Chore == null)
        {
            Chore = GameObject.Find(chorename);
        }
        StartCoroutine(Strike());
	}
	
    IEnumerator Strike()
    {
        yield return new WaitUntil(()=>Chore.GetComponent<TaskInteraction>().issolved);
        GetComponent<TextMeshPro>().fontStyle = FontStyles.Strikethrough;
    }
}
