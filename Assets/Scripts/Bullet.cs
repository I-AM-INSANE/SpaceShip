using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Fields
    Timer timer;
    Vector3 bulletDirection;
    Quaternion bulletRotation;
    const float MovePerSecond = 10f;

    #endregion
    // Start is called before the first frame update
    #region Properties

    public Vector3 BulletDirection
    {
        set { bulletDirection = value; }
    }

    public Quaternion BulletRotation
    {
        set { bulletRotation = value; }
    }

    #endregion

    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(bulletDirection * MovePerSecond, ForceMode2D.Impulse);
        gameObject.transform.rotation = bulletRotation;
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 1f;
        timer.Run();
        Physics2D.IgnoreLayerCollision(8, 8);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }
}
