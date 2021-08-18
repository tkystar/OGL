using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace iwashi{
public class MoveSpeed : MonoBehaviour
{
    public float speed;
  // public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
       //player_Move=player.GetComponent<Player_Move>();
    }

    // Update is called once per frame
    void Update()
    {
       // speed = Player_Move.tide * 0.01f;
        transform.position += new Vector3(speed, 0, 0);
    }
}
}