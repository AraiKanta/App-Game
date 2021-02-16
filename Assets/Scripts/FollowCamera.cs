using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FollowCamera : MonoBehaviour
{
    GameObject playerObj;
    Transform playerTransForm;

    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        playerTransForm = playerObj.transform;
    }

    void LateUpdate()
    {
        MoveCamera();
    }

    void MoveCamera() 
    {
        transform.position = new Vector3(playerTransForm.position.x + 6, transform.position.y, transform.position.z);
    }
}
