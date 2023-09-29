using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationLeanTween : MonoBehaviour
{
    public GameObject panel;
    public RectTransform background;
    public float posY;
    // Start is called before the first frame update
    void Start()
    {

        startAnim();
        Debug.Log("lean Jalan");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void startAnim()
    {
        /* Shake()*/
        LeanTween.alpha(background, 0f, 2f);

        LeanTween.moveLocalY(panel, posY, 1.25f).setEaseOutBounce().setDelay(2f);
    }
}
