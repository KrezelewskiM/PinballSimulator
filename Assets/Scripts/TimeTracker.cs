using UnityEngine;
using System.Collections;

public class TimeTracker : MonoBehaviour {

    private float startTime;
    
    public void StartTrackingTime()
    {
        startTime = Time.fixedTime;
    }

    public float GetElapsedTime()
    {
        return Time.fixedTime - startTime;
    }
}
