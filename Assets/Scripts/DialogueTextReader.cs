using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class DialogueTextReader : MonoBehaviour{

	public GameObject TextBox;
	public TextMeshProUGUI TheText;

    public TextAsset DialogueFile;
    public string[] DialogueLines;

	public int CurrentLine;
	public int EndAtLine;
	public PlayerInteraction move;
	public bool IsActive;
	public bool StopPlayer;

    void Start()
    {
		TextBox = GameObject.Find("TextBox");
		move = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteraction>();
		
        if (DialogueFile != null)
        {
            DialogueLines = (DialogueFile.text.Split('/'));
        }

		if (EndAtLine == 0)
		{
			EndAtLine = DialogueLines.Length - 1;
		}

		if (IsActive)
		{
			EnableTextBox();
		}
		else
		{
			DisableTextBox();
		}
    }

	void Update()
	{
		TheText.text = DialogueLines[CurrentLine];

		if (!IsActive)
		{
			return;
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			CurrentLine += 1;
		}

		if (CurrentLine > EndAtLine)
		{
			DisableTextBox();
		}
	}

	public void EnableTextBox()
	{
		TextBox.SetActive(true);
		move.CanMove = false;
		IsActive = true;
	}

	public void DisableTextBox()
	{
		TextBox.SetActive(false);
		move.CanMove = true;
		IsActive = false;
	}

	public void ReloadScript(TextAsset TheText)
	{
		if (TheText != null)
		{
			DialogueLines = new string[1];
			DialogueLines = (TheText.text.Split('/'));
		}
	}
}
