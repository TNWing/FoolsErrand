using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
    public float speed;
    public GameObject InteractionObj;
    public Vector3 DirFace;
    public bool caninteract = true;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Interact());
    }
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime * Input.GetAxis("Horizontal");
            DirFace = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        }
        if (Input.GetButton("Vertical"))
        {
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime * Input.GetAxis("Vertical");
            DirFace = new Vector3(0, Input.GetAxis("Vertical"), 0);
        }
    }
    IEnumerator Interact()
    {

        while (this != null)
        {
            yield return new WaitUntil(() => caninteract);
            yield return new WaitUntil(() => Input.GetButtonDown("Confirm"));
            caninteract = false;
            Vector3 objpos = transform.position + DirFace;
            GameObject obj = Instantiate(InteractionObj, objpos, Quaternion.identity);
            yield return new WaitUntil(() => caninteract);
            Destroy(obj);
            yield return new WaitForSeconds(0.02f);
        }
    }
}