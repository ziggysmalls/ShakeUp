using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Sprite Animation Set")]
public class SpriteAnimationSetScriptableObject : ScriptableObject
{
	public SpriteAnimation[] spriteAnimations;
}

[System.Serializable]
	public class SpriteAnimation
	{
		public string id;
		public Sprite[] sprites;
		public bool flipX;
		public bool flipY;
		public float interval;
	}
