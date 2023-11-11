using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPosition : MonoBehaviour
{

    public Transform bodyAnchor;
    public Transform forwardAxis;
    //public float frontalOffset = 0.2f;
    //public Transform leftHandAnchor;
    //public Transform rightHandAnchor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(bodyAnchor.position.x, bodyAnchor.position.y * 0.6f, bodyAnchor.position.z);

        transform.LookAt(forwardAxis);

    }
}
