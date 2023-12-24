using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject talkPanel;
    public TMP_Text talkText;
    public GameObject scanObject;
    public TalkManager talkManager;
    public bool isAction;
    public int talkIndex;
    public void Action(GameObject scanObj)
    {
        isAction = true;
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc);

        talkPanel.SetActive(isAction);

    }
    void Talk(int id, bool isNpc) //대화가 모두 끝나야 액션이 끝나도록 설정해야함
    {
        string talkData = talkManager.GetTalk(id, talkIndex);
        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0; //이야기끝나면 인덱스 초기화 시켜줘야 다른 오브젝트 대화창 뜰때 0부터 시작함
            return; //함수 강제 종료 역할
        }
        if (isNpc)
        {
            talkText.text = talkData;
        }
        else
        {
            talkText.text = talkData;
        }
        isAction = true;
        talkIndex++; //계속 이어가게 할수있게끔
    }
}
