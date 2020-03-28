using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLevel : MonoBehaviour
{
    public bool inLight = false;
    public float maxLightLevel = 10f;
    public float lightLevel = 10f;
    public float timeBetweenLevelUpdate = 1f;
    public float timeUntilLevelUpdate = 1f;
    public string strTag = "Light";

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
        timeUntilLevelUpdate -= Time.deltaTime;
        
        if (timeUntilLevelUpdate <= 0)
        {
            if (inLight == false)
                lightLevel--;

            if (inLight == true)
                lightLevel++;

            if (lightLevel > maxLightLevel)
                lightLevel = maxLightLevel;

            if (lightLevel < 0)
                lightLevel = 0;

            timeUntilLevelUpdate = timeBetweenLevelUpdate;
        }
    }
}