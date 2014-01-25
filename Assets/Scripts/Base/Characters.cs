using UnityEngine;
using System.Collections;

public class Character {
	public int characterIndex; // 1-indexed
	public string Name;
	public Sprite characterPortrait;

	static Character[] Characters = new Character[3];
}

public class Cat:Character {
	public Cat() {
		characterIndex = 1;
		Name = "Cat";
		characterPortrait = Resources.Load<Sprite> ("Characters/cat");
	}
}

public class Girl:Character {
	public Girl() {
		characterIndex = 2;
		Name = "Girl";
		characterPortrait = Resources.Load<Sprite> ("Characters/girl");
	}
}

public class Napoleon:Character {
	public Napoleon() {
		characterIndex = 3;
		Name = "Napoleon";
		characterPortrait = Resources.Load<Sprite> ("Characters/napoleon");
	}
}
