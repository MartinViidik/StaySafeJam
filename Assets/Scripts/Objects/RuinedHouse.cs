using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class RuinedHouse : MonoBehaviour
{
    [SerializeField] private Light2D[] lights;
    [SerializeField] private Dissolve dissolvingSprite;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        foreach (var l in lights)
        {
            l.intensity = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        dissolvingSprite.DissolveSprite();
        spriteRenderer.DOFade(1, 1f).OnComplete(() =>
        {
            foreach (var l in lights)
            {
                DOTween.To(() => l.intensity, value => l.intensity = value, 1, 1f);
            }
        });
    }
}
