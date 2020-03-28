using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LightLevel : MonoBehaviour
{
    public bool inLight = false;
    public float maxLightLevel = 10f;
    public float lightLevel = 10f;
    public float timeBetweenLevelUpdate = 1f;
    public float timeUntilLevelUpdate = 1f;
    public string strTag = "Light";
    [SerializeField] private LightLevelBar lightLevelBar;
    public Animator animator;
    private string levelToLoad = "GameOver";
    public float timeUntilGameOver;
    bool dying = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == strTag)
        {
            inLight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == strTag)
        {
            inLight = false;
        }
    }

    // Update is called once per frame
    void Update()
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
                FadeToLevel("GameOver");
                lightLevel = 0;
            }

            lightLevelBar.setSize(lightLevel/maxLightLevel);
            timeUntilLevelUpdate = timeBetweenLevelUpdate;
        }

        //Switch to GameOver
        if (dying == true)
        {
            timeUntilGameOver -= Time.deltaTime;
        }

        if (timeUntilGameOver <= 0)
            SceneManager.LoadScene(levelToLoad);
    }

    public void FadeToLevel(string GameOver)
    {
        levelToLoad = "GameOver";
        animator.SetTrigger("FadeOut");
        dying = true;
    }
}