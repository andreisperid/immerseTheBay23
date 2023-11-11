using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeSelector : MonoBehaviour
{


    public float frontOffset;
    // TODO: make object float

    public Transform userHead;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, userHead.position.y * 0.75f, frontOffset);
        
    }
}
