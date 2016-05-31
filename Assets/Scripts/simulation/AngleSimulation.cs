using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class AngleSimulation : Simulation
{
    private int currentAngle = 5;
    private int ANGLE_STEP = 5;
	private int MIN_ANGLE = 10;
    private int MAX_ANGLE = 90;

    private int currentForce = 10;
    private int FORCE_STEP = 10;
    private int MAX_FORCE = 300;

    public SpringLauncherController springController;
    public ScoreTracker scoreTracker;
    public TimeTracker timeTracker;

    public BoardManager boardManager;

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
        file.Write(currentAngle);
        file.Write(";");
		file.Write(currentForce);
		file.Write(";");
        file.Write(value);
        file.WriteLine();
        file.Flush();
    }

    public override void OnRestart()
    {
		Debug.Log("Simulation - OnRestart()");
        SaveScore();
        currentAngle += ANGLE_STEP;
        if (currentAngle <= MAX_ANGLE)
        {
            RunSimulation();
        }
        else
        {
            if (ChangeForce())
            {
                RunSimulation();
            }
        }
    }

    private bool ChangeForce()
    {
        if (currentForce > MAX_FORCE)
        {
            return false;
        }
        currentForce += FORCE_STEP;
        currentAngle = MIN_ANGLE;
		return true;
    }

    public override void InitSimulation()
    {
        saveFileScores = File.CreateText(RESULTS_FOLDER + "scores" + ".txt");
        saveFileTime = File.CreateText(RESULTS_FOLDER + "times" + ".txt");
    }

    public override void RunSimulation()
    {
        Debug.Log("Simulation - starting simulation with angle: " + currentAngle + " and force: " + currentForce);
        timeTracker.StartTrackingTime();
        boardManager.SetAngle(currentAngle);
        springController.LaunchBall(currentForce);
    }
}
