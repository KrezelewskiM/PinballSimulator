using UnityEngine;
using System.Collections;

public class UnityPhysics : MonoBehaviour {
    private Vector3 vector;
	// Use this for initialization
	void Start () {
        vector = Quaternion.AngleAxis(15, gameObject.transform.forward) * gameObject.transform.right * 50;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            
            gameObject.GetComponent<Rigidbody>().AddForce(vector);
        }
    }
}
