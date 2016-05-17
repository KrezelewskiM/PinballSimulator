using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    private const float CHANGE_STEP = 0.1f;

    private Text gameSpeedLabel;

    private FixedSizedQueue<BallPositionInfo> ballPositionCache;

    // Use this for initialization
    void Start()
    {
        gameSpeedLabel = GameObject.Find("GameSpeed").GetComponent<Text>();
        UpdateGameSpeedLabel();

        ballPositionCache = new FixedSizedQueue<BallPositionInfo>(100);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) == true)
        {
            Time.timeScale = Mathf.Max(0, Time.timeScale - CHANGE_STEP);
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            UpdateGameSpeedLabel();
        }
        if (Input.GetKeyDown(KeyCode.W) == true)
        {
            Time.timeScale = Mathf.Min(1, Time.timeScale + CHANGE_STEP);
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            UpdateGameSpeedLabel();
        }
    }

    public void SaveBallPosition(BallPositionInfo ballPositionInfo)
    {
        ballPositionCache.Enqueue(ballPositionInfo);
    }

    public BallPositionInfo GetSavedBallPosition()
    {
        return ballPositionCache.Dequeue() as BallPositionInfo;
    }

    private void UpdateGameSpeedLabel()
    {
        gameSpeedLabel.text = "GameSpeed: " + Mathf.Round(Time.timeScale * 10f) / 10f;
    }
}
