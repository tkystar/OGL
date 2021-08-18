using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cosMove : MonoBehaviour
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
        //cosの大きさ
        transform.position = new Vector3(transform.position.x,transform.position.y+cosWave*Mathf.Cos(Time.frameCount/cosRate+1),0);
    }
}
