using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDialogueAtLine : MonoBehaviour {

	public ActivateDialogueAtLine closet;
	public TextAsset TheText;
	public int StartLine;
	public int EndLine;
	public DialogueTextReader TheTextBox;
	public int off;
	public int on;
	public bool HasBat;

	// Use this for initialization

	void OnEnable()
	{		
		if(on == off)
		{
			on = 0;
			return;
		}
	
		if(on == 0)
		{
			TheTextBox = FindObjectOfType<DialogueTextReader>();
			TheTextBox.CurrentLine = StartLine;
			TheTextBox.EndAtLine = EndLine;
			TheTextBox.EnableTextBox();
			
		}
		on += 1;
	}

	private void Update()
	{
		this.enabled = false;
	}
}
