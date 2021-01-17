using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // Start is called before the first frame update
    const float MovePerSeconds = 20f;
    float turnRad = Mathf.PI / 2;
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
            turnRad += -direction * 0.02f;
            transform.Rotate(0, 0, -direction * 1.15f);
        }

        if (Input.GetAxis("DriveShip") != 0)
        {
            Vector2 vector = new Vector2(Mathf.Cos(turnRad), Mathf.Sin(turnRad*1));//jo;j;;
            vector *= MovePerSeconds;
            rigidSpaceShip.AddForce(vector, ForceMode2D.Force);
        }
    }
}
