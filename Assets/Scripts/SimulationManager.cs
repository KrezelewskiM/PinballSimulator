using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class SimulationManager : MonoBehaviour {

    private int currentSpringStrength = 0;
    private int FORCE_STEP = 10;
    private int MAX_FORCE = 300;

    public SpringLauncherController springController;
    public ScoreTracker scoreTracker;

    private StreamWriter saveFile;

	// Use this for initialization
	void Start () {
        saveFile = File.CreateText("scores" + ".txt");
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.S) == true)
        {
            StartSimulation();
        }
	}

    void StartSimulation()
    {
        Debug.Log("Simulation - starting simulation with force: " + currentSpringStrength);
        springController.LaunchBall(currentSpringStrength);
    }

    void SaveScore()
    {
        saveFile.Write(currentSpringStrength);
        saveFile.Write(";");
        saveFile.Write(scoreTracker.GetScore());
        saveFile.WriteLine();
        saveFile.Flush();
    }

    public void OnRestart()
    {
        currentSpringStrength += FORCE_STEP;
        SaveScore();
        if (currentSpringStrength <= MAX_FORCE)
        {
            StartSimulation();
        }
    }
}
