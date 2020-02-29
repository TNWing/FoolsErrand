using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class RequiredItems//provides list of items req for a solution
{
    public List<string> reqitems;
}
[System.Serializable]
public class SolutionList//contains all the req items for each solution
{
    public List<RequiredItems> Solutions;
}
[System.Serializable]
public class ItemUsed//states if the item needed was used on this problem (used for multi-obj solutions)
{
    public List<bool> itemused;
}
[System.Serializable]
public class ListofIU//list of above class
{
    public List<ItemUsed> SolutionItems;
}
public class TaskInteraction : MonoBehaviour {
    public bool issolved;
    public GameObject ItemMenu;
    public GameObject Player;
    public SolutionList SList = new SolutionList();
    public ListofIU IUList = new ListofIU();
    public string[] SolutionsText;
	void OnEnable () {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (!issolved)
        {
            ItemMenu = GameObject.Find("Item Menu");
            StartCoroutine(Solve());
        }
	}
    IEnumerator Solve()//wip solve func
    {
        yield return new WaitUntil(() => Input.GetKey(KeyCode.Space));
        var Sol = SList.Solutions;
        var IU = IUList.SolutionItems;
        var Inv = Player.GetComponent<Inventory>().slots;
        bool isvalid = false;
        bool itemvalid=false;
        var e = Player.GetComponent<Inventory>().selectedslot;
        if (e != 9 && Player.GetComponent<Inventory>().isFull[e])
        {
            string obj = Inv[e].transform.GetChild(0).gameObject.name.ToLower();
            for (int i = 0; i < Sol.Count; i++)
            {
                for (int n = 0; n < Sol[i].reqitems.Count; n++)
                {
                    string ItemName = (Sol[i].reqitems[n] + " (Inventory)").ToLower();
                    Debug.Log(ItemName);
                    if (ItemName == obj)
                    {
                        itemvalid = true;
                        IU[i].itemused[n] = true;
                        Destroy(Inv[e].transform.GetChild(0).gameObject);
                        bool isreadytosolve = true;
                        for (int c = 0; c < Sol[i].reqitems.Count; c++)
                        {
                            if (IU[i].itemused[c] == false)
                            {
                                isreadytosolve = false;
                            }
                        }
                        if (isreadytosolve == true)
                        {
                            isvalid = true;
                            break;
                        }
                    }
                }
                if (isvalid == true)
                {
                    Debug.Log("Solved Loser");
                    issolved = true;
                    break;
                }
            }
            if (itemvalid == false)
            {
                Debug.Log("You can't seem to figure out how to use this item...");
            }
            else
            {
                Debug.Log("You used an item");
            }
        } 
        yield return new WaitWhile(() => Input.GetKey(KeyCode.Space));
        this.enabled = false;
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
                    if (Inv[c].transform.childCount>0 && ItemName == Inv[c].transform.GetChild(0).gameObject.name.ToLower())
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
