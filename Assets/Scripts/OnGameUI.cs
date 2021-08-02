using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGameUI : MonoBehaviour
{
    public bool isClickPauseButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickPause()
    {
        isClickPauseButton = true;
        print("Pause");
    }
}
