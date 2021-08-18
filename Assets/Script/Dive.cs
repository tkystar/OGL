using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace iwashi
{
public class Dive : MonoBehaviour
{
    float preX;
    float preY;
    float X;
    float Y;
    Transform Player;
    bool go;
    Stage Stage;
    float EnemySpeed;
    float t;
    float thisX;
    float thisY;
    float sinpuku;
    float akusin;
    float prethisX;
    Vector3 a;
    float height;
    float width;
    // Start is called before the first frame update
    void Start()
    {
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
        Player = GameObject.Find("Player").transform;
        Stage = this.GetComponent<Stage>();
        EnemySpeed = -Stage.EnemySpeed;
        t = 0;

    }

    // Update is called once per frame
    void Update()
    {
        float XX = this.transform.position.x - Player.position.x;
        //float X = this.transform.position.y - pre;
        float YY = this.transform.position.y - Player.position.y;

        if (YY - XX < -6)
        {
            go = false;
        }
        else if (YY - XX > 0 && go == false && akusin * t < Mathf.PI)
        {
            a = new Vector3(-EnemySpeed, 0, 0);
            //this.GetComponent<Rigidbody2D>().velocity;
            this.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            go = true;
            X = Player.transform.position.x;
            Y = Player.transform.position.y;
            thisX = this.transform.position.x;
            thisY = this.transform.position.y;
            EnemySpeed = Mathf.Abs(this.transform.position.x - prethisX) / 2;
            sinpuku = Mathf.Abs(Player.transform.position.y - this.transform.position.y);
            if (sinpuku == 0) go = false;
            akusin = Mathf.Abs(Mathf.Asin(Mathf.Abs(EnemySpeed / sinpuku)));

        }
        
        prethisX = this.transform.position.x;

        if (go == true)
        {
            t += 1;
            if (akusin * t >= Mathf.PI / 2)
            {
                transform.position = new Vector3(thisX - sinpuku * 2 + sinpuku * Mathf.Sin(akusin * t), thisY - sinpuku + Mathf.Abs(sinpuku * Mathf.Cos(akusin * t)), 0);
            }
            if (akusin * t < Mathf.PI/2)
            {
                transform.position = new Vector3(thisX - sinpuku * Mathf.Sin(akusin * t), thisY - sinpuku + Mathf.Abs(sinpuku * Mathf.Cos(akusin * t)), 0);
            }
            
            /*
            else if (prethisX == this.transform.position.x)
            {
                go = false;
            }
            */

            if (akusin*t > Mathf.PI)
            {
                go = false;
                this.GetComponent<Rigidbody2D>().velocity = a;
            }
        }
    }
}
}