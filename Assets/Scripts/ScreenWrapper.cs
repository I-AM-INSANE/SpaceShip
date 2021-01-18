using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
