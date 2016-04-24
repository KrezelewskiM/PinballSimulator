using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject startingPoint;
    public GameObject ball;

    // Use this for initialization
    void Start()
    {
        RestartGame();
    }

    public void RestartGame()
    {
        ball.transform.position = startingPoint.transform.position;
    }
}
