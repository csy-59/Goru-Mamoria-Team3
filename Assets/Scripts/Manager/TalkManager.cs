using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    // Start is called before the first frame update
    void Start()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] {
            "안녕! 난 유니콘이야!\n 넌 여기가 처음이구나!",
            "정말 반가워!",
            "내게 유니콘 뿔을 찾아줄 수 있겠니?",
        });
        talkData.Add(100, new string[] { "상자이다.", "양초가 들어있다!" });
        talkData.Add(101, new string[] { "상자이다.", "물약이 들어있다!" });
        talkData.Add(102, new string[] { "상자이다.", "물약이 들어있다!" });
        talkData.Add(103, new string[] { "상자이다.", "유니콘 뿔이 들어있다!" });
        talkData.Add(104, new string[] { "상자이다.", "유니콘 뿔이 들어있다!" });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
        {
            return null;
        }
        else
        {
            return talkData[id][talkIndex];
        }
    }
}
