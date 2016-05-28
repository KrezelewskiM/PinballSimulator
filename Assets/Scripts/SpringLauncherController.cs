using UnityEngine;
using System.Collections;

public class SpringLauncherController : MonoBehaviour
{

    public BallController ball;
    public GameObject startingPosition;
	
	public float springForce;
    public bool launched;

    // Use this for initialization
    void Start()
    {
        launched = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!launched && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown("joystick button 1")))
        {
            LaunchBall(springForce);
        }
    }

    public void LaunchBall(float force)
    {
        Debug.Log("Simulation - launch ball");
        ball.StartBall(force);
        launched = true;
    }
}
