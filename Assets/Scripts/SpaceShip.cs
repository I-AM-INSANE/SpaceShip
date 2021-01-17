using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    // Start is called before the first frame update
    bool visible = true;
    Vector3 position;
    float selfWidth, selfHeight;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnBecameInvisible()
    {
        /*RectTransform rectTransform = GetComponent<RectTransform>();
        selfHeight = rectTransform.rect.height;
        selfWidth = rectTransform.rect.width;*/
        position = gameObject.transform.position;
        if (position.x > ScreenUtils.ScreenRight || position.x < ScreenUtils.ScreenLeft)
            position.x = -position.x;
        if (position.y > ScreenUtils.ScreenTop || position.y < ScreenUtils.ScreenBottom)
            position.y = -position.y;
        gameObject.transform.position = position;
    }
}
