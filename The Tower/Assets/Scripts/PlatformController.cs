using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{

    public Transform finalPosition;
    public float speed;
    private Vector3 beginningPosition;
    private Vector3 thisFinalPosition;
    private float thisSpeed;

    // Start is called before the first frame update
    void Start()
    {

        beginningPosition = transform.position;
        thisFinalPosition = finalPosition.position;
        thisSpeed = speed * 1f;
        
    }

    // Update is called once per frame 
    void Update()
    {
        transform.position = Vector3.Lerp(beginningPosition, thisFinalPosition,
            Mathf.SmoothStep(0f, 1f, Mathf.PingPong(Time.time * thisSpeed/20, 1f)));
    }
}
