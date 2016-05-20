using UnityEngine;

public class BallController : MonoBehaviour
{
    private Vector3 velocity;
    private Vector3 baseForwardVelocity;

    public TimeManager timeManager;
    private SpringLauncherController springController;

    void Start()
    {
        springController = GameObject.FindGameObjectWithTag("SpringLauncher").GetComponent<SpringLauncherController>();
        baseForwardVelocity = this.transform.forward;
        Reset();
    }

    private void Reset()
    {
        springController.launched = false;
        this.velocity = baseForwardVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown("joystick button 2"))
        {
            BallPositionInfo ballPositionInfo = timeManager.GetSavedBallPosition();
            this.transform.position = ballPositionInfo.ballPosition;
            this.GetComponent<Rigidbody>().velocity = ballPositionInfo.ballVelocity;
        }
    }

    void FixedUpdate()
    {
        BallPositionInfo ballPositionInfo = new BallPositionInfo(gameObject.transform.position, gameObject.GetComponent<Rigidbody>().velocity);
        timeManager.SaveBallPosition(ballPositionInfo);
    }

    public void StartBall(float force)
    {
        GameObject.Find("ScoreTracker").GetComponent<ScoreTracker>().ResetScore();
        this.GetComponent<Rigidbody>().AddForce(baseForwardVelocity * force, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == Constants.GAME_OVER_TAG)
        {
            Reset();
            GameObject.Find(Constants.GAME_MANAGER_NAME).GetComponent<GameManager>().RestartGame();
        }
        else
        {
            ContactPoint contactPoint = col.contacts[0];
            velocity = 2 * (Vector3.Dot(velocity, Vector3.Normalize(contactPoint.normal))) * Vector3.Normalize(contactPoint.normal) - velocity;
            velocity *= -1;
        }
    }
}
