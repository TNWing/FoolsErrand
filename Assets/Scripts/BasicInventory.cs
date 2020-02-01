using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicInventory : MonoBehaviour {
    public GameObject[] Inventory = new GameObject[5];
    public GameObject SelectedItem;
    public int currentindex;
	void Start () {
        currentindex = 0;
        StartCoroutine(Select());
	}
	
	IEnumerator Select()
    {
        while (this != null)
        {
            yield return new WaitUntil(() => Input.anyKey);
            if (Input.GetKey(KeyCode.Alpha1))
            {
                currentindex = 0;
            }
            else if (Input.GetKey(KeyCode.Alpha2))
            {
                currentindex = 1;
            }
            else if (Input.GetKey(KeyCode.Alpha3))
            {
                currentindex = 2;
            }
            else if (Input.GetKey(KeyCode.Alpha4))
            {
                currentindex = 3;
            }
            else if (Input.GetKey(KeyCode.Alpha5))
            {
                currentindex = 4;
            }
            yield return new WaitWhile(() => Input.anyKey);
            SelectedItem = Inventory[currentindex];
        }
    }
}
