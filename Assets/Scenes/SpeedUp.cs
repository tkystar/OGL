using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float bairitsu  =1.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x * bairitsu, rb2d.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
