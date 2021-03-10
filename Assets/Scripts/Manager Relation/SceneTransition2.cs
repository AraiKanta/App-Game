﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition2 : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void OnClick() 
    {
        SceneManager.LoadScene(sceneName);
    }
}
