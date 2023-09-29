using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AnimasiSoal : MonoBehaviour
{
    [Header ("soal")]
    public GameObject Soal1;
    public GameObject Soal2;
    public GameObject Soal3;
    public GameObject Soal4;

    [Header("posisi soal")]
    public float YsoalIn;
    public float YSoalOut;
    //public float Yjawaban;

    [Header("jawaban setting")]
    public List<GameObject> jawaban;
    public List<GameObject> jawabanSalah;
    //public TextMeshProUGUI skorKuis;
    public static int tambahSkor;
    public List<GameObject> nilai;
    public GameObject[] salahNotif;
    public GameObject[] benarNotif;
    
    public Vector2 ukurannotif;

    [Header("jawaban")]
    public GameObject jawaban1;
    public GameObject jawaban2;
    public GameObject jawaban3;

    [Header("animasi jawaban")]
    public Vector2 ukuranJawaban;
    public float YjawabanIn;
    public float YjawabanOut;

    private bool notif;
  


    // Start is called before the first frame update
    void Start()
    {
        #region animasi panel soal dan jawaban;
        LeanTween.moveLocalY(Soal1, YsoalIn, 1).setEaseOutBounce();
        Debug.Log("soal1 in");
        LeanTween.moveLocalY(Soal1, YSoalOut, 1).setEaseInOutExpo().setDelay(10);
        Debug.Log("soal1 out");
        LeanTween.moveLocalY(jawaban1, YjawabanIn, 1).setEaseOutBounce();
        LeanTween.moveLocalY(jawaban1, YjawabanOut, 1).setEaseInOutExpo().setDelay(10);

        LeanTween.moveLocalY(Soal2, YsoalIn, 1).setEaseOutBounce().setDelay(13);
        LeanTween.moveLocalY(Soal2, YSoalOut, 1).setEaseInOutExpo().setDelay(23);
        LeanTween.moveLocalY(jawaban2, YjawabanIn, 1).setEaseOutBounce().setDelay(13);
        LeanTween.moveLocalY(jawaban2, YjawabanOut, 1).setEaseInOutExpo().setDelay(23);
        
        LeanTween.moveLocalY(Soal3, YsoalIn, 1).setEaseOutBounce().setDelay(26f);
        LeanTween.moveLocalY(Soal3, YSoalOut, 1).setEaseInOutExpo().setDelay(39);
        LeanTween.moveLocalY(jawaban3, YjawabanIn, 1).setEaseOutBounce().setDelay(26);
        LeanTween.moveLocalY(jawaban3, YjawabanOut, 1).setEaseInOutExpo().setDelay(39);
        
        LeanTween.moveLocalY(Soal4, YsoalIn, 1).setEaseOutBounce().setDelay(40f);
        //LeanTween.moveLocalY(Soal3, YSoalOut, 1).setEaseInOutExpo().setDelay();
        //LeanTween.moveLocalY(jawaban3, YjawabanIn, 1).setEaseOutBounce().setDelay(40);
        //LeanTween.moveLocalY(jawaban3, YjawabanOut, 1).setEaseInOutExpo().setDelay(39);
        #endregion 
    }


    public void Skor(int i)
    {
        notif = true;
        benarNotif[i].SetActive(notif);
        LeanTween.scale(jawaban[i],ukuranJawaban,0.25f).setLoopPingPong();
        LeanTween.scale(benarNotif[i], ukurannotif, 1f).setLoopPingPong();
        //StartCoroutine(stopanim());
        tambahSkor +=1;
        if (tambahSkor == 1)
        {
            nilai[0].SetActive(true);
        }
        else if ( tambahSkor == 2)
        {
            nilai[1].SetActive(true);
        }
        else if (tambahSkor == 3)
        {
            nilai[2].SetActive(true);
        }
        Destroy(jawaban[i].GetComponent<Button>());
        Destroy(jawabanSalah[i].GetComponent<Button>());
        Destroy(benarNotif[i], 1.5f);

     
    }


    public void JawabSalah(int i)
    {
        notif = true;
        salahNotif[i].SetActive(notif);
        LeanTween.scale(jawabanSalah[i], ukuranJawaban, 0.25f).setLoopPingPong();
        LeanTween.scale(salahNotif[i], ukurannotif, 1f).setLoopPingPong();
        
        Destroy(jawabanSalah[i].GetComponent<Button>());
        Destroy(jawaban[i].GetComponent<Button>());
        Destroy(salahNotif[i], 1.5f);
    }
    //IEnumerator stopanim()
    //{
    //    //for(int j = 0; j<benarNotif.Length; j++) { 
    //    if (notif == true )
    //       {
    //        notif = false;
    //       }
    //    yield return new WaitForSeconds(2);
    //}
}
