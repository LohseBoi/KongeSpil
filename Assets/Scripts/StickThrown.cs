using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickThrown : MonoBehaviour
{

    Vector3 lastPosition = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float speed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
        if (transform.position.y <= -0.8f && speed < 0.001)
        {
            Destroy(this.gameObject);
        }
    }
}
