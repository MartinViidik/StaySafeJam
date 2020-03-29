using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightLevelBar : MonoBehaviour
{
    private Image bar;

    // Start is called before the first frame update
    private void Start()
    {
        bar = transform.Find("Bar").GetComponent<Image>();
    }

    public void setSize(float sizeNormalized)
    {
        bar.fillAmount = sizeNormalized;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
