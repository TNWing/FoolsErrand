using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskInteraction : MonoBehaviour {
    public string[] UsableItems;
    public bool issolved;
    public GameObject ItemMenu;
    public GameObject Player;

    public string[] SolutionsText;
	void OnEnable () {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (!issolved)
        {
            ItemMenu = GameObject.Find("Item Menu");
            StartCoroutine(BasicSolution());
        }
	}
    IEnumerator OpenMenu()
    {
        yield return null;
        //ItemMenu.SetActive(true);
    }
    IEnumerator BasicSolution()//solves problem if you have solution
    {
        yield return new WaitUntil(() => Input.GetKey(KeyCode.Space));
        for (int i = 0; i < UsableItems.Length; i++)
        {
            if (Player.GetComponent<BasicInventory>().SelectedItem.name == UsableItems[i])
            {
                issolved = true;
                Debug.Log("Solved");
                break;
            }
        }
        yield return new WaitWhile(() => Input.GetKey(KeyCode.Space));
        this.enabled = false;
    }
}
