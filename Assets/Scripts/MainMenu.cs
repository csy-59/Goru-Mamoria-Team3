using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public bool isGameStart;
    public bool isClickHowToPlay;

    // Start is called before the first frame update
    void Start()
    {
        isGameStart = false;
        isClickHowToPlay = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickStart()
    {
        isGameStart = true;
        print("Game Start");
    }
    public void onClickHowToPlay()
    {
        isClickHowToPlay = true;
        print("How to Play");
    }
    public void onClickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OnClickBack()
    {
        isClickHowToPlay = false;
        print("Back");
    }
}
