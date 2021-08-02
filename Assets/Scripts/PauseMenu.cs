using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool isClickResume;
    public bool isClickHowToPlay;
    public bool isQuit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onClickResume()
    {
        isClickResume = true;
        print("Resume");
    }
    public void onClickHowToPlay()
    {
        isClickHowToPlay = true;
        print("How to Play");
    }
    public void OnClickBack()
    {
        isClickHowToPlay = false;
        print("Back");
    }

    public void OnClickQuit()
    {
        isQuit = true;
        print("Quit");
    }
}
