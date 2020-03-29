using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideArrow : MonoBehaviour
{
    public GameObject target;
    public GameObject returnPoint;
    public SpriteRenderer renderer;
    private Vector3 v_diff;
    private float atan2;
    [SerializeField] private Transform uiArrow;

    private static GuideArrow _instance;
    public static GuideArrow Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void SetNewTarget(GameObject newTarget)
    {
        SetArrowState(true);
        target = newTarget;
    }

    public void ReturnToBase()
    {
        SetArrowState(true);
        target = returnPoint;
    }

    public void SetArrowState(bool state)
    {
//        renderer.enabled = state;
    }

    private void Update()
    {
        if(target != null)
        {
            v_diff = (target.transform.position - transform.position);
            atan2 = Mathf.Atan2(v_diff.y, v_diff.x);
            transform.rotation = Quaternion.Euler(0f, 0f, atan2 * Mathf.Rad2Deg);
            uiArrow.localRotation = transform.rotation;
        }
    }
}
