using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkUp : MonoBehaviour
{
    public bool red;
    GameObject[] targets;
    Vector3 startVR, startT, startS;
    public GameObject table, sticks;
    // Start is called before the first frame update
    void Start()
    {
        if (red)
        {
            targets = GameObject.FindGameObjectsWithTag("Red Target");
        }
            
        else if (!red)
        {
            targets = GameObject.FindGameObjectsWithTag("Blue Target");
        }

        startVR = transform.position;
        startT = table.transform.position;
        startS = sticks.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            if (red)
            {
                sticks = GameObject.FindGameObjectWithTag("Red Stick");
            }
            else
            {
                sticks = GameObject.FindGameObjectWithTag("Blue Stick");
            }

            List<float> locs = new List<float>();

            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].transform.position.x > -3 && targets[i].transform.position.x < 3)
                {
                    locs.Add(targets[i].transform.position.x);
                }
            }

            locs.Sort(); //First number if positive, last if negative

            if (locs.Count == 0)
            {
                transform.position = startVR;
                table.transform.position = startT;
                sticks.transform.position = startS;
                return;
            }
            else if(Mathf.Sign(locs[0]) == 1)
            {
                transform.position = new Vector3(locs[0] + 1, transform.position.y, transform.position.z);
                table.transform.position = new Vector3(startT.x - (startVR.x - transform.position.x), startT.y, startT.z);
                sticks.transform.position = new Vector3(startS.x - (startVR.x - transform.position.x), startS.y, startS.z);
            }
            else
            {
                transform.position = new Vector3(locs[locs.Count - 1] - 1, transform.position.y, transform.position.z);
                table.transform.position = new Vector3(startT.x + (transform.position.x - startVR.x), startT.y, startT.z);
                sticks.transform.position = new Vector3(startS.x + (transform.position.x - startVR.x), startS.y, startS.z);
            }
        }
        else
        {
            transform.position = startVR;
            table.transform.position = startT;
            sticks.transform.position = startS;
        }
    }
}
