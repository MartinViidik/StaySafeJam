using System.Collections;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    [SerializeField] private float dissolvingTime;
    [SerializeField] private Color dissolvingColor;
    [SerializeField] private SpriteRenderer dissolvingMaterial;

    private void Awake()
    {
        dissolvingMaterial.material.SetColor("_DissolveColor", dissolvingColor);
    }

    public void DissolveSprite()
    {
        StartCoroutine(CoDissolving());
    }

    private IEnumerator CoDissolving()
    {
        var currentTime = 0f;

        while (currentTime < dissolvingTime)
        {
            currentTime += Time.deltaTime;
            dissolvingMaterial.material.SetFloat("_DissolveAmount", currentTime / dissolvingTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
