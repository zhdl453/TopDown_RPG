using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    [Header("대화하나에는 여러 문장이 들어있으므로 string[]사용")]
    Dictionary<int, string[]> talkData;//id / 대사
    void Awake()
    {
        talkData = new Dictionary<int, string[]>(); //초기화 해주기
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        talkData.Add(1, new string[] { "Hi", "Are you new here, huh?" });
        talkData.Add(2, new string[] { "Yo", "Isn't that lake so beautiful, Man?", "Actually, I'm told that there is some secret behind the lake." });
        talkData.Add(100, new string[] { "This is just a box" });
        talkData.Add(200, new string[] { "This looks like a desk that someone has used." });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
        {
            return null; //대화 끝난거임
        }
        else
        {
            return talkData[id][talkIndex]; //딕션너리 타입에서 데이터 꺼내는법
        }

    }
}
