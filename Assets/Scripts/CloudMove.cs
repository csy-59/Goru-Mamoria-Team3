using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    public Transform desPos;
    public float speed;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, desPos.position, Time.deltaTime * speed);
    }
    /*   void Update()
        {
            float h = Input.GetAxis("Horizontal");

            Vector2 jumpVelocity = new Vector2(speed, 0);

      }*/
}
