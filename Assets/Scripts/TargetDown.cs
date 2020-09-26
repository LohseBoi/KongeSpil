using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDown : MonoBehaviour
{
    public bool second = false;
    bool hold = false;
    public int team; //
    Vector3 lastPosition = Vector3.zero;
    Quaternion startRot;
    // Start is called before the first frame update
    void Start()
    {
        startRot = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float speed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
        if (transform.up.y < 0.2 && speed < 0.000000000000000000000000001 && !hold)
        {
            Kill();
        }
    }

    void Kill()
    {
        if (second)
            Destroy(this.gameObject);
        else
        {
            switch (team)
            {
                case 1:
                    //Place on reds table
                    transform.SetPositionAndRotation(new Vector3(Random.Range(3.32f, 4.21f), 0.9f, Random.Range(1.255f, 1.76f)), startRot);
                    break;
                case 2:
                    //Place on blues table
                    break;
                default:
                    return;
            }
        }
        gameObject.tag = "Red Hit";
    }

    void Stand()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        transform.SetPositionAndRotation(transform.position, startRot);
        gameObject.tag = "Red Target";
        second = true;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
            hold = true;
        if (col.gameObject.CompareTag("Layer"))
            Stand();
    }
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
            hold = false;
    }
}
