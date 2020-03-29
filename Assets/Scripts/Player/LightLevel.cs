using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class LightLevel : MonoBehaviour
{
    public bool active = true;
    public bool inLight = false;
    public float maxLightLevel = 10f;
    public float lightLevel = 10f;
    public float timeBetweenLevelUpdate = 1f;
    public float timeUntilLevelUpdate = 1f;
    public string strTag = "Light";
    [SerializeField] private LightLevelBar lightLevelBar;
    [SerializeField] private Animator playerAnimator;
    public Animator animator;
    private string levelToLoad = "GameOver";
    public float timeUntilGameOver;
    bool dying;
    private bool _dead;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(strTag))
        {
            inLight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(strTag))
        {
            inLight = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            //LightLevel
            timeUntilLevelUpdate -= Time.deltaTime;

            if (timeUntilLevelUpdate <= 0)
            {
                if (inLight == false)
                    lightLevel--;

                if (inLight == true && dying == false)
                    lightLevel++;

                if (lightLevel > maxLightLevel)
                    lightLevel = maxLightLevel;

                if (lightLevel < 0)
                {
                    if (!_dead)
                        StartCoroutine(Dying());
                    lightLevel = 0;
                }

                lightLevelBar.setSize(lightLevel / maxLightLevel);
                timeUntilLevelUpdate = timeBetweenLevelUpdate;
            }

            //Switch to GameOver
            if (dying)
            {
                timeUntilGameOver -= Time.deltaTime;
            }

            if (timeUntilGameOver <= 0)
                SceneManager.LoadScene(levelToLoad);
        }
    }

    private IEnumerator Dying()
    {
        _dead = true;
        PlayerMovement.Instance.dead = true;
        PlayerMovement.Instance.SetMovementEnabled(false);
        playerAnimator.SetTrigger("Dead");
        ColorAdjustments colorAdjustments;
        Camera.main.GetComponent<Volume>().profile.TryGet(out colorAdjustments);
//        colorAdjustments.saturation.value = 0f;
        DOTween.To(() => colorAdjustments.saturation.value, value => colorAdjustments.saturation.value = value, -100f, 1.5f);

        yield return new WaitForSeconds(3f);
        FadeToLevel("GameOver");
    }

    public void FadeToLevel(string GameOver)
    {
        levelToLoad = GameOver;
        animator.SetTrigger("FadeOut");
        dying = true;
    }
}