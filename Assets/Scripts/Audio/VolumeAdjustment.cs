using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary> Audio調整用クラス </summary>
public class VolumeAdjustment: MonoBehaviour
{

    AudioSource _AudioSource;

    public Slider _Slider;

    private bool isPlay;
    public bool isSliderChange;
    void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
        isPlay = true;
    }

    void Update()
    {
        _AudioSource.volume = _Slider.GetComponent<Slider>().normalizedValue;
    }
}
