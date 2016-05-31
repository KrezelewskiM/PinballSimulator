using UnityEngine;
using System.Collections;

public abstract class Simulation : MonoBehaviour {

	public abstract void InitSimulation();	
	public abstract void RunSimulation();
	public abstract void OnRestart();
}
