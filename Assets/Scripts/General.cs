using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : MonoBehaviour
{
    public GameObject king, redL, blueL, redP, blueP;
    public GameObject[] redT, blueT, redS, blueS, redH, blueH;
    public GameObject stickR, stickB;
    // Start is called before the first frame update
    void Start()
    {
        redT = GameObject.FindGameObjectsWithTag("Red Target");
        blueT = GameObject.FindGameObjectsWithTag("Blue Target");
        StartCoroutine(CheckStick());
       // StartCoroutine(CheckHit());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CheckStick()
    {
        redS = GameObject.FindGameObjectsWithTag("Red Stick");
        Debug.Log("R = " + redS.Length);
        if (redS.Length == 0 && redP.activeSelf == true)
        {
            redP.SetActive(false);
            blueP.SetActive(true);
          //  yield return new WaitWhile(() => blueH.Length > 0);
            while (blueH.Length > 0)
            {
                blueH = GameObject.FindGameObjectsWithTag("Blue Hit");
                yield return null;
            }
            Instantiate(stickB);
            Debug.Log("wtf b");
        }

        blueS = GameObject.FindGameObjectsWithTag("Blue Stick");
        Debug.Log("B = " + blueS.Length);
        if (blueS.Length == 0 && blueP.activeSelf == true)
        {
            blueP.SetActive(false);
            redP.SetActive(true);
            while(redH.Length > 0)
            {
                redH = GameObject.FindGameObjectsWithTag("Red Hit");
                Debug.Log("loop r");
                yield return null;
            }
            Instantiate(stickR);
            Debug.Log("wtf r");
        }

        StartCoroutine(CheckStick());
    }
/*
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
    */
}
