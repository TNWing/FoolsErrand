using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePositionIndex : MonoBehaviour {
    public MovePanel[] Panels;
    public int indexchange;
    //changes the position index in the move panel scripts

    public void ChangeIndex()
    {
        foreach (MovePanel P in Panels)
        {
            IndexMod(P);
        }
    }
    void IndexMod(MovePanel P)
    {
        //yield return new WaitUntil(() => P.d1 && P.d2);
        P.positionindex += indexchange;
    }
}
