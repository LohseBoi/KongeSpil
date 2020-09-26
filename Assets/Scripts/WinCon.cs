using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinCon : MonoBehaviour
{
    public TextMesh text;
    public GameObject redPlayer, bluePlayer;
    GameObject[] targets;
    Color col;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.transform.Rotate(new Vector3(0, 1, 0), 100 * Time.deltaTime);
        // Debug.Log(transform.up);
        if (transform.up.z > -0.5f && transform.up.z < 0.5f)
        {    
            if (redPlayer.activeSelf)
            {
                targets = GameObject.FindGameObjectsWithTag("Blue Target");
                if (targets.Length > 0)
                    BlueWin();
                else if (targets.Length == 0)
                    RedWin();
            }

            else if (bluePlayer.activeSelf)
            {
                targets = GameObject.FindGameObjectsWithTag("Red Target");
                if (targets.Length > 0)
                    RedWin();
                else if (targets.Length == 0)
                    BlueWin();
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            if (redPlayer.activeSelf)
            {
                targets = GameObject.FindGameObjectsWithTag("Blue Target");
                if (targets.Length > 0)
                    BlueWin();
                else if (targets.Length == 0)
                    RedWin();
            }

            else if (bluePlayer.activeSelf)
            {
                targets = GameObject.FindGameObjectsWithTag("Red Target");
                if (targets.Length > 0)
                    RedWin();
                else if (targets.Length == 0)
                    BlueWin();
            }
        }
    }

    void RedWin()
    {
        text.text = "RED WINS!";
        text.gameObject.SetActive(true);
        StartCoroutine(End());
    }

    void BlueWin()
    {
        text.text = "BLUE WINS!";
        text.gameObject.SetActive(true);
        StartCoroutine(End());
    }
        IEnumerator End()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Menu");
    }
}
