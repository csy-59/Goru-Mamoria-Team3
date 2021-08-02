using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //시작 UI 관련
    public GameObject startUI;
    MainMenu start;
    public GameObject startPanel;
    public GameObject howToPlayPanel;

    // Start is called before the first frame update
    void Start()
    {
        start = startUI.GetComponent<MainMenu>();
        startPanel.SetActive(true);
        howToPlayPanel.SetActive(false);

        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //UI관련
        startPanel.SetActive(!start.isClickHowToPlay);
        howToPlayPanel.SetActive(start.isClickHowToPlay);

        if (start.isGameStart)
        {
            startUI.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
