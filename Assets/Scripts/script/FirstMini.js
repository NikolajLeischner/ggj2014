#pragma strict
var tileOne :Transform;var tileTwo :Transform;var tileThree :Transform;
var tileFour :Transform;var tileFive :Transform;var tileSix :Transform;
var tileSeven :Transform;var tileEight :Transform;

function Start () {
	Debug.Log("game started !");
	// randomize the tiles positions
}

function Update () {
	checkSolution();
}

function checkSolution(){
	if (tileOne.position.Equals(Vector3 (0,0,0)) && tileTwo.position.Equals(Vector3 (1,0,0)) && tileThree.position.Equals(Vector3 (2,0,0)) && tileFour.position.Equals(Vector3 (0,1,0)) && tileFive.position.Equals(Vector3 (1,1,0)) && tileSix.position.Equals(Vector3 (2,1,0)) && tileSeven.position.Equals(Vector3 (0,2,0)) && tileEight.position.Equals(Vector3 (1,2,0)))
	{
		Debug.Log("You Won ! ");
	}
}