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

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector2 pos = Player.transform.position;
        float posx = Mathf.Clamp(pos.x, pos.x+Boundary.xMin, pos.x+Boundary.xMax);
        float posy = Mathf.Clamp(pos.y, pos.y+Boundary.yMin, pos.y+Boundary.yMax);
        Vector3 newpos = new Vector3(posx, posy, -10);
        transform.position = newpos;
    }
}
