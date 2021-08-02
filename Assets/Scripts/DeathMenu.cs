using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    public bool isClickRestart;
    public bool isQuit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickRestart()
    {
        isClickRestart = true;
        print("Restart");
    }

    public void OnClickQuit()
    {
        isQuit = true;
        print("Quit");
    }
}
