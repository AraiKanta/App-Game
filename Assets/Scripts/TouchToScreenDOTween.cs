using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TouchToScreenDOTween : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] Text ttsText;
 
    void Start()
    {
        ttsText = GetComponent<Text>();

        Dofade();
    }

    private void Dofade() 
    {
        ttsText.DOFade(0.0f, this.duration)
            .SetEase(Ease.Flash)
            .SetLoops(-1, LoopType.Restart)
            .Play();
    }
}
