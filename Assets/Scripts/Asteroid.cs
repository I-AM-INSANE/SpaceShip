using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    GameObject prefabAsteroidMini;
    // Start is called before the first frame update
    void Start()
    {
        float screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
        float screenHeight = ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom;

        float X = Random.Range(Camera.main.transform.position.x - gameObject.transform.position.x - screenWidth / 2.3f, Camera.main.transform.position.x - gameObject.transform.position.x + screenWidth / 2.3f);
        float Y = Random.Range(Camera.main.transform.position.y - gameObject.transform.position.y - screenHeight / 2.3f, Camera.main.transform.position.y - gameObject.transform.position.y + screenHeight / 2.3f);
        Vector2 direction = new Vector2(X, Y);
        direction.Normalize();
        float magnitude = Random.Range(4, 5);
        Rigidbody2D asteroid = gameObject.GetComponent<Rigidbody2D>();
        asteroid.AddForce(direction * magnitude, ForceMode2D.Impulse);


        Physics2D.IgnoreLayerCollision(9, 9);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "SpaceShip")
        {
            //collision.gameObject.GetComponent<HUD>().Stop();
            GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>().Stop();
            Destroy(gameObject);
        }
        Destroy(collision.gameObject);
        Instantiate(prefabAsteroidMini, transform.position, Quaternion.identity);
        Instantiate(prefabAsteroidMini, transform.position, Quaternion.identity);
    }
}
