using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    #region Fields

    [SerializeField]
    Bullet prefabBullet;

    Bullet bullet;
    Vector3 bulletSpawnLocation;
    Vector2 recoil;
    Timer timer;
    bool shotCheck = false;

    #endregion

    #region Methods

    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 0.01f;
        timer.Run();
    }

    void Update()
    {
        bulletSpawnLocation = gameObject.transform.position + gameObject.transform.up / 1.5f;
        if (Input.GetAxis("Shot") > 0 && timer.Finished && !shotCheck)
        {
            bullet = Instantiate(prefabBullet, bulletSpawnLocation, Quaternion.identity);
            AudioManager.Play(AudioClipName.Shot);
            bullet.BulletDirection = gameObject.transform.up;
            bullet.BulletRotation = gameObject.transform.rotation;
            timer.Duration = 0.3f;
            timer.Run();
            shotCheck = true;
            gameObject.GetComponent<Rigidbody2D>().AddForce(- gameObject.transform.up / 3, ForceMode2D.Impulse);
        }
        if (Input.GetAxis("Shot") == 0)
            shotCheck = false;
    }

    #endregion
}
