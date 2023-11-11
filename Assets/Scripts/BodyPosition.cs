using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPosition : MonoBehaviour
{

    public Transform userHead;
    public float frontOffset;
    public float heightProportion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, userHead.position.y * heightProportion, frontOffset);
    }
}
