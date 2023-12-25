using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    [Header("대화하나에는 여러 문장이 들어있으므로 string[]사용")]
    Dictionary<int, string[]> talkData;//id / 대사
    Dictionary<int, Sprite> portraitData;//id / 초상화 저장할 딕션너리
    public Sprite[] portraitArr;
    void Awake()
    {
        talkData = new Dictionary<int, string[]>(); //초기화 해주기
        portraitData = new Dictionary<int, Sprite>(); //초기화 해주기
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        talkData.Add(1, new string[] { "Hi:1000", "Are you new here, huh?:2000" }); //구분자와 함께 초상화 Index를 문장 뒤에 추가
        talkData.Add(2, new string[] { "Yo:2000", "Isn't that lake so beautiful, Man?:1000", "Actually, I'm told that there is some secret behind the lake.:2000" });
        talkData.Add(100, new string[] { "This is just a box" });
        talkData.Add(200, new string[] { "This looks like a desk that someone has used." });

        portraitData.Add(1 + 1000, portraitArr[0]);
        portraitData.Add(1 + 2000, portraitArr[1]);
        portraitData.Add(1 + 3000, portraitArr[2]);
        portraitData.Add(1 + 4000, portraitArr[3]);
        portraitData.Add(2 + 1000, portraitArr[4]);
        portraitData.Add(2 + 2000, portraitArr[5]);
        portraitData.Add(2 + 3000, portraitArr[6]);
        portraitData.Add(2 + 4000, portraitArr[7]);
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

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
