using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>レバースイッチのオーディオを制御するやつ</summary>
[RequireComponent(typeof(AudioClip))]
[RequireComponent(typeof(AudioSource))]
public class LeverSwitchSound : MonoBehaviour
{
    [Header("レバースイッチのオーディオソース")]
    [SerializeField] private AudioSource _audioSource;
    [Header("レバースイッチのオーディオクリップ")]
    [SerializeField] private AudioClip _audioClip;
    [Header("ギミックのオーディオソース")]
    [SerializeField] private AudioSource _gimmickAudioSource;
    [Header("ギミックのオーディオクリップ")]
    [SerializeField] private AudioClip _gimmickAudioClip;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _gimmickAudioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// 当たり判定でオーディオ再生
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _audioSource.PlayOneShot(_audioClip);
            _gimmickAudioSource.PlayOneShot(_gimmickAudioClip);
        }
    }


}
