using UnityEngine;
using System.Collections;

public class OwnPhysics : MonoBehaviour {
    private Vector3 speed;
    private Vector3 acceleration;
    private bool moving;
	// Use this for initialization
	void Start () {
        moving = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space) && !moving)
        {
            speed = Quaternion.AngleAxis(15, gameObject.transform.forward) * gameObject.transform.right * 10;
            acceleration = Quaternion.AngleAxis(15, gameObject.transform.forward) * gameObject.transform.right * -1 * 0.5f * 10;
            moving = true;
        }

        if (moving)
        {
            speed = speed + acceleration * Time.deltaTime;
            transform.position = transform.position + speed * Time.deltaTime;
        }
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Cube")
        {       
            moving = false;
            speed = Vector3.zero;
            acceleration = Vector3.zero;
        }
    }
}
