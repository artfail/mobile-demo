using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marble : MonoBehaviour
{
    private int speed = 10;
    Rigidbody2D bubbleRB;

    void Start()
    {
        bubbleRB = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        bubbleRB.AddForce(new Vector2(Input.acceleration.x, Input.acceleration.y) * speed);
    }
}
