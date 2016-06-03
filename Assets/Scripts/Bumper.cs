using UnityEngine;
using System.Collections;

public class Bumper : MonoBehaviour
{
    public ScoreTracker scoreTracker;
    public int hitScore;
    
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bumper hit");
        collision.rigidbody.AddForce(-1 * collision.contacts[0].normal * 80, ForceMode.Impulse);
        scoreTracker.AddScore(hitScore);
    }
}
