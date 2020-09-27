using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KnobGrav : MonoBehaviour
{
    public double grav = 1;
    public TextMesh _out;
    Scene currentScene;
    BoxCollider my;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        my = FindObjectOfType<BoxCollider>();
        _out.text = grav.ToString();
        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScene.name != "Menu")
        {
            Physics.gravity = new Vector3(0, ((float)grav * 9.8f) * -1f, 0);
            Destroy(this.gameObject);
        }
    }
    public void Add(float d)
    {
        grav += d;
        grav = System.Math.Round(grav, 2);
        if (grav < 0.1) grav = 0.1;
        else if (grav > 5) grav = 5;
        _out.text = grav.ToString();
    }
    public void Sel(float d)
    {
        grav = d;
        grav = System.Math.Round(grav, 2);
        _out.text = grav.ToString();
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "KING")
        {
            Destroy(player);
            Destroy(my);
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            DontDestroyOnLoad(this.gameObject);
            SceneManager.LoadScene("SampleScene");
        }
    }
}
