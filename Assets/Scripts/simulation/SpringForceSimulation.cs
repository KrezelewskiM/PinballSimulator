using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class SpringForceSimulation : Simulation
{

    private int currentSpringStrength = 0;
    private int FORCE_STEP = 10;
    private int MAX_FORCE = 300;

    public SpringLauncherController springController;
    public ScoreTracker scoreTracker;
    public TimeTracker timeTracker;

    private StreamWriter saveFileScores;
    private StreamWriter saveFileTime;

    private const string RESULTS_FOLDER = "results/";

    void SaveScore()
    {
        SaveToFile(saveFileScores, scoreTracker.GetScore().ToString());
        SaveToFile(saveFileTime, timeTracker.GetElapsedTime().ToString());
    }

    private void SaveToFile(StreamWriter file, string value)
    {
        file.Write(currentSpringStrength);
        file.Write(";");
        file.Write(value);
        file.WriteLine();
        file.Flush();
    }

    public override void OnRestart()
    {
        currentSpringStrength += FORCE_STEP;
        SaveScore();
        if (currentSpringStrength <= MAX_FORCE)
        {
            RunSimulation();
        }
    }

    public override void InitSimulation()
    {
        saveFileScores = File.CreateText(RESULTS_FOLDER + "scores" + ".txt");
        saveFileTime = File.CreateText(RESULTS_FOLDER + "times" + ".txt");
    }

    public override void RunSimulation()
    {
        Debug.Log("Simulation - starting simulation with force: " + currentSpringStrength);
        timeTracker.StartTrackingTime();
        springController.LaunchBall(currentSpringStrength);
    }
}
