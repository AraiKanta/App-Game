using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private ObstacleSwitch obstacleSwitch;
    [SerializeField] private float posY = 1f;
    bool isFall = false;

    public bool IsFall()
    {
        obstacleSwitch.IsSwitch();

        Move();
        return isFall;
    }

    private void Move()
    {
        isFall = true;
        if (isFall)
        {
            this.gameObject.transform.Translate(0, posY * Time.deltaTime, 0);
        }
    }
}
