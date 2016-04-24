﻿using UnityEngine;
using System.Collections;

public class Bumper : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bumper hit");
        collision.rigidbody.AddForce(-1 * collision.contacts[0].normal * 100, ForceMode.Impulse);
    }
}
