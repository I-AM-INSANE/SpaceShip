using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float angle = Random.Range(0, Mathf.PI * 2);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(2, 3);
        Rigidbody2D asteroid = gameObject.GetComponent<Rigidbody2D>();
        asteroid.AddForce(direction * magnitude, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
