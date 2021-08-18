using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score_Fish : MonoBehaviour
{
    //‚±‚¢‚Â‚ª“®‚©‚·ˆ×‚Ì‚â‚Â
    static public int score;
    // Start is called before the first frame update
    void Start()
    {
        
        DelayMethod();
    }

    public GameObject A1;
    public GameObject A2;
    public GameObject A3;
    public GameObject A4;
    public GameObject A5;

    // Update is called once per frame
    void Update()
    {

        

    }

    void DelayMethod()
    {
        print(score);
        if (score >= 10000)
        {
            score -= 10000;
            //Instantiate(A1, new Vector3(0,0,0), Quaternion.identity);
            A1.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            A1.GetComponent<Animator>().SetBool("gogo", true);
            Invoke("DelayMethod", 0.5f);
        }
        else if (score >= 1000)
        {
            score -= 1000;
            A2.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            A2.GetComponent<Animator>().SetBool("gogo", true);
            Invoke("DelayMethod", 0.5f);
        }
        else if (score >= 100)
        {
            score -= 100;
            A3.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            A3.GetComponent<Animator>().SetBool("gogo", true);
            Invoke("DelayMethod", 0.5f);
        }
        else if (score >= 10)
        {
            score -= 10;
            A4.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            A4.GetComponent<Animator>().SetBool("gogo", true);
            Invoke("DelayMethod", 0.5f);
        }
        else if (score >= 1)
        {
            score -= 1;
            A5.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            A5.GetComponent<Animator>().SetBool("gogo", true);
            Invoke("DelayMethod", 0.5f);
        }
        if(score == 0)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("MainScene");
            }
        }
    }
}
