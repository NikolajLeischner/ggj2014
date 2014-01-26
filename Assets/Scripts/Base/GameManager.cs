using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameManager {

	private static GameManager singleton;

	public string currentRoom = "";

	public string roomStartMessage = "";

	int characterId = 1;

	HashSet<int> remainingCharactersHallway = new HashSet<int>();
	
	HashSet<int> remainingCharactersLobby = new HashSet<int>();

	HashSet<int> allCharacters = new HashSet<int> ();



	public static string paddedCellScene = Rooms.PaddedCell;
	
	public static GameManager instance() {
		if (singleton == null) {
			singleton = new GameManager();
			for (int i = 1; i <= 3; ++i) {
				singleton.remainingCharactersHallway.Add (i);
				singleton.remainingCharactersLobby.Add (i);
				singleton.allCharacters.Add(i);
			}
		}
		return singleton;
	}

	public int CurrentCharacterId() {
		return characterId;
	}

	public void CurrentRoomSuccess() {
		if (currentRoom == Rooms.Hallway) {
			remainingCharactersHallway.Remove (characterId);		
		} else if (currentRoom == Rooms.Lobby) {
			remainingCharactersLobby.Remove (characterId);	
				}
	}

	public bool NextRoomUnlocked() {
		if (currentRoom == Rooms.Hallway && remainingCharactersHallway.Count == 0)
						return true;
				else if (currentRoom == Rooms.Lobby && remainingCharactersLobby.Count == 0)
						return true;
				else if (currentRoom == Rooms.Bedroom)
						return true;
		return false;
	}

	public int NextRandomCharacterId() {
		System.Random random = new System.Random ();
		characterId = allCharacters.OrderBy (x => random.Next ()).First ();
		return characterId;
	}


	public int NextRandomCharacterIdForRoom() {
		NextRandomCharacterId ();
		HashSet<int> remaining = allCharacters;
		if (currentRoom == Rooms.Hallway)
						remaining = remainingCharactersHallway;
				else if (currentRoom == Rooms.Lobby)
						remaining = remainingCharactersLobby;

		
		System.Random random = new System.Random ();
		characterId = remaining.OrderBy (x => random.Next ()).First ();

		return characterId;



	}

}
