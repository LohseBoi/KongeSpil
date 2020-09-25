using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnobGrav : MonoBehaviour
{
    public double grav = 0.1, dif;
    public TextMesh _out;

    // Start is called before the first frame update
    void Start()
    {
        dif = transform.rotation.z;
    }

    // Update is called once per frame
    void Update()
    {
        grav = System.Math.Round(transform.rotation.z - dif, 2);
        _out.text = grav.ToString();
    }
}
