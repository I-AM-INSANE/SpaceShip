using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // Start is called before the first frame update
    const float MovePerSecond = 6f;
    const float TurnSpeed = 1.5f;
    Rigidbody2D rigidSpaceShip;
    void Start()
    {
        rigidSpaceShip = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Turn");
        if (direction != 0)
        {
            transform.Rotate(0, 0, -direction * TurnSpeed);
        }

        if (Input.GetAxis("DriveShip") > 0)
        {
            rigidSpaceShip.AddForce(transform.up * MovePerSecond, ForceMode2D.Force);
        }
    }
}
