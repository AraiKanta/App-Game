using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideDestroy : MonoBehaviour
{
    [SerializeField] private GameObject _gurideBlack;
    [SerializeField] private GameObject _gurideWhite;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(_gurideBlack);
            Destroy(_gurideWhite);
        }
    }
}
