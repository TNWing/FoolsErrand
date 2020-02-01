using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {
    public bool end = false;
    public bool interact = false;

    void Start()
    {
        StartCoroutine(NoTarget());
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
        StartCoroutine(SetEndTrue());
    }
    IEnumerator SetEndTrue()
    {
        yield return null;
        end = true;
    }
    IEnumerator NoTarget()
    {
        yield return new WaitForSeconds(0.1f);
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
