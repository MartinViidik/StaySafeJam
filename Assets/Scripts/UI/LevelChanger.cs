﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;



    public void FadeToLevel (string GameOver)
    {
        animator.SetTrigger("FadeOut");
    }
}
