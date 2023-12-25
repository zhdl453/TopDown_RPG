using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex; //퀘스트 대화 순서를 맞추기 위한 변수.GenerateData()에 있는 NPC id 순서를 가지고 오기위해 쓰는 변수임
    public GameObject[] questObject; //퀘스트 오브젝트를 저장할 변수 생성해줌
    Dictionary<int, QuestData> questList;
    void Awake()
    {
        questList = new Dictionary<int, QuestData>(); //초기화
        GenerateData();
    }
    void GenerateData()
    {
        questList.Add(10, new QuestData("Let's talk to neighbors", new int[] { 1, 2 })); //퀘스트를 새로 만듦
        questList.Add(20, new QuestData("Find coin for ludo", new int[] { 500, 2 })); //퀘스트를 새로 만듦
        questList.Add(30, new QuestData("All completed!", new int[] { 0 })); //퀘스트를 새로 만듦
    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex; //퀘스트번호 + 퀘스트 대화순서 = 퀘스트 대화 id
    }
    public string CheckQuest(int id) //대화 진행을 위해 퀘스트 대화순서를 올리는 함수 생성(대화가 끝이 났을떄)
    {
        //Next Talk Target
        if (id == questList[questId].npcId[questActionIndex])
        {
            questActionIndex++;
        }
        //Control Quest Object
        ControlObject();
        //Talk Complete & Next Quest
        if (questActionIndex == questList[questId].npcId.Length) //퀘스트 대화순서가 끝에 도달했을때 퀘스트 번호 증가
        {
            NextQuest();
        }
        return questList[questId].questName;

    }
    public string CheckQuest() //오버로딩
    {
        return questList[questId].questName;
    }
    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0; //다시 0으로 초기화
    }

    void ControlObject()
    {
        switch (questId)
        {
            case 10: //마을사람들과 대화하기
                if (questActionIndex == 2)//루도랑 대화끝나면 퀘스트액션인덱스 2로 변하고 코인뜨게 만듦
                    questObject[0].SetActive(true);
                break;
            case 20: //루도의 동전 찾아주기
                if (questActionIndex == 1) //동전 다 먹었으면 퀘스트액션인덱스 1로 변하고 코인 안뜨게
                    questObject[0].SetActive(false);
                break;
        }
    }
}
