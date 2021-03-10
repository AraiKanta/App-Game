using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GuideDOTween : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] Image _guide;
 
    void Start()
    {
        _guide = GetComponent<Image>();

        var sequence = DOTween.Sequence();
        sequence.Append(_guide.DOFade(0.0f, this.duration).SetEase(Ease.InOutFlash))
                .SetLoops(-1, LoopType.Yoyo)
                .Play();
    }
}
