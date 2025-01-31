using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightAnimator : MonoBehaviour
{
    [SerializeField] private Light2D lightIntensity;
    private void Start()
    {
        DOTween.To(() => lightIntensity.intensity, x => lightIntensity.intensity = x, lightIntensity.intensity + 0.5f, 1)
        .SetLoops(-1, LoopType.Yoyo) // Infinite loop
            .SetEase(Ease.Linear);    // Smooth transition
    }
}
