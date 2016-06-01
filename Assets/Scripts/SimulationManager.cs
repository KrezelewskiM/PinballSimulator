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
    public TimeTracker timeTracker;

    private StreamWriter saveFileScores;
    private StreamWriter saveFileTime;
    private bool simulationPending;

	// Use this for initialization
	void Start () {
        saveFileScores = File.CreateText("scores" + ".txt");
        saveFileTime = File.CreateText("times" + ".txt");
        simulationPending = false;
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
        simulationPending = true;
        Debug.Log("Simulation - starting simulation with force: " + currentSpringStrength);
        timeTracker.StartTrackingTime();
        springController.LaunchBall(currentSpringStrength);
    }

    void SaveScore()
    {
        SaveToFile(saveFileScores, scoreTracker.GetScore().ToString());

        SaveToFile(saveFileTime, timeTracker.GetElapsedTime().ToString());
    }

    private void SaveToFile(StreamWriter file, String value)
    {
        file.Write(currentSpringStrength);
        file.Write(";");
        file.Write(value);
        file.WriteLine();
        file.Flush();
    }

    public void OnRestart()
    {
        if (simulationPending)
        {
            currentSpringStrength += FORCE_STEP;
            SaveScore();
            if (currentSpringStrength <= MAX_FORCE)
            {
                StartSimulation();
            }
        }
    }
}
