using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //UI 텍스트 관련
    public GameObject talkPanel;
    public Text talkText;
    GameObject scanObject;
    public bool isTextOn = false;
    TalkManager tm;
    int talkIndex;

    // Start is called before the first frame update
    void Start()
    {
        talkPanel.SetActive(false);
        tm = GameObject.FindObjectOfType<TalkManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NPCText(GameObject scanObj)
    {
        
        scanObject = scanObj;
        InteractiveCode objCode = scanObject.GetComponent<InteractiveCode>();
        Talk(objCode.codeNumber, objCode.isNPC);
        
        talkPanel.SetActive(isTextOn);
    }

    void Talk(int id, bool isNPC)
    {
        string talkData = tm.GetTalk(id, talkIndex);

        if(talkData == null)
        {
            isTextOn = false;
            talkIndex = 0;
            return;
        }

        if(isNPC)
        {
            talkText.text = talkData;
        }
        else
        {
            talkText.text = talkData;
        }

        isTextOn = true;
        talkIndex++;
    }

}
