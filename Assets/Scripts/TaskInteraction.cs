using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class RequiredItems
{
    public List<string> reqitems;
}
[System.Serializable]
public class SolutionList
{
    public List<RequiredItems> Solutions;
}

public class TaskInteraction : MonoBehaviour {
    public string[] UsableItems;
    public bool issolved;
    public GameObject ItemMenu;
    public GameObject Player;
    public SolutionList SList = new SolutionList();
    public string[] SolutionsText;
	void OnEnable () {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (!issolved)
        {
            ItemMenu = GameObject.Find("Item Menu");
            StartCoroutine(AdvancedSolution());
        }
	}
    IEnumerator AdvancedSolution()
    {
        yield return new WaitUntil(() => Input.GetKey(KeyCode.Space));
        var Sol = SList.Solutions;
        bool isvalid=false;
        for (int i = 0; i < Sol.Count; i++)
        {
            for (int n = 0; n < Sol[i].reqitems.Count; n++)
            {
                bool hasitem=false;
                for (int c = 0; c < Player.GetComponent<BasicInventory>().Inventory.Length; c++)
                {
                    if (Sol[i].reqitems[n].ToLower() == Player.GetComponent<BasicInventory>().Inventory[c].name.ToLower())
                    {
                        hasitem = true;
                    }
                }
                if (hasitem == false)
                {
                    break;
                }
                if (n+1 == Sol[i].reqitems.Count)
                {
                    isvalid = true;
                }
            }
            if (isvalid)
            {
                issolved = true;
                Debug.Log("Advanced Solved");
                break;
            }
        }
        yield return new WaitWhile(() => Input.GetKey(KeyCode.Space));
        this.enabled = false;
    }
}
