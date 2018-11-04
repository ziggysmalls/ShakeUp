using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	private SpriteAnimator spriteAnimatorPlayer1;
	private SpriteAnimator spriteAnimatorPlayer2;
	public static bool isPaused;


	// Use this for initialization
	void Start () 
	{
		spriteAnimatorPlayer1 = gameObject.transform.GetChild(0).GetComponent<SpriteAnimator>();
		spriteAnimatorPlayer2 = gameObject.transform.GetChild(1).GetComponent<SpriteAnimator>();
		

	}
	
	// Update is called once per frame
	void Update () 
	{
		isPaused = spriteAnimatorPlayer1.pause;
		if (UIController.uMessaage != "" && UIController.uMessaage != null && spriteAnimatorPlayer1.pause)
		{
			
			spriteAnimatorPlayer1.AddAnimation(UIController.uMessaage);
			spriteAnimatorPlayer2.AddAnimation(UIController.uMessaage);

			spriteAnimatorPlayer1.ReplayAll();
			spriteAnimatorPlayer2.ReplayAll();

			UIController.uMessaage = "";
		}
		if(UIController.uMessaage == "ReplayAll" && spriteAnimatorPlayer1.pause)
		{
			spriteAnimatorPlayer1.ReplayAll();
			spriteAnimatorPlayer2.ReplayAll();
			UIController.uMessaage = "";
		}


	}
}
