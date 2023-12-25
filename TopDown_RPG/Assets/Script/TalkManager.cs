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
    void GenerateData()
    {
        talkData.Add(1, new string[] { "Hi:1000", "Are you new here, huh?:2000", "Go look around more if you want:1000" }); //구분자와 함께 초상화 Index를 문장 뒤에 추가
        talkData.Add(2, new string[] { "Yo:2000", "Isn't that lake so beautiful, Man?:1000", "Actually, I'm told that there is some secret behind the lake.:2000" });
        talkData.Add(100, new string[] { "This is just a box" });
        talkData.Add(200, new string[] { "This looks like a desk that someone has used." });

        //Quest Talk
        talkData.Add(1 + 10, new string[] { "Hello..:1000", "I heard that there was an amazing story in this town:2000", "Lodo will tell you about the story:1000" });
        talkData.Add(2 + 11, new string[] { "Hey:1000", "Did you come to listen to a story of the lake?:2000", "then, I could use your help to do some work:1000", "I'd like you to pick up the coins that have dropped around my house:2000" });
        talkData.Add(1 + 20, new string[] { "Ludo's coin?:1000", "God! he always lose his stuff!:4000", "I gotta have a bone to pick with him:4000" });
        talkData.Add(2 + 20, new string[] { "Please Get me back my coin..:2000" });
        talkData.Add(500 + 20, new string[] { "Coin has been found." });
        talkData.Add(2 + 21, new string[] { "Woah..Thank you for finding the coin..:3000" });
        //1000:Normal, 2000:Speak, 3000:Happy, 4000:Angry,
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
    {//ContainsKey():딕션너리에 키가 존재하는지 검사
        if (!talkData.ContainsKey(id))
        {//해당퀘스트 진행순서 대사가 없을때, 퀘스트 맨 처음 대사를 가지고 온다.
            if (!talkData.ContainsKey(id - id % 10))//퀘스트 맨 처음 대사마저 없을때(책상이나 상자처럼), 기본 대사를 가지고 오면 된다(퀘스트번호 제거후재탐색)
            {//Get First Talk
                return GetTalk(id - id % 100, talkIndex);
            }
            else//Get First Quest Talk
            {
                return GetTalk(id - id % 10, talkIndex);
            }
        }
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
