﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameControl : MonoBehaviour
{
    public GameObject[] Inventory = new GameObject[5];
    public GameObject ConfirmationObj;
    public static GameControl control;
    public int numofchoresdone;
    public int numchores;

    public bool Tutorial;
    void Awake()
    {
        if (control == null)
        {
            Tutorial = true;
            numofchoresdone = 0;
            DontDestroyOnLoad(gameObject);
            control = this;
            Application.targetFrameRate = 60;
            QualitySettings.vSyncCount = 0;
            StartCoroutine(Finish());
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Finish()
    {
        yield return new WaitUntil(() => numofchoresdone>=numchores);
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene(2);
    }
}
