using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightController : MonoBehaviour
{
    [SerializeField] private Light2D pointLight;

    private void OnTriggerStay2D(Collider2D other)
    {
//        pointLight.intensity = 0f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Light"))
        {
//            DOTween.To(() => pointLight.intensity, value => pointLight.intensity = value, 0, 0.5f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Light"))
        {
//            DOTween.To(() => pointLight.intensity, value => pointLight.intensity = value, 1, 0.5f);
        }
    }
}
