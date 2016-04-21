using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public GameObject startingPoint;
	public GameObject ball;

	// Use this for initialization
	void Start () {
		RestartGame();
	}
	
	public void RestartGame() 
	{
		ball.transform.position = startingPoint.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
