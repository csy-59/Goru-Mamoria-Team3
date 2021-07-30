using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayMenu : MonoBehaviour
{
    public bool isMenuBack;
    // Start is called before the first frame update
    void Start()
    {
        isMenuBack = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //HowToPlay
    public void OnClickBack()
    {
        isMenuBack = true;
        print("Back");
    }
}
