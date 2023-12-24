using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject talkPanel;
    public TMP_Text talkText;
    public GameObject scanObject;
    public bool isAction;
    public void Action(GameObject scanObj)
    {
        if (isAction) //Exit Action
        {
            isAction = false;
        }
        else ////Enter Action
        {
            isAction = true;
            scanObject = scanObj;
            talkText.text = "This name is " + scanObject.name;
        }
        talkPanel.SetActive(isAction);

    }
}
