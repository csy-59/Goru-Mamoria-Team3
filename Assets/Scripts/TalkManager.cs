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
        talkData.Add(1000, new string[] { "안녕! 난 유니콘이야!\n이곳은 처음이구나!",
            "반가워!! 이곳은 행복한 꿈의 나라야!\n아주 즐거운 곳이지!",
            "그게 문제가 아니지...",
            "초면에 정말 미안한데 혹시 내 뿔을 가져다 줄 수 있겠니...?",
        });
        talkData.Add(100, new string[] { "상자이다.", "양초가 들어있다!" });
        talkData.Add(101, new string[] { "상자이다.", "물약이 들어있다!" });
        talkData.Add(102, new string[] { "상자이다.", "물약이 들어있다!" });
        talkData.Add(103, new string[] { "상자이다.", "유니콘 뿔이 들어있다!" });
        talkData.Add(104, new string[] { "상자이다.", "유니콘 뿔이 들어있다!" });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if(talkIndex == talkData[id].Length)
        {
            return null;
        }
        else
        {
            return talkData[id][talkIndex];
        }
    }
}
