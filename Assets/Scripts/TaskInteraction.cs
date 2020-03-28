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
    public List<AudioSource> SFXList = new List<AudioSource>();
    public bool issolved;
    public GameObject ItemMenu;
    public GameObject Player;
    public SolutionList SList = new SolutionList();
    public ListofIU IUList = new ListofIU();
    public string[] SolutionsText;

    public Sprite FinishedSprite;

	void OnEnable () {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (!issolved)
        {
            ItemMenu = GameObject.Find("Item Menu");
            StartCoroutine(Solve());
        }
	}
    IEnumerator Solve()
    {
        yield return new WaitUntil(() => Input.GetKey(KeyCode.Space));
        var Sol = SList.Solutions;
        var IU = IUList.SolutionItems;
        var Inv = Player.GetComponent<Inventory>().slots;
        bool isvalid = false;
        bool itemvalid=false;
        var e = Player.GetComponent<Inventory>().selectedslot;
        if (e != 9 && Player.GetComponent<Inventory>().isFull[e]==true)
        {
            string obj = Inv[e].transform.GetChild(0).gameObject.name.ToLower();
            for (int i = 0; i < Sol.Count; i++)
            {
                for (int n = 0; n < Sol[i].reqitems.Count; n++)
                {
                    string ItemName = (Sol[i].reqitems[n] + " (Inventory)").ToLower();
                    if (ItemName == obj)
                    {
                        itemvalid = true;
                        IU[i].itemused[n] = true;
                        Destroy(Inv[e].transform.GetChild(0).gameObject);
                        Player.GetComponent<Inventory>().isFull[e] = false;
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
                    Debug.Log("Solved");
                    //GetComponent<SpriteRenderer>().sprite = FinishedSprite;
                    issolved = true;
                    break;
                }
                else
                {
                    if (itemvalid == false)
                    {
                        Debug.Log("You can't seem to figure out how to use this item...");
                    }
                    else
                    {
                        Debug.Log("You used an item");
                    }
                }
            }
        } 
        yield return new WaitWhile(() => Input.GetKey(KeyCode.Space));
        this.enabled = false;
    }
}
