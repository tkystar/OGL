using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cosSize : MonoBehaviour
{
    public float cosRate;
    public float cosWave;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(1, 1 + cosWave * Mathf.Cos(Time.frameCount / cosRate + 1), 0);
    }
}
