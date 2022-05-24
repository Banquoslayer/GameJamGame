using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        InputHandler();
    }

    void InputHandler()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MoveUp(1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveUp(-1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveSideWays(1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveSideWays(-1);
        }
    }

    void MoveUp(float direction)
    {
        Vector3 upDirection = new Vector3(0.0f, 0.0f, direction);
        rb.AddForce(upDirection * moveSpeed);
    }

    void MoveSideWays(float direction)
    {
        Vector3 sideDirection = new Vector3(direction, 0.0f, 0.0f);
        rb.AddForce(sideDirection * moveSpeed);
    }
}
