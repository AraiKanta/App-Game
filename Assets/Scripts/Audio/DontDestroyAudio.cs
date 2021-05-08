﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//シーン遷移してもオーディオ消さない奴
public class DontDestroyAudio : SingletonMonoBehaviour<DontDestroyAudio>
{
    [SerializeField] private string sceneName;

    public void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this);
    }

    public void AudioDestroy() 
    {
        SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
        SceneManager.LoadScene(sceneName);
    }
    
}
