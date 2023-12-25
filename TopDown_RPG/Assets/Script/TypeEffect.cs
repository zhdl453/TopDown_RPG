using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypeEffect : MonoBehaviour
{
    public string targetMsg;
    public GameObject EndCursor;
    public int CharPerSeconds; //글자 재생 속도를 위한 변수
    public TMP_Text msgText;
    public int index;
    float interval;

    public void Awake()
    {
        msgText = GetComponent<TMP_Text>(); //초기화 해주기
    }
    public void SetMsg(string msg)
    {
        targetMsg = msg;
        EffectStart();
    }

    // Update is called once per frame
    void EffectStart()
    {
        msgText.text = ""; //시작할땐 공백처리
        index = 0;
        EndCursor.SetActive(false);
        //1/CharPerSeconds = 1글자가 나오는 딜레이
        interval = 1.0f / CharPerSeconds;
        Debug.Log(interval);
        Invoke("Effecting", interval); //시간차 호출을 위한 Invoke()함수 쓰기
    }
    void Effecting()
    {
        if (msgText.text == targetMsg)
        {
            EffectEnd();
            return; //이래야 재귀함수 안돌고 끝남
        }
        msgText.text += targetMsg[index]; //문자열도 배열처럼 char값에 접근 가능
        index++;

        Invoke("Effecting", interval);
    }
    void EffectEnd()
    {
        EndCursor.SetActive(true);
    }
}
