using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionText : MonoBehaviour
{
    public Transform target;
    private Camera camera1;

    // Start is called before the first frame update
    void Start()
    {
        camera1 = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = camera1.WorldToScreenPoint(new Vector3(target.position.x, target.position.y, target.position.z));

        transform.position = new Vector3(screenPos.x, screenPos.y, screenPos.z);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
