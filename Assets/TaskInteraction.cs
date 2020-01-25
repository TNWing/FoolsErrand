using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskInteraction : MonoBehaviour {
    public string[] UsableItems;
    public GameObject ItemMenu;
	void Start () {
        ItemMenu = GameObject.Find("Item Menu");
	}
	

    IEnumerator OpenMenu()
    {
        yield return null;
        ItemMenu.SetActive(true);
    }
}
