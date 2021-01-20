using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabAsteroid;

    [SerializeField]
    Sprite[] sprites = new Sprite[3];

    // Timer timer;
    List<GameObject> asteroids = new List<GameObject>();
    Vector2 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        // timer = gameObject.AddComponent<Timer>();
        AsteroidSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        ScreenUtils.Initialize();
    }

    void ChangeSprite(GameObject prefabAsteroid)
    {
        SpriteRenderer spriteRenderer = prefabAsteroid.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[Random.Range(0, 3)];
    }

    void AsteroidSpawn()
    {
        SpriteRenderer spriteRenderer = prefabAsteroid.GetComponent<SpriteRenderer>();
        float asteroidWidth = spriteRenderer.sprite.bounds.size.x;
        float asteroidHeight = spriteRenderer.sprite.bounds.size.y;

        spawnPosition = new Vector2(ScreenUtils.ScreenRight - (ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft) / 2, ScreenUtils.ScreenTop + asteroidHeight);
        Instantiate(prefabAsteroid, spawnPosition, Quaternion.identity);
        ChangeSprite(prefabAsteroid);
        spawnPosition = new Vector2(ScreenUtils.ScreenRight + asteroidWidth, ScreenUtils.ScreenTop - (ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom) / 2);
        Instantiate(prefabAsteroid, spawnPosition, Quaternion.identity);
        ChangeSprite(prefabAsteroid);
        spawnPosition = new Vector2(ScreenUtils.ScreenRight - (ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft) / 2, ScreenUtils.ScreenBottom - asteroidHeight);
        Instantiate(prefabAsteroid, spawnPosition, Quaternion.identity);
        ChangeSprite(prefabAsteroid);
        spawnPosition = new Vector2(ScreenUtils.ScreenLeft - asteroidWidth, ScreenUtils.ScreenTop - (ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom) / 2);
        Instantiate(prefabAsteroid, spawnPosition, Quaternion.identity);
        ChangeSprite(prefabAsteroid);
    }
}
