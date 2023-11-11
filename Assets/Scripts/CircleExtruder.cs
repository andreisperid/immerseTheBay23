using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleExtruder : MonoBehaviour
{
    public Transform centerPoint;
    public Transform boundPoint;

    float height = 0;
    float width = 2;

    // Update is called once per frame
    void Update()
    {
        height = boundPoint.localPosition.y;
        width = Vector3.Distance(new Vector3(centerPoint.localPosition.x, 0, centerPoint.localPosition.z), new Vector3(boundPoint.localPosition.x, 0, boundPoint.localPosition.z));

        Debug.Log(height);
        Debug.Log(width);

        transform.localScale = new Vector3(width * 2, height / 2, width * 2);
        transform.localPosition = new Vector3(0, height / 2, 0);
    }
}
