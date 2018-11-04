using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour 
{	

	public List<int> spriteAniamtionsLinkedList = null;

	private SpriteRenderer spriteRenderer;
	public SpriteAnimationSetScriptableObject spriteAnimationSetScriptable;
	private float time;
	private int frameIndex;
	private int currrentSpriteAnimatinIndex;
	[HideInInspector] public bool pause = true;

	public float speed = 1;

	public void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void Update()
	{
		if (pause)
			spriteRenderer.material.color = new Color(0.1f,0.1f,0.1f);
		else
			spriteRenderer.material.color = Color.white;

		if (pause || spriteAniamtionsLinkedList.Count == 0)
			return;

		time -= Time.deltaTime * speed;
		if (time <= 0)
		{

			time = GetCurrentAnimation().interval;
			frameIndex++;
			if (frameIndex > GetCurrentAnimation().sprites.Length - 1)
			{
				frameIndex = 0;
				currrentSpriteAnimatinIndex++;

				if (currrentSpriteAnimatinIndex > spriteAniamtionsLinkedList.Count - 1)
					pause = true;

			}
			
			UpdateSpriteRenderer();
		}
	}

	public void Play(string id)
	{
		int a = 0;
		foreach(var i in spriteAnimationSetScriptable.spriteAnimations)
		{
			if (i.id == id && GetCurrentAnimation() != i)
			{
				frameIndex = 0;
				currrentSpriteAnimatinIndex = a;
				time = i.interval;
				UpdateSpriteRenderer();
				return;
			}
			a ++;
		}

		pause = false;
	}

	public void ReplayAll()
	{
		currrentSpriteAnimatinIndex = 0;
		pause = false;
	}

	public void AddAnimation(string id)
	{
		for(int i = 0; i < spriteAnimationSetScriptable.spriteAnimations.Length; i++)
			{
				if(id == spriteAnimationSetScriptable.spriteAnimations[i].id)
				{
					spriteAniamtionsLinkedList.Add(i);
				}

					
			}
	}

	private void UpdateSpriteRenderer()
	{
		if (pause)
			return;

		spriteRenderer.sprite = GetCurrentAnimation().sprites[frameIndex];
		spriteRenderer.flipX =  GetCurrentAnimation().flipX;
		spriteRenderer.flipY =  GetCurrentAnimation().flipY;
	}

	private SpriteAnimation GetCurrentAnimation()
	{
		return spriteAnimationSetScriptable.spriteAnimations[spriteAniamtionsLinkedList[currrentSpriteAnimatinIndex]];
	}
}
