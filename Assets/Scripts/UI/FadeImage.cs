
using System.Collections;
using UnityEngine;

public class FadeImage : MonoBehaviour
{
    private Animator anim;

    private static FadeImage _instance;
    public static FadeImage Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            anim = GetComponent<Animator>();
        }
    }

    public void FadeEnding()
    {
        anim.SetBool("Ending", true);
    }

    public void FadeDead()
    {
        anim.SetBool("Dead", true);
    }

}
