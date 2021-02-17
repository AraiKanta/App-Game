using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleSceneDOTween : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] Image touchToStart;
 
    void Start()
    {
        touchToStart = GetComponent<Image>();

        var sequence = DOTween.Sequence();
        sequence.Append(touchToStart.DOFade(0.0f, this.duration).SetEase(Ease.InOutFlash))
                .SetLoops(-1, LoopType.Yoyo)
                .Play();
    }
}
