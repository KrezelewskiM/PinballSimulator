using UnityEngine;

public class BallController : MonoBehaviour
{
    private Vector3 velocity;
    private Vector3 baseForwardVelocity;
    private bool moving;

    void Start()
    {
        moving = false;
        baseForwardVelocity = this.transform.forward;
        Reset();
    }

    private void Reset()
    {
        this.moving = false;
        this.velocity = baseForwardVelocity;
    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.GetKey(KeyCode.Space) || Input.GetKey("joystick button 1")) && !moving)
        {
            moving = true;
        }
    }

    void FixedUpdate()
    {
        if (moving)
        {
            this.transform.position += velocity * Time.deltaTime * 50;
        }
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
