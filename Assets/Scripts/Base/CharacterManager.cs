using UnityEngine;
using System.Collections;

public class CharacterManager : MonoBehaviour
{
	public SpriteRenderer characterPortrait;
	public Character playerChar;

	public void RandomCharacter(int oldCharIndex)
	{
		int rnd = 1;
		int newCharIndex = oldCharIndex + rnd;//Mathf.RoundToInt (Random.Range (1, 2));
		if (newCharIndex % 3 > 0) {
			newCharIndex = newCharIndex % 3;
		}
		//print ("OLD " + oldCharIndex + " NEW " + newCharIndex);
		ChangeCharacter (newCharIndex);
	}
	
	public void ChangeCharacter(int newCharIndex)
	{
		//int characterIndex = newCharIndex;
		switch (newCharIndex) {
		case 1: playerChar = new Cat(); break;
		case 2: playerChar = new Girl(); break;
		case 3: playerChar = new Napoleon(); break;
		}
		
		characterPortrait.sprite = playerChar.characterPortrait;
		//print (characterPortrait.sprite);
	}
}