using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    PlayerMove player;

    //시작 UI 관련
    public GameObject startUI;
    MainMenu start;
    public GameObject startPanel;
    public GameObject howToPlayPanel;

    //사망 UI 관련
    public GameObject DeathUI;
    DeathMenu death;
    public bool isDeath;

    //Pause UI 관련
    public GameObject PauseUI;
    PauseMenu pause;
    public GameObject pauseButtonPanel;
    public GameObject howToPlayPanel_PauseUI;
    public bool isPauseOn;

    //Talk UI 관련
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

    //스테이지 전환 관련
    public int nowStage;
    MainCamara Camara1;

    // Start is called before the first frame update
    void Start()
    {
        tm = GameObject.FindObjectOfType<TalkManager>();
        player = GameObject.FindObjectOfType<PlayerMove>();
        start = startUI.GetComponent<MainMenu>();
        death = DeathUI.GetComponent<DeathMenu>();
        pause = PauseUI.GetComponent<PauseMenu>();

        talkPanel.SetActive(false);
        startPanel.SetActive(true);
        howToPlayPanel.SetActive(false);
        DeathUI.SetActive(false);
        PauseUI.SetActive(false);
        pauseButtonPanel.SetActive(false);
        howToPlayPanel_PauseUI.SetActive(false);

        isPauseOn = false;
        
        Camara1 = GameObject.FindObjectOfType<MainCamara>();

        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //###UI관련
        //Start UI;
        startPanel.SetActive(!start.isClickHowToPlay);
        howToPlayPanel.SetActive(start.isClickHowToPlay);
        if (start.isGameStart)
        {
            startUI.SetActive(false);
            Time.timeScale = 1;
        }
        //Death UI;
        if(death.isClickRestart)
        {
            isDeath = false;
            player.currentHp = player.maxHp;
            DeathUI.SetActive(false);
            death.isClickRestart = false;
        }
        else if (death.isQuit)
        {
            isDeath = false;
            startUI.SetActive(true);
            DeathUI.SetActive(false);
            death.isQuit = false;
            GameOver();
        }
        //Pause UI
        if (Input.GetKeyDown(KeyCode.Escape))   //esc 키 누를시
        {
            isPauseOn = true;
        }
        PauseUI.SetActive(isPauseOn);
        pauseButtonPanel.SetActive(!pause.isClickHowToPlay);
        howToPlayPanel_PauseUI.SetActive(pause.isClickHowToPlay);
        Time.timeScale = isPauseOn ? 0 : 1;
        if (pause.isClickResume)    //일시정지 풀기
        {
            isPauseOn = false;
            pause.isClickResume = false;
        }
        else if (pause.isQuit)
        {
            startUI.SetActive(true);
            isPauseOn = false;
            pause.isQuit = false;
            GameOver();
        }

        //플레이어 사망
        if (player.currentHp == 0)
        {
            Time.timeScale = 0;
            isDeath = true;
            DeathUI.SetActive(true);
        }
    }
    public void StageChange()
    {
        nowStage++;
    }

    public void NPCText(GameObject scanObj)
    {
        scanObject = scanObj;
        InteractiveCode objCode = scanObject.GetComponent<InteractiveCode>();
        Talk(objCode.codeNumber, objCode.isNPC, scanObj);

        talkPanel.SetActive(isTextOn);
    }

    void Talk(int id, bool isNPC, GameObject scanObj)
    {
        string talkData = tm.GetTalk(id, talkIndex);

        if (talkData == null)
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
                    case 102:
                        medicine++;
                        break;
                    case 103:
                    case 104:
                        unicornHorns++;
                        break;
                }
            }
            return;
        }
        talkText.text = talkData;
        isTextOn = true;
        talkIndex++;
    }

    void GameOver()
    {
        print("Game Over");
    }
}
