using UnityEngine;
using System.Collections;


public class GameManager {

	private static GameManager singleton;

	public string currentRoom = "";

	int characterId = 1;

	public static string paddedCellScene = Rooms.PaddedCell;
	
	public static GameManager instance() {
		if (singleton == null) {
			singleton = new GameManager();		
		}
		return singleton;
	}

	public int CurrentCharacterId() {
		return characterId;
	}

	public int NextRandomCharacterId() {
		characterId = new System.Random().Next(1, 3);
		return characterId;
	}

}
