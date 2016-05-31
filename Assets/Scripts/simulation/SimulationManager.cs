using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class SimulationManager : MonoBehaviour
{
    public bool isSimulationActive;
    
    public Simulation simulation;

    // Use this for initialization
    void Start()
    {
        if (isSimulationActive)
        {
            simulation.InitSimulation();
        }
    }
    
    public void OnRestart()
    {
        if (isSimulationActive)
        {
            simulation.OnRestart();
        }
    }
}
