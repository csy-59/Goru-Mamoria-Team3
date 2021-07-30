using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public bool isGameStart;
    public bool isCilckHowToPlay;
    // Start is called before the first frame update
    void Start()
    {
        isGameStart = false;
        isCilckHowToPlay = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //메인 메뉴
    public void OnClickStart()
    {
        isGameStart = true;
        print("Game Start");
    }
    public void OnClickHowToPlay()
    {
        isCilckHowToPlay = true;
        print("How to Play");
    }
    public void OnClickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    //HowToPlay
    public void OnClickBack()
    {
        isCilckHowToPlay = false;
        print("Back");
    }
}
