using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour
{

	[Range(0, 90)]
    public float boardAngle;
	
	//Arbitrary multiplier to better show ball behavior
	private const float GRAVITY_MULTIPLIER = -40f;

    // Use this for initialization
    void Start()
    {
		RecalculateGravity();
    }

    private void RecalculateGravity()
    {
		float xGravity = Mathf.Sin(boardAngle * Mathf.Deg2Rad) * GRAVITY_MULTIPLIER;
		Debug.Log("Change gravity to: " + xGravity);
		Physics.gravity = new Vector3(xGravity, 0, 0);
    }

    public void SetAngle(float angle)
    {
        this.boardAngle = angle;
		RecalculateGravity();
    }
}
