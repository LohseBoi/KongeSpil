using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnobGrav : MonoBehaviour
{
    public double grav = 0.1;
    public TextMesh _out;

    // Start is called before the first frame update
    void Start()
    {
        _out.text = grav.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Add(float d)
    {
        grav += d;
        grav = System.Math.Round(grav, 2);
        if (grav < 0.1) grav = 0.1;
        else if (grav > 20) grav = 20;
        _out.text = grav.ToString();
    }
    public void Sel(float d)
    {
        grav = d;
        _out.text = grav.ToString();
    }
}
