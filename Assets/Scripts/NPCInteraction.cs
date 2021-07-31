using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public GameObject pressKeyText;
    public Transform textPos;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressKeyText()
    {
        GameObject text = Instantiate(pressKeyText);
        text.transform.position = textPos.position;
    }
}
