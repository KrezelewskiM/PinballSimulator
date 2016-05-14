using UnityEngine;
using System.Collections;

public class SpringLauncherController : MonoBehaviour
{

    public BallController ball;
    public GameObject startingPosition;
	
	public float springForce;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) == true)
        {
			ball.StartBall(springForce);
        }
    }
}
