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
        CheckStick();
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
