using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TMP_Text questName;
    public Animator talkPanel;
    public Animator portraitAnim;
    public QuestManager questManager;
    public Image portraitImg;
    public TypeEffect talk;
    public GameObject scanObject;
    public TalkManager talkManager;
    public bool isAction;
    public int talkIndex;
    public Sprite prevportrait;
    public AudioSource completeSound;

    void Start()
    {
        questName.text = $"Quest: {questManager.CheckQuest()}";
    }
    public void Action(GameObject scanObj)
    {
        isAction = true;
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc);

        talkPanel.SetBool("isShow", isAction);

    }
    void Talk(int id, bool isNpc) //대화가 모두 끝나야 액션이 끝나도록 설정해야함
    {
        int questTalkIndex = 0;
        string talkData = "";
        //Set Talk Data
        if (talk.isAnim)
        {
            talk.SetMsg("");
            return; //아래쪽 실행시키면 안되니까
        }
        else
        {
            questTalkIndex = questManager.GetQuestTalkIndex(id);
            talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);
        }

        //End Talk
        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0; //이야기끝나면 인덱스 초기화 시켜줘야 다른 오브젝트 대화창 뜰때 0부터 시작함

            questName.text = $"Quest: {questManager.CheckQuest(id)}";
            if (questManager.CheckQuest(id) == "All completed!")
            {
                completeSound.Play();
            }


            return; //함수 강제 종료 역할
        }
        if (isNpc)
        {
            talk.SetMsg(talkData.Split(":")[0]);
            //Show Portrait
            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(":")[1]));
            portraitImg.color = new Color(1, 1, 1, 1);
            //Animation Portrait
            if (prevportrait != portraitImg.sprite)
            {
                portraitAnim.SetTrigger("doEffect");
                prevportrait = portraitImg.sprite;
            }

        }
        else
        {
            talk.SetMsg(talkData);
            portraitImg.color = new Color(1, 1, 1, 0); //알파값을 0으로 해서 안보이게 하면 되지
        }
        isAction = true;
        talkIndex++; //계속 이어가게 할수있게끔
    }
}
