using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    Dictionary<int, QuestData> questList;
    void Awake()
    {
        questList = new Dictionary<int, QuestData>(); //초기화
        GenerateData();
    }
    void GenerateData()
    {
        questList.Add(10, new QuestData("마을사람들과 대화하기", new int[] { 1, 2 })); //퀘스트를 새로 만듦
    }

    public int GetQuestTalkIndex(int id)
    {

        return questId;
    }
}
