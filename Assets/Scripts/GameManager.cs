using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameObject player;

    //기본(스타트) UI 관련
    public GameObject startUI;
    MainMenu start;
    public GameObject startPanel;
    public GameObject howToPlayPanel;

    //UI 텍스트 관련
    public GameObject talkPanel;
    public Text talkText;
    GameObject scanObject;
    public bool isTextOn = false;
    TalkManager tm;
    int talkIndex;

    //아이템 관련
    public int Doll = 0;            //layer 15
    public int unicornHorns = 0;    //layer 16
    public int candle = 0;          //layer 17
    public int medicine = 0;        //layer 18

    // Start is called before the first frame update
    void Start()
    {
        talkPanel.SetActive(false);
        tm = GameObject.FindObjectOfType<TalkManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        start = startUI.GetComponent<MainMenu>();
        startPanel.SetActive(true);
        howToPlayPanel.SetActive(false);

        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //UI관련
        startPanel.SetActive(!start.isCilckHowToPlay);
        howToPlayPanel.SetActive(start.isCilckHowToPlay);

        if (start.isGameStart)
        {
            startUI.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void NPCText(GameObject scanObj)
    {
        
        scanObject = scanObj;
        InteractiveCode objCode = scanObject.GetComponent<InteractiveCode>();
        Talk(objCode.codeNumber, objCode.isNPC, scanObject);

        talkPanel.SetActive(isTextOn);
    }

    void Talk(int id, bool isNPC, GameObject scanObj)
    {
        string talkData = tm.GetTalk(id, talkIndex);

        if(talkData == null)
        {
            isTextOn = false;
            talkIndex = 0;
            if (!isNPC)
                Destroy(scanObj);
            else
            {
                switch (id)
                {
                    case 100:
                        candle++;
                        break;
                    case 101:
                        medicine++;
                        break;
                    case 102:
                        medicine++;
                        break;
                    case 103:
                    case 104:
                        unicornHorns++;
                        candle++;
                        break;
                }
            }
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
