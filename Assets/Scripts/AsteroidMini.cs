using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMini : MonoBehaviour
{
    #region Fields

    float angle;
    float magnitude;
    Vector2 direction;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        angle = Random.Range(0, Mathf.PI * 2);
        direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        magnitude = Random.Range(3, 4);
        gameObject.GetComponent<Rigidbody2D>().AddForce(direction * magnitude, ForceMode2D.Impulse);

        Physics2D.IgnoreLayerCollision(9, 9);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        if (collision.gameObject.tag == "SpaceShip")
        {
            Destroy(gameObject);
            AudioManager.Play(AudioClipName.Explosion);
            GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>().Stop();
        }
    }
}
