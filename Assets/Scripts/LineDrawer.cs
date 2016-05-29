using UnityEngine;
using System.Collections;

public class LineDrawer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 ballVelocity;
    private Vector3 ballPosition;
    private Rigidbody ballRigidbody;
    private SphereCollider sphereCollider;
    private RaycastHit hit;
    float radius;
    public bool draw;


    // Use this for initialization
    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        ballRigidbody = gameObject.transform.parent.GetComponent<Rigidbody>();
        sphereCollider = gameObject.transform.parent.GetComponent<SphereCollider>();
        lineRenderer.SetVertexCount(300);
        clear();
    }

    // Update is called once per frame
    void Update()
    {
        if (draw)
        {
            updateBallPosition();
            Vector3 currentPoint = ballPosition;
            Vector3 previousPoint;
            bool firstCollision = false;
            float timeDelta = Time.deltaTime * 0.5f;
            for (int i = 0; i < 300; i++)
            {
                previousPoint = currentPoint;
                currentPoint += ballVelocity * timeDelta + 0.5f * Physics.gravity * timeDelta * timeDelta;
                ballVelocity += Physics.gravity * timeDelta;

                if (Physics.SphereCast(previousPoint, 0.5f, currentPoint - previousPoint, out hit, Vector3.Distance(previousPoint, currentPoint)))
                {
                    if (firstCollision)
                    {
                        currentPoint = previousPoint;
                    }
                    else
                    {
                        ballVelocity = Vector3.Reflect(ballVelocity, hit.normal);
                        currentPoint += ballVelocity * timeDelta + 0.5f * Physics.gravity * timeDelta * timeDelta;
                        ballVelocity += Physics.gravity * timeDelta;
                        firstCollision = true;
                    }

                }

                lineRenderer.SetPosition(i, currentPoint);
            }
        }
    }

    void updateBallPosition()
    {
        ballVelocity = ballRigidbody.velocity;
        ballPosition = gameObject.transform.parent.position;
    }

    void clear()
    {
        for (int i = 0; i < 300; i++)
        {
            lineRenderer.SetPosition(i, Vector3.zero);
        }
    }
}
