using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace iwashi
{
public class Player_Move : MonoBehaviour
{
    // Start is called before the first frame update
    
    Rigidbody2D rb2d;
    public int life; //体力
    public float power; //一回押したら移動する量
    public float tide; //流れ
    Animator animator;
    float width;
    float height;
    bool muteki;
    public int sakanaMany;
    public UIController uicontroller;
    Transform Stage;
    public GameObject fish;

    public AudioClip sound1;
    AudioSource audioSource;

    float sens1;
    float sens2;
    float sens3;
    public float default_t = 3f;
    float muteki_time = 3f;
    public bool sotoderenai = true;
    [SerializeField]string nowmessage;
    string upmessage="2";
    string downmessage="3";
    string kasokumessage="1";
    string stopmessage="0";
    public SerialHandler_ingame serialHandler_ingame;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        serialHandler_ingame.OnDataReceivedd += OnDataReceivedd;
        Score_Fish.score = 0;
        audioSource = GetComponent<AudioSource>();

        Application.targetFrameRate = 60;
        muteki = false;
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();

        width = Camera.main.orthographicSize * Screen.width / Screen.height;
        height = Camera.main.orthographicSize;
        sakanaMany = 1;
        MutekiTime(default_t);
        //rb=GetComponent<Rigidbody2D>();
        if(sens1 == 0)
        {
            sens1 = 1f;
            sens2 = 1f;
            sens3 = 1f;
        }
        else
        {
            sens1 = GoNext.getSensitivity();
            sens2 = GoNext.getSensitivity2();
            sens3 = GoNext.getSensitivity3();
        }
        
        //upmessage=MoveTest.upmapping();
        //downmessage=MoveTest.downmapping();
    }

    // Update is called once per frame
    void Update()
    {
        int ObjCount = this.transform.childCount;
        Vector3 iu = this.transform.position;
        GameObject[] Fish = new GameObject[ObjCount];
        animator.SetInteger("life", life);

        if(sotoderenai == true)
        {

        }


        Move(nowmessage);
        
        
        if (transform.position.y < -3.8f)
        { 
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        }
        if (transform.position.y > 3.3f)
        {
            if (this.gameObject.tag == "Player")
            {
                transform.position = new Vector3(transform.position.x, 3.3f, 0);
            }
        }



        if (rb2d.velocity.x > -10f)//ここながれ
        {
            if (muteki == false) //無敵時間じゃなかったら
            {
                rb2d.AddForce(new Vector3(tide * sens3, 0, 0));
            }
        }
        

            if (rb2d.velocity.x < 10f)//ここながれ
        {

            if (muteki == false) //無敵時間じゃなかったら
            {
                 //流れの大きさ
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    //一回の移動
                    audioSource.PlayOneShot(sound1);
                    rb2d.velocity = new Vector3(power * sens2, 0, 0);

                }
            }
        }

            if(muteki == true)
        {
            rb2d.velocity = new Vector3(0, 0, 0);
        }

            if(life < 0)
        {
            uicontroller.Gohome();
            muteki = true;
        }

        

        
            if (transform.position.x <= -width) //画面外に出る
        {
            
            life--;
            Destroy(this.transform.transform.GetChild(ObjCount - 1).gameObject);
            MutekiTime(muteki_time);

        }
        else if(transform.position.y >= height){
            
            life--;
            Destroy(this.transform.transform.GetChild(ObjCount - 1).gameObject);
            MutekiTime(muteki_time);
        }

        
        //Debug.Log(ObjCount);
        for (int i=0;i<ObjCount; i++)
        {
            Fish[i] = this.transform.transform.GetChild(i).gameObject;

            if (i % 3 == 0)
            {
                Fish[i].transform.position = iu + new Vector3(-(i + 1) * 0.25f - 0.7f, 0, 0);
                //GameObject made = Instantiate(fish, iu + new Vector3(-(ObjCount), 0, 0), Quaternion.identity, Stage);
            }
            else if (i % 3 == 1)
            {
                Fish[i].transform.position = iu + new Vector3(-(i) * 0.25f - 0.7f, (i) * 0.05f + 0.2f, 0);
                //GameObject made = Instantiate(fish, iu + new Vector3(-(ObjCount - 1), (ObjCount - 1), 0), Quaternion.identity, Stage);
            }
            else
            {
                
                Fish[i].transform.position = iu + new Vector3(-(i-1) * 0.25f - 0.7f, -(i - 1) * 0.05f - 0.2f, 0);
                //GameObject made = Instantiate(fish, iu + new Vector3(-(ObjCount - 2), -(ObjCount - 2), 0), Quaternion.identity, Stage);
            }
        }
    }

    void OnDataReceivedd(string message)
   {
	   
	   //detareceived=true;
	   
        //detas = message.Split(new string[]{"\n","\r"}, System.StringSplitOptions.RemoveEmptyEntries);     //

		
		
        /*
		for(int i=0;i<detas.Length;i++)
		{
			if(detas[i]==null)
			{				
				detas[i]=detas[i+1];
				
			}
		}*/
        nowmessage=message;
        
       //Move(message);

              //ゲームスタートしたらの条件つけてもいい。 
            //sendmessage=message;
			//Sendmessage();
			//player_move.Move(sendmessage);

        if(message.Contains("2"))
        {
            Debug.Log("in");
            transform.Translate(0, 0.2f * sens1, 0);
        }
        else if(message.Contains("3"))
        {
            Debug.Log("in");
            transform.Translate(0, -0.2f * sens1, 0);
        }
        else if(message.Contains("1"))
        {
            
            rb2d.velocity = new Vector3(power * sens2, 0, 0);
            
        }
   }
   


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (this.gameObject.tag == "Player")
        {
            //タグは全角から
            if (col.gameObject.tag == "Enemy")
            {

                if (muteki == false) //無敵じゃなかったら
                {
                    Destroy(col.gameObject);
                    life--;
                    MutekiTime(muteki_time);
                    int ObjCount = this.transform.childCount;
                    Vector3 iu = this.transform.position;
                    GameObject[] Fish = new GameObject[ObjCount];
                    Destroy(this.transform.transform.GetChild(ObjCount - 1).gameObject);
                }

            }

            else if (col.gameObject.tag == "Score")
            {
                //Score_Fish.score += col.gameObject.GetComponent<Point>().ten;
                Destroy(col.gameObject);
                maker();
            }

            else if (col.gameObject.tag == "Goal")
            {
                uicontroller.Clear();

            }
        }

    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Have") //コイツは持ってく系の敵
        {
            //そいつ以外の攻撃を当たらなくする

            if (muteki == false) //無敵じゃなかったら
            {
                this.tag = "Enemy";
                this.transform.position = col.transform.position;
            }

        }

    }



    
    private void MutekiTime(float t)
    {
        this.transform.parent = null;
        muteki = true;
        animator.SetBool("muteki", true);
        this.transform.position = new Vector3(0, 0, 0);
        Invoke("DelayMethod", t);
        
    }

    private void DelayMethod()
    {
        //ここで無敵を切る処理
        animator.SetBool("muteki", false);
        muteki = false;
        this.tag = "Player";
    }

    private void maker()
    {
        int ObjCount = this.transform.childCount;
        Vector3 iu = this.transform.position;
        life++;
        if (ObjCount % 3 == 1)
        {
            GameObject made = Instantiate(fish, iu + new Vector3(0, 0, 0), Quaternion.identity, this.transform);
        }
        else if (ObjCount % 3 == 2)
        {
            GameObject made = Instantiate(fish, iu + new Vector3(0,0, 0), Quaternion.identity, this.transform);
        }
        else
        {
            GameObject made = Instantiate(fish, iu + new Vector3(0, 0, 0), Quaternion.identity, this.transform);
        }
    }

    
    private void Move(string nowmessages) //
	{
        //Debug.Log("out");
        if(nowmessages==upmessage)
        {
            Debug.Log("in");
            transform.Translate(0, 0.05f * sens1, 0);
        }
        else if(nowmessages==downmessage)
        {
            Debug.Log("in");
            transform.Translate(0, -0.05f * sens1, 0);
        }
        else
        {
            
        }
		/*
		Vector2 Position = transform.position;
		
		if(inputdeta=="2")          //本当はif(inputdeta==upBtnNum)でupbtnNUmをマッピングシーンからもらってくる
		{
			//rb.velocity=new Vector2(0,1.0f)*sens1;
            transform.Translate(0, 0.05f * sens1, 0);
		}
		else if(inputdeta=="3")
		{
			//rb.velocity=new Vector2(0,-1.0f)*sens1;
            transform.Translate(0, -0.05f * sens1, 0);
		}
		else
		{		
			rb.velocity=new Vector2(0,0);
		}
	
		
		
        if (Input.GetKey(KeyCode.DownArrow))
        {

            transform.Translate(0, -0.05f * sens1, 0);

        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0.05f * sens1, 0);
        }
        
	    */
	}
	
}
}
