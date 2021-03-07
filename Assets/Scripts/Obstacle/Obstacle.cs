using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour
{
    /// <summary>this.transform.DOMoveの移動先の位置のX,Y,Z軸の変数</summary>
    [Header("最初に動かす位置")]
    [SerializeField] Vector3 startPos;
    /// <summary>this.transform.DOMoveの移動時間の変数</summary>
    [Header("移動時間")]
    [SerializeField] private float traveTime;
    /// <summary>フラグ</summary>
    bool isFall = false;

    //[Header("X動かす値")]
    //[SerializeField] private float posX = 0f;
    //[Header("Y動かす値")]
    //[SerializeField] private float posY = 0f;

    public bool IsFall() 
    {
        Move();
        return isFall;
    }

    private void Move()
    {
        isFall = true;
        if (isFall)
        {
            DOTween.Sequence()
                .Append(this.transform.DOMove(startPos, traveTime).SetRelative())
                .Play();

            //this.gameObject.transform.Translate(posX, posY * Time.deltaTime, 0);
        }
    }
}
