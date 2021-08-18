using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace iwashi
{
public class BackGround_Title : MonoBehaviour
{
    public float size;
    //public Player_Move Player_Move;
    public float a;
    public float bairitsu;

    //GameObject a;
    float speed;


    private void Start()
    {
        //a = GameObject.Find("MainCamera");
        size = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;

    }
    void Update()
    {

        transform.position += new Vector3(a * 0.01f * bairitsu, 0, 0);

        if (transform.position.x < -size)
        {
            transform.position += new Vector3(size * 2, 0, 0);
        }
    }
}
}
