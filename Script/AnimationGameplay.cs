using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationGameplay : MonoBehaviour
{
    //public GameObject char2D;
    public GameObject textBox;
    public GameObject textBox2;
    public GameObject cardHolder;
    //public GameObject panelChar;

    public float posYText;
    public float posYCard;
    public float posYTextafter;
    //public float PosXCharafter;
    //public float PosYpanel;
    // Start is called before the first frame update
    void Start()
    {
         LeanTween.moveLocalY(textBox, posYText, 1.25f).setEaseOutBounce().setDelay(13f);
        LeanTween.moveLocalY(textBox2, posYText, 1.25f).setEaseOutBounce().setDelay(5f);
        LeanTween.moveLocalY(cardHolder, posYCard, 1.25f).setEaseOutBounce().setDelay(23f);
        animout();
    }

    // Update is called once per frame
    void animout()
    {
        LeanTween.moveLocalY(textBox2, posYTextafter, 1.25f).setEaseOutBounce().setDelay(12f);
        LeanTween.moveLocalY(textBox, posYTextafter, 1.25f).setEaseOutBounce().setDelay(23f);
    }
}
