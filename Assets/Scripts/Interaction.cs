using System.Collections;
using UnityEngine;

public class Interaction : MonoBehaviour {
    public bool end;
    public bool interact;

    void Start()
    {
        Invoke("NoTarget", 0.1f);
        StartCoroutine(Remove());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        interact = true;
        GameObject c = collision.gameObject;
        if (c.tag=="Interactable")
        {
            c.GetComponent<BaseInteraction>().enabled = true;
        }
        Invoke("SetEndTrue", 0.01f);
    }
    void SetEndTrue()
    {
        end = true;
    }
    void NoTarget()
    {
        if (!interact)
        {
            end = true;
        }
    }
    IEnumerator Remove()
    {
        yield return new WaitUntil(() => end);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteraction>().caninteract = true;
    }
}
