using UnityEngine;
using System.Collections;

public class flipperController : MonoBehaviour {
    public string direction;
    public float startingRotation;
    public float maxRotation;
    public bool gamePad;

    public bool movingForward;

    private float difference;
    private float inputValue;
    private Transform thisTransform;
    private float previousInputValue;
    private float currentInputValue;

	void Start () {
        thisTransform = gameObject.transform;
        difference = maxRotation - startingRotation;
        currentInputValue = 0f;
        movingForward = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        previousInputValue = currentInputValue;
        if (direction == "LEFT")
        {
            if (gamePad)
            {
                inputValue = scaledInput(Constants.LEFT_TRIGGER);
            }
            else
            {
                inputValue = keyboardInput(KeyCode.Z);
            }
        }
        else
        {
            if (gamePad)
            {
                inputValue = scaledInput(Constants.RIGHT_TRIGGER);
            }
            else
            {
                inputValue = keyboardInput(KeyCode.X);
            }
        }

        rotateLever(inputValue);
        currentInputValue = inputValue;
        movingForward = currentInputValue != previousInputValue;
	}

    void OnCollisionEnter(Collision collision)
    {
        if (movingForward)
            collision.rigidbody.AddForce(-1 * collision.contacts[0].normal * 50, ForceMode.Impulse);
    }


    private void rotateLever(float value)
    {
        Vector3 rotationVector = thisTransform.rotation.eulerAngles;
        rotationVector.y = startingRotation + difference * value;
        thisTransform.rotation = Quaternion.Euler(rotationVector);
    }

    private float scaledInput(string triggerName)
    {
        return Input.GetAxis(triggerName) / 2f + 0.5f;
    }

    

    private float keyboardInput(KeyCode key)
    {
        if (Input.GetKey(key))
        {
            return 1f;
        }
        return 0f;
    }
}
