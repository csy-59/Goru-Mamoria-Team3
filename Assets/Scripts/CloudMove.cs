using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    // 시작 지점, 끝 지점
    public Transform startPos;
    public Transform endPos;

    // 도착할 지점
    public Transform desPos;

    // 발판 속도
    public float speed;

    void Start()
    {
        // 시작 지점 -> 끝 지점
        transform.position = startPos.position;
        desPos = endPos;
    }

    void FixedUpdate()
    {
        // 이동
        transform.position = Vector2.MoveTowards(transform.position, desPos.position, Time.deltaTime * speed);

        // 만약 목적지까지 도착했을 때, 목적지가 끝지점이면 시작 지점으로 바꾸면 반대면 반대로
        if (Vector2.Distance(transform.position, desPos.position) <= 0.05f)
        {
            if (desPos == endPos) desPos = startPos;
            else desPos = endPos;
        }
    }
}

