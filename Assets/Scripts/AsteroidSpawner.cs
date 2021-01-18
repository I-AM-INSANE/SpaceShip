using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabAsteroid;

    [SerializeField]
    Sprite[] sprites = new Sprite[3];

    Timer timer;
    List<GameObject> asteroids = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 2;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished && asteroids.Count < 5)
        {
            asteroids.Insert(0, prefabAsteroid);
            Vector2 spawnPosition = new Vector2(Random.Range(ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight), Random.Range(ScreenUtils.ScreenTop, ScreenUtils.ScreenBottom));
            Instantiate(asteroids[0], spawnPosition, Quaternion.identity);
            ChangeSprite();
            timer.Run();
        }
    }

    void ChangeSprite()
    {
        SpriteRenderer spriteRenderer = asteroids[0].GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[Random.Range(0, 3)];
    }
}
