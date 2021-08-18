using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace iwashi
{
public class MoveTest : MonoBehaviour
{
	//public SerialHandler serialHandler;
	public SerialHandler serialHandler;
    // 速度
	//public GameObject Ground;
    //CollisionDetection CollisionDetection;
    Rigidbody2D rb; 
    [SerializeField]float SPEED;
    float defaultSpeed;
    float fighSpeed;
    float highSpeed;
	public Button upBtn;
	public Button downBtn;
	public Button kasokuBtn;
	public Button okBtn;
    public Button homeBtn;
	bool downBtnMapping=false;
	bool upBtnMapping=false;
	bool kasokuBtnMapping=false;
	public GameObject upBtnNumTextObj;
	Text _upBtnNumText;
	public GameObject downBtnNumTextObj;
	Text _downBtnNumText;
	public GameObject kasokuBtnNumTextObj;
	Text _kasokuBtnNumText;
	public Sprite selectBtnImage;
	public Sprite normalBtnImage;
	Image upbtnImage;
	Image downbtnImage;
	Image kasokubtnImage;
	bool _adjustMode;
	bool detareceived;
	public string[] detas;
	public string latestInput;
	public static string downBtnNum;
   public static string upBtnNum;
   public static string kasokuBtnNum;
   public static string sendmessage;
   Player_Move player_move;
    //bool onGround;
	// Use this for initialization
	void Start () {

        //信号を受信したときに、そのメッセージの処理を行う
        serialHandler.OnDataReceived += OnDataReceived;
		//serialHandler.OnDataReceived += OnDataReceived;

	    rb=this.GetComponent<Rigidbody2D>();
        defaultSpeed=SPEED;
        highSpeed=1.5f*SPEED;
		upBtn.onClick.AddListener(upBtnClicked);
		downBtn.onClick.AddListener(downBtnClicked);
		kasokuBtn.onClick.AddListener(kasokuBtnClicked);
		okBtn.onClick.AddListener(OkBtnClicked);
        homeBtn.onClick.AddListener(homeBtnClicked);
		_upBtnNumText=upBtnNumTextObj.GetComponent<Text>();
		_downBtnNumText=downBtnNumTextObj.GetComponent<Text>();
		_kasokuBtnNumText=kasokuBtnNumTextObj.GetComponent<Text>();
		downBtnMapping=false;
	    upBtnMapping=false;
		kasokuBtnMapping=false;
		upbtnImage=upBtn.GetComponent<Image>();
		kasokubtnImage=kasokuBtn.GetComponent<Image>();
		downbtnImage=downBtn.GetComponent<Image>();
		_adjustMode=false;
		detareceived=false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		// 移動処理
		//Move();
		if(!_adjustMode)
		{
			if(!upBtnMapping&&!downBtnMapping&&!kasokuBtnMapping)
			{
			upbtnImage.sprite=normalBtnImage;
			downbtnImage.sprite=normalBtnImage;
			kasokubtnImage.sprite=normalBtnImage;
				if(detareceived)
				{
					//Movealpha();
				}
			}
		
		}

		if(!serialHandler.isNewMessageReceived_)
		{
			//Movealpha("100");
			//rb.velocity=new Vector2(0,0);
		}
		
		
		
	}
     
	
	void Move(string inputdeta)
	{
		
		Vector2 Position = transform.position;
		
		if(inputdeta==upBtnNum)
		{
			rb.velocity=new Vector2(0,1.0f)*SPEED;
		}
		else if(inputdeta==downBtnNum)
		{
			rb.velocity=new Vector2(0,-1.0f)*SPEED;
		}
		else
		{		
			rb.velocity=new Vector2(0,0);
		}
	
		
		
	    
	}
	
	
	void OnDataReceived(string message)
   {
	   
	   detareceived=true;
	   
        //detas = message.Split(new string[]{"\n","\r"}, System.StringSplitOptions.RemoveEmptyEntries);     //

		Debug.Log(message);
		
		for(int i=0;i<detas.Length;i++)
		{
			if(detas[i]==null)
			{				
				detas[i]=detas[i+1];
				
			}
		}

	   if(upBtnMapping)
		{
			upBtnMap(message);
		}
		else if(downBtnMapping)
		{
			downBtnMap(message);
		}
		else if(kasokuBtnMapping)
		{
			kasokuBtnMap(message);
		}
		
		if(!_adjustMode)
		{
			if(!upBtnMapping&&!downBtnMapping)
			{
				Move(message);
			}
		}

              //ゲームスタートしたらの条件つけてもいい。 
            //sendmessage=message;
			//Sendmessage();
			//player_move.Move(sendmessage);
   }
   

   void upBtnClicked()
   {
	   _adjustMode=true;
       upBtnMapping=true;
	   downBtnMapping=false;
	   kasokuBtnMapping=false;
	   Debug.Log("upBtnClicked");
	   upbtnImage.sprite=selectBtnImage;
		downbtnImage.sprite=normalBtnImage;
		kasokubtnImage.sprite=normalBtnImage;
   }
   

   void downBtnClicked()
   {
	   _adjustMode=true;
       downBtnMapping=true;
	   upBtnMapping=false;
	   kasokuBtnMapping=false;
	   Debug.Log("downBtnClicked");
	   downbtnImage.sprite=selectBtnImage;
	   upbtnImage.sprite=normalBtnImage;
	   kasokubtnImage.sprite=normalBtnImage;
   }

   void kasokuBtnClicked()
   {
	   _adjustMode=true;
       kasokuBtnMapping=true;
	   upBtnMapping=false;
	   downBtnMapping=false;
	   Debug.Log("kasokuBtnClicked");
	   kasokubtnImage.sprite=selectBtnImage;
	   upbtnImage.sprite=normalBtnImage;
	   downbtnImage.sprite=normalBtnImage;
   }
   

   void upBtnMap(string message)
   {
	   
		upBtnNum=message;
		_upBtnNumText.text=upBtnNum.ToString();
		upBtnMapping=false;
		

   }

   void downBtnMap(string message)
   {
	   /*
	   Debug.Log("rightBtnMap");
	   //Debug.Log("leftBtnMap");
	   if(serialHandler.isNewMessageReceived_)
		{
			//leftBtnNum=int.Parse(detas[0]);  
			if(detas!=null)
			{
				for(int i=0;i<detas.Length;i++)
				{
					if(detas[i]=="1"||detas[i]=="2")
					{
						rightBtnNum=detas[i];
						_rightBtnNumText.text=rightBtnNum.ToString();
						rightBtnMapping=false;
						return;
					}
				}
				
				
			}
			else
			{
				Debug.Log("else");
			}
			 
		}
		*/

	downBtnNum=message;
	_downBtnNumText.text=downBtnNum.ToString();
	downBtnMapping=false;



   }

   void kasokuBtnMap(string message)
   {
	   
		kasokuBtnNum=message;
		_kasokuBtnNumText.text=kasokuBtnNum.ToString();
		kasokuBtnMapping=false;
		

   }


   void OkBtnClicked()
   {
	   _adjustMode=false;
	   upBtnMapping=false;
	   downBtnMapping=false;
	   kasokuBtnMapping=false;
	   upmapping();
	   downmapping();
	   kasokumapping();
   }

   void homeBtnClicked()
   {
       SceneManager.LoadScene("Title");
   }

   public static string Sendmessage()
   {
       return sendmessage;
   }

   public static string upmapping()
   {
       return upBtnNum;
   }

   public static string downmapping()
   {
       return downBtnNum;
   }

   public static string kasokumapping()
   {
       return kasokuBtnNum;
   }
}

}
