using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueText : MonoBehaviour
{
    public GameObject Text;

    public bool OnScreen;

    public ObjectDataCache ObjectData;

    // Use this for initialization
    void Start()
    {
        Text = GameObject.Find("Text");
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        ObjectData = collision.gameObject.GetComponent<ObjectDataCache>();

        Text.GetComponent<TextMeshProUGUI>().text = ObjectData.thisObject.myName + "" + ObjectData.thisObject.myDesc;
    }
}
