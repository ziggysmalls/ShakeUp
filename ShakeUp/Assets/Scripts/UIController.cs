using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour 
{

	public static string uMessaage;

	public string thisMessage;

	public void Start()
	{
		GetComponent<Button>().onClick.AddListener(Click);
	}
	void Update()
	{
		GetComponent<Button>().interactable = GameController.isPaused;
	}
	public void Click()
	{
		uMessaage = thisMessage;
	}
}
