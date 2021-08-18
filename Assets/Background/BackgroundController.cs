using UnityEngine;
using System.Collections;

namespace iwashi
{
public class BackgroundController : MonoBehaviour
{
    public float size;
    Player_Move Player_Move;
    public float bairitsu;
    public GameObject player;

    GameObject a;
    float speed;
    private void Start()
    {
        //a = GameObject.Find("MainCamera");
        size = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        Player_Move=player.GetComponent<Player_Move>();
    }
    void Update()
    {

        transform.position += new Vector3(Player_Move.tide*0.01f * bairitsu, 0, 0);
        
        if (transform.position.x < -size)
        {
            transform.position += new Vector3(size*2, 0, 0);
        }
    }
}
}