using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
     public Transform Target;
    
    void OnTriggerEnter(Collider col)  // 트리거에 충돌이 되었을 때 호출
    {
        if (col.gameObject.tag == "Player") 
        {
            col.transform.position = Target.position; // 부딪힌 객체를 타겟의 위치
            StartCoroutine(FadeOut()); 
            StartCoroutine(FadeIn());
        }
    }
    ///fade in/out
    public Image fadeImg; // fade에 쓸 이미지
    public float fadeTime; //화면이 변할 시간
    /*public bool fadeout;
    public bool fadein;

    private bool isPlaying = false;

    private void Update()
    {
        if (fadeout == true && isPlaying == false) //페이드아웃을 원할 때
        {
            StartCoroutine(FadeOut());
        }
        else if (fadeout == false && fadein == true) //페이드인을 원할 때
        {
            StartCoroutine(FadeIn());
        }
    }*/
    IEnumerator FadeOut()
    {
        fadeImg.gameObject.SetActive(true);
        //isPlaying = true;
        Color tempColor = fadeImg.color;
        tempColor.a = 0f;
        while (tempColor.a < 1f)
        {
            tempColor.a += Time.deltaTime / fadeTime;
            fadeImg.color = tempColor;

            if (tempColor.a >= 1f)
            {
                tempColor.a = 1f;
            }
            yield return null;
        }
        //fadeout = false;
    }
    IEnumerator FadeIn()
    {
        Color tempColor = fadeImg.color;
        while (tempColor.a > 0f)
        {
            tempColor.a -= Time.deltaTime / fadeTime;
            fadeImg.color = tempColor;

            if (tempColor.a <= 0f)
            {
                tempColor.a = 0f;
                fadeImg.color = tempColor;
            }
            yield return null;
        }
        fadeImg.gameObject.SetActive(false);
        //fadein = false;
        //isPlaying = false;
    }
}
