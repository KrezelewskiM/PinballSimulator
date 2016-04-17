using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
    private Vector3 velocity;
    private bool moving;
	
	void Start () {
        moving = false;
        velocity = this.transform.forward;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space) && !moving)
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
        ContactPoint contactPoint = col.contacts[0];
        velocity = 2 * (Vector3.Dot(velocity, Vector3.Normalize(contactPoint.normal))) * Vector3.Normalize(contactPoint.normal) - velocity;
        velocity *= -1;
    }
}
