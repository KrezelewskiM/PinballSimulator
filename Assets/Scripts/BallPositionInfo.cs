using UnityEngine;
using System.Collections;

public class BallPositionInfo
{
    public Vector3 ballPosition;
    public Vector3 ballVelocity;

    public BallPositionInfo(Vector3 position, Vector3 velocity)
    {
		this.ballPosition = position;
		this.ballVelocity = velocity;
    }
}
