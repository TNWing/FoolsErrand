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
    IEnumerator Solve()//wip solve func
    {
        yield return new WaitUntil(() => Input.GetKey(KeyCode.Space));
        var Sol = SList.Solutions;
    }
    IEnumerator AdvancedSolution()
    {
        yield return new WaitUntil(() => Input.GetKey(KeyCode.Space));
        var Sol = SList.Solutions;
        var Inv = Player.GetComponent<Inventory>().slots;
        bool isvalid=false;
        List<GameObject> objs = new List<GameObject>();
        List<int> invlist = new List<int>();
        for (int i = 0; i < Sol.Count; i++)
        {
            
            for (int n = 0; n < Sol[i].reqitems.Count; n++)
            {
                string ItemName = (Sol[i].reqitems[n] + " (Inventory)").ToLower();
                bool hasitem=false;
                for (int c = 0; c < Inv.Length; c++)
                {
                    if (Inv[c].transform.childCount>0 && ItemName.ToLower() == Inv[c].transform.GetChild(0).gameObject.name.ToLower())
                    {
                        hasitem = true;
                        objs.Add(Inv[c].transform.GetChild(0).gameObject);
                        invlist.Add(c);
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
                foreach (GameObject g in objs)
                {
                    
                    Destroy(g);
                }
                foreach (int index in invlist)
                {
                    Player.GetComponent<Inventory>().isFull[index] = false;
                }
                break;
            }
            objs = new List<GameObject>();
            invlist = new List<int>();
        }
        yield return new WaitWhile(() => Input.GetKey(KeyCode.Space));
        this.enabled = false;
    }
}
