using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : MonoBehaviour
{
    public GameObject king, redL, blueL, redP, blueP;
    public GameObject[] redT, blueT, redS, blueS, redH, blueH;
    public GameObject stickR, stickB;
    bool turnRed = true, turnBlue = true;
    // Start is called before the first frame update
    void Start()
    {
        redT = GameObject.FindGameObjectsWithTag("Red Target");
        blueT = GameObject.FindGameObjectsWithTag("Blue Target");

       // CheckStick();
        StartCoroutine(CheckHit());
    }

    // Update is called once per frame
    void Update()
    {
        redT = GameObject.FindGameObjectsWithTag("Red Target");
        blueT = GameObject.FindGameObjectsWithTag("Blue Target");

        CheckStick();
        CheckMid();
    }

    void CheckStick()
    {
        redH = GameObject.FindGameObjectsWithTag("Red Hit");
        blueH = GameObject.FindGameObjectsWithTag("Blue Hit");
       

        redS = GameObject.FindGameObjectsWithTag("Red Stick");
        blueS = GameObject.FindGameObjectsWithTag("Blue Stick");

        if (redS.Length == 0 && redP.activeSelf == true)
        {
            if (turnBlue)
            {
                Debug.Log("Shift to blue");
                redP.SetActive(false);
                blueP.SetActive(true);
                turnRed = false;
            }
            else if (redH.Length == 0)
            {
                turnBlue = true;
                Instantiate(stickR);
            }
        }
        else if (blueS.Length == 0 && blueP.activeSelf == true)
        {
            if (turnRed)
            {
                Debug.Log("Shift to red");
                blueP.SetActive(false);
                redP.SetActive(true);
                turnBlue = false;
            }
            else if (blueH.Length == 0)
            {
                turnRed = true;
                Instantiate(stickB);
            }
        }
    }

    void CheckMid()
    {
        bool red = false, blue = false;
        //Red
        if (redP.activeSelf == true)
        {
            for (int i = 0; i < redT.Length; i++)
            {
                if (redT[i].transform.position.x > -3.1 && redT[i].transform.position.x < 0)
                {
                    red = true;
                }
            }

            if (red)
            {
                foreach (GameObject g in blueT)
                {
                    //g.SetActive(false);
                    g.GetComponent<Rigidbody>().isKinematic = true;
                    g.GetComponent<BoxCollider>().enabled = false;
                    g.GetComponent<MeshRenderer>().enabled = false;
                }
            }
            else if (!red)
            {
                foreach (GameObject g in blueT)
                {
                    //g.SetActive(true);
                    g.GetComponent<BoxCollider>().enabled = true;
                    g.GetComponent<MeshRenderer>().enabled = true;
                    g.GetComponent<Rigidbody>().isKinematic = false;
                }
            }
        }


        //Blue
        if (blueP.activeSelf == true)
        {
            for (int i = 0; i < blueT.Length; i++)
            {
                if (blueT[i].transform.position.x > 0 && blueT[i].transform.position.x < 3.1)
                {
                    blue = true;
                }
            }
            if (blue)
            {
                foreach (GameObject g in redT)
                {
                    //g.SetActive(false);
                    g.GetComponent<Rigidbody>().isKinematic = true;
                    g.GetComponent<BoxCollider>().enabled = false;
                    g.GetComponent<MeshRenderer>().enabled = false;
                }
            }
            else if (!blue)
            {
                foreach (GameObject g in redT)
                {
                    //g.SetActive(true);
                    g.GetComponent<BoxCollider>().enabled = true;
                    g.GetComponent<MeshRenderer>().enabled = true;
                    g.GetComponent<Rigidbody>().isKinematic = false;
                }
            }
        }
        
    }

    IEnumerator CheckHit()
    {
        redH = GameObject.FindGameObjectsWithTag("Red Hit");
        if (redH.Length > 0 && redP.activeSelf == true)
            blueL.SetActive(true);
        else
            blueL.SetActive(false);

        blueH = GameObject.FindGameObjectsWithTag("Blue Hit");
        if (blueH.Length > 0 && blueP.activeSelf == true)
            redL.SetActive(true);
        else
            redL.SetActive(false);
        yield return new WaitForSeconds(1);
        
        StartCoroutine(CheckHit());
    }
}
