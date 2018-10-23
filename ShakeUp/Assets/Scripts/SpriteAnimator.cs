using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpriteAnimator : MonoBehaviour 
{
public AAnimation[] animations;	
 public AAnimation currentAnimation;
 private SpriteRenderer spriteRenderer;

[System.Serializable]
public class AAnimation
{
    public Sprite[] sprites;
	public AAnimation previousAnimation;
	public AAnimation nextAnimation;

    public float interval;
    [HideInInspector]public float time;
	[HideInInspector]public int currentSpriteFrame;
    
    
	

}
	// Use this for initialization
	void Start () 
	{
		LinkedAnimations();
		
		spriteRenderer = GetComponent<SpriteRenderer>();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
			currentAnimation.time += Time.deltaTime;
			
            if (currentAnimation.time > currentAnimation.interval )
            {
				currentAnimation.currentSpriteFrame++;
				if (currentAnimation.currentSpriteFrame <= currentAnimation.sprites.Length - 1)
				{
					spriteRenderer.sprite = currentAnimation.sprites[currentAnimation.currentSpriteFrame];
					currentAnimation.time = 0;
                }
                
				if(Input.GetKeyDown(KeyCode.Q))
				{
				currentAnimation = animations[0];
				spriteRenderer.sprite = currentAnimation.sprites[0];
				currentAnimation.time = 0;
				currentAnimation.currentSpriteFrame = 0;
                
                
				}
					
                if(Input.GetKeyDown(KeyCode.K))
                {
                currentAnimation = currentAnimation.nextAnimation;
				spriteRenderer.sprite = currentAnimation.sprites[0];
                currentAnimation.time = 0;
				currentAnimation.currentSpriteFrame = 0;
                    
				}
			}
		
	}

	void LinkedAnimations()
	{
		animations[0].previousAnimation = animations[animations.Length - 1];
		animations[animations.Length - 1].nextAnimation = animations[0];

		for(int i = 0; i < animations.Length - 1; i++)
			animations[i].nextAnimation = animations[i + 1];
		for(int i = animations.Length - 1; i > 1; i--)
			animations[i].previousAnimation = animations[i - 1];
	}




}







