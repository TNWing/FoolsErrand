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
public class TaskInteraction : MonoBehaviour {//note: need to add way to obtain unused items back
    public List<AudioSource> SFXList = new List<AudioSource>();
    public bool issolved;
    public GameObject ItemMenu;
    public GameObject Player;
    public SolutionList SList = new SolutionList();
    public ListofIU IUList = new ListofIU();
    public string[] SolutionsText;

    public Sprite[] FinishedSprites;
    public SpriteRenderer SR;//child object that has sprite renderer

    public List<GameObject> ListofUsedItems = new List<GameObject>();

    public Vector2 spawnpos;//position where items are returned
    public GameObject ParentObj;//parent object of items that are returned
	void OnEnable () {
        Player = GameObject.FindGameObjectWithTag("Player");
        SR=GetComponent<SpriteRenderer>();
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
                    if (isvalid == true)
                    {
                        break;
                    }
                    string ItemName = (Sol[i].reqitems[n] + " (Inventory)").ToLower();
                    if (ItemName == obj)
                    {
                        itemvalid = true;
                        IU[i].itemused[n] = true;//issue
                        GameObject TempObj = Instantiate(Inv[e].transform.GetChild(0).gameObject.GetComponent<InventoryPrefab>().SpawnItem);
                        TempObj.transform.parent = gameObject.transform.GetChild(2);
                        TempObj.SetActive(false);
                        ListofUsedItems.Add(TempObj);
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
                            SR.sprite = FinishedSprites[i];
                            //adds back unused items to inventory
                            List<GameObject> ObjToRemove = new List<GameObject>();
                            foreach (GameObject g in ListofUsedItems)
                            {
                                //determines what items were used
                                
                                for(int a = 0; a < Sol[i].reqitems.Count; a++)
                                {
                                    string IName = (Sol[i].reqitems[a] + "(Clone)").ToLower();
                                    Debug.Log(g.name);
                                    if (g.name.ToLower() == IName)
                                    {
                                        ObjToRemove.Add(g);
                                        Debug.Log("Item consumed is : " + g);
                                        break;
                                    }
                                }
                            }
                            foreach (GameObject g in ObjToRemove)
                            {
                                ListofUsedItems.Remove(g);
                                Destroy(g);
                            }
                            foreach (GameObject g in ListofUsedItems)//unused items returned
                            {
                                Debug.Log(g);
                                string name = (g.name + "Inventory").ToLower();
                                GameObject Obj = Instantiate(g, transform.position, Quaternion.identity);
                                Obj.transform.parent = ParentObj.transform;
                                Obj.transform.position = spawnpos;
                                Obj.SetActive(true);
                            }
                            
                        }
                    }
                }
            }
            
            if (isvalid == true)
            {
                Debug.Log("Solved");
                issolved = true;
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
        yield return new WaitWhile(() => Input.GetKey(KeyCode.Space));
        this.enabled = false;
    }
}
