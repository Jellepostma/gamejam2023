using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public float inflation = 0f; // 0 to 1
    public float deflationSpeed = 0.025f;
    public float inflationSpeed = 0.05f;

    void Update()
    {
        inflation = Mathf.Clamp01(inflation - deflationSpeed * Time.deltaTime);
    }
    

    public  void Inflate()
    {
        inflation = Mathf.Clamp01(inflation + inflationSpeed * Time.deltaTime);
    }
}
