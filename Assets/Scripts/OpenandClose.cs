using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenandClose : MonoBehaviour {
    public Sprite[] sprites = new Sprite[2];
    public bool changecollision;
    // Use this for initialization
    void OnEnable()
    {
        ChangeSprite();
    }
    void ChangeSprite()
    {
        var sr = GetComponent<SpriteRenderer>();
        var child = transform.Find("PlayerCollider");
        if (sr.sprite == sprites[0])
        {
            sr.sprite = sprites[1];
        }
        else
        {
            sr.sprite = sprites[0];
        }
        if (changecollision)
        {
            child.GetComponent<Collider2D>().enabled = !child.GetComponent<Collider2D>().enabled;
        }
        this.enabled = false;
    }
}
