using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypeEffect : MonoBehaviour
{
    public bool isAnim; //애니메이션 실행 판단을 위한 플래그 변수 생성;
    public GameObject EndCursor;
    public int CharPerSeconds; //글자 재생 속도를 위한 변수

    AudioSource audioSource;
    TMP_Text msgText;
    public int index;
    string targetMsg;
    float interval;


    private void Awake()
    {
        msgText = GetComponent<TMP_Text>(); //초기화 해주기
        audioSource = GetComponent<AudioSource>();
    }
    public void SetMsg(string msg)
    {
        if (isAnim) //플래그 변수를 이요하여 분기점 로직 작성
        {
            msgText.text = targetMsg; //그냥 여기서 글자 채워주고 End시키기
            CancelInvoke(); //돌고있는 인보크가 꺼짐
            EffectEnd();
        }
        else
        {
            targetMsg = msg;
            EffectStart();
        }
    }
    void EffectStart()
    {
        msgText.text = ""; //시작할땐 공백처리
        index = 0;
        EndCursor.SetActive(false);
        //1/CharPerSeconds = 1글자가 나오는 딜레이
        interval = 1.0f / CharPerSeconds;
        isAnim = true;
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
        //Sound(띄어쓰기랑 쩜은 사운드 안나오게)
        if (targetMsg[index] != ' ' || targetMsg[index] != '.')
        {
            audioSource.Play();
        }

        index++;

        Invoke("Effecting", interval);
    }
    void EffectEnd()
    {
        isAnim = false;
        EndCursor.SetActive(true);
    }
}
