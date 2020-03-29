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
    private bool _ruined = true;
    public AudioSource natureSound;
    public AudioSource spookSound;

    private AudioSource ac;
    [SerializeField] private AudioClip[] restoreSFX;

    private void Awake()
    {
        foreach (var l in lights)
        {
            l.intensity = 0f;
            l.gameObject.tag = "Untagged";
        }
        ac = GetComponent<AudioSource>();
    }

    public void Dissolve()
    {
        if(!_ruined) return;
        PlaySound();
        _ruined = false;
        dissolvingSprite.DissolveSprite();
        spriteRenderer.DOFade(1, 1f).OnComplete(() =>
        {
            natureSound.volume = 1;
            spookSound.volume = 0;
            foreach (var l in lights)
            {
                l.gameObject.tag = "Light";
                DOTween.To(() => l.intensity, value => l.intensity = value, 1, 1f);
            }
        });
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Dissolve();
    }

    private void PlaySound()
    {
        AudioClip sound = restoreSFX[UnityEngine.Random.Range(0, restoreSFX.Length)];
        ac.PlayOneShot(sound);
    }
}
