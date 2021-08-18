using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace iwashi
{
public class UIController : MonoBehaviour
{
    public Text text;
    public float score;
    public int scoreRate;
    public Text GameOver;
    public Text sakana;
    public Text text_2;
    bool gameover;
    Player_Move Player_Move;
    int sakanaMany;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        Player_Move = GameObject.Find("Player").GetComponent<Player_Move>();

        score = 0;
        scoreRate = 1;
        sakanaMany = 1;


    }

    // Update is called once per frame
    void Update()
    {
        //time += Time.deltaTime;
        //sakanaMany = Player_Move.sakanaMany;
        score += Time.deltaTime*100;
        float sco = score / 100;
        float sco2 = (score - Mathf.FloorToInt(score / 100)*100) / 1;
        text.text = Mathf.FloorToInt(sco).ToString();
        text_2.text = Mathf.FloorToInt(sco2).ToString();
        string a = (sakanaMany - 1).ToString() + "/5";
        //sakana.text = a;
        if(gameover == true){
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("MainScene");
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Opening");
            }

        }
    }

    public void Gohome()
    {
        GameOver.text = "GAMEOVER" +
            "Press " +
            "SPACE"
            +"to Restart";

        gameover = true;

    }

    public void Clear()
    {
        SceneManager.LoadScene("Goal");
    }
}
}