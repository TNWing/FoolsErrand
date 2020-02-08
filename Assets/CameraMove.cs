using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}
public class CameraMove : MonoBehaviour
{
    public GameObject Player;
    public Boundary Boundary;
    public float speed;
    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float posx = Mathf.Clamp(Player.transform.position.x, Boundary.xMin, Boundary.xMax);
        float posy = Mathf.Clamp(Player.transform.position.y, Boundary.yMin, Boundary.yMax);
        Vector3 newpos = new Vector3(posx, posy, -10);
        transform.position = newpos;
    }
}
