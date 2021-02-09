using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackGround : MonoBehaviour
{
    public float speed = 1.0f;
    public float startPos;
    public float endPos;

    private void Update()
    {
        transform.Translate(-1 * speed * Time.deltaTime, 0, 0);

        if (transform.position.x <= endPos) ScrollEnd();
    }

    void ScrollEnd()
    {
        float excess = transform.position.x - endPos;
        Vector2 resetartPosition = transform.position;
        resetartPosition.x = startPos + excess;
        transform.position = resetartPosition;

        SendMessage("OnScrollEnd", SendMessageOptions.DontRequireReceiver);
    }
}
