using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDown : MonoBehaviour
{
    public bool second = false;
    bool hold = false;
    public int team; 
    Vector3 lastPosition = Vector3.zero;
    Quaternion startRot;
    public GameObject table;
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
        if (transform.up.y < 0.2f && speed < 0.000000000000000000000000001f && !hold)
        {
            Kill();
        }
    }

    void Kill()
    {
        if (second)
        {
            Destroy(this.gameObject);
            return;
        }
            
        else
        {
            switch (team)
            {
                case 1:
                    //Place on reds table
                    //transform.SetPositionAndRotation(new Vector3(Random.Range(4.8f, 5.28f) - (table.transform.position.x - 5.05f), 0.82f, Random.Range(-0.45f, 0.45f) + (table.transform.position.z - 5.05f)), startRot);
                    transform.SetPositionAndRotation(new Vector3(Random.Range(4.8f, 5.28f), 0.82f, Random.Range(-0.45f, 0.45f)), startRot);
                    gameObject.tag = "Red Hit";
                    break;
                case 2:
                    //Place on blues table
                    //transform.SetPositionAndRotation(new Vector3(Random.Range(-4.8f, -5.28f) + (table.transform.position.x + 5.05f), 0.82f, Random.Range(-0.45f, 0.45f) + (table.transform.position.z + 5.05f)), startRot
                    transform.SetPositionAndRotation(new Vector3(Random.Range(-4.8f, -5.28f), 0.82f, Random.Range(-0.45f, 0.45f)), startRot);
                    gameObject.tag = "Blue Hit";
                    break;
                default:
                    return;
            }
        }
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
