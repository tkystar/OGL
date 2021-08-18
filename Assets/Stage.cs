using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace iwashi
{
public class Stage : MonoBehaviour
{
    float width; //�X�N���[����
    float size;
    public float EnemySpeed; //�G�L�����N�^�[�̃\�N�h

    Rigidbody2D rb2d;
    bool move;
    Player_Move player_move;
    // Start is called before the first frame update
    void Start()
    {
        width = Camera.main.orthographicSize * Screen.width / Screen.height;
        size = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        rb2d = GetComponent<Rigidbody2D>();
        player_move = GameObject.Find("Player").GetComponent<Player_Move>();

        float tide = -1f * player_move.tide/ 3f;

        this.transform.parent = null;
        move = true;

        rb2d.velocity = new Vector3(EnemySpeed * tide, 0, 0);
        //Debug.Log(tide);
    }
    // Update is called once per frame
    void Update()
    {
        /*
        if(this.transform.position.x <= width + size/2 && move == false)
        {
            float tide = -1/3 * player_move.tide;

            this.transform.parent = null;
            move = true;
            
            rb2d.velocity = new Vector3(EnemySpeed * tide, 0, 0);
            Debug.Log(tide);
        }
        */
    }

    
}

}