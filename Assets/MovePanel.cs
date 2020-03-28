using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MovePanel : MonoBehaviour {
    //moves and makes a panel fade/reappear
    // Use this for initialization
    public List<Button> ButtonList = new List<Button>();

    public bool fade;

    public bool d1;
    public bool d2;
    public bool enablebuttons;

    public CanvasGroup Panel;

    public Vector3[] positions = new Vector3[3];//original pos,destination 1, destination 2,
    public int positionindex = 1;
	void Start () {
        d1 = true;
        d2 = true;
        positions[0]= transform.position;
        positions[1] =positions[0] - new Vector3(250, 0);
        positions[2]= positions[0] - new Vector3(250, 0);
    }
	
    public void ActivateIEN()
    {
        if (d1==true&&d2==true)
        {
            StartCoroutine(DeactiveButtons());
            d1 = false;
            d2 = false;
            StartCoroutine(OpacityChange());
            StartCoroutine(Move());
        }
        
    }
    IEnumerator DeactiveButtons()
    {
        foreach(Button B in ButtonList)
        {
            B.interactable = false;
        }
        yield return new WaitForSeconds(0.05f);
        yield return new WaitUntil(() => d1==true && d2 == true);
        if (enablebuttons)
        {
            foreach (Button B in ButtonList)
            {
                B.interactable = true;
            }
        }
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(0.02f);
        while (transform.position != positions[positionindex])
        {
            transform.position = Vector3.MoveTowards(transform.position, positions[positionindex], 3f);
            yield return new WaitForSeconds(0.01f);
        }
        d1 = true;
    }
    IEnumerator OpacityChange()
    {
        yield return new WaitForSeconds(0.02f);
        if (fade)
        {
            while (Panel.alpha > 0)
            {
                Panel.alpha -= 0.02f;
                yield return new WaitForSeconds(0.02f);
            }
            enablebuttons = false;
        }
        else
        {
            while (Panel.alpha < 1)
            {
                Panel.alpha += 0.02f;
                yield return new WaitForSeconds(0.02f);
            }
            enablebuttons = true;
        }
        d2 = true;
        
        fade = !fade;
    }
}
