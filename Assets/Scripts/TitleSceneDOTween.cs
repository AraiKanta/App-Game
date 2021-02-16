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

        Dofade();
    }
    private void Dofade() 
    {
        touchToStart.DOFade(0.0f, this.duration)
            .SetEase(Ease.Flash)
            .SetLoops(-1, LoopType.Restart)
            .Play();
    }
}
