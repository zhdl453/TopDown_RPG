using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject talkPanel;
    public QuestManager questManager;
    public Image portraitImg;
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
        //Set Talk Data
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);
        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0; //이야기끝나면 인덱스 초기화 시켜줘야 다른 오브젝트 대화창 뜰때 0부터 시작함
            return; //함수 강제 종료 역할
        }
        if (isNpc)
        {
            talkText.text = talkData.Split(":")[0];

            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(":")[1]));
            portraitImg.color = new Color(1, 1, 1, 1);
        }
        else
        {
            talkText.text = talkData;
            portraitImg.color = new Color(1, 1, 1, 0); //알파값을 0으로 해서 안보이게 하면 되지
        }
        isAction = true;
        talkIndex++; //계속 이어가게 할수있게끔
    }
}
