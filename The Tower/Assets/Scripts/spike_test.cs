using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike_test : MonoBehaviour
{
    // Start is called before the first frame updat

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime);
     
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("OutOfBound"))
        {
            gameObject.SetActive(false);
        }
    }

}
