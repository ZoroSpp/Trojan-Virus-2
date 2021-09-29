using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text score;
    [SerializeField] Text Info;
    [SerializeField] Text tim;
    [SerializeField] Text Gamecmp;
    [SerializeField] GameObject spark;
    [SerializeField] Spark sc;
    [SerializeField] Text Info2;
    public int scoreVal;
    int InVal, valChn;
    float infoST,infoST2;
    [SerializeField]float infoTP;
    float gameSt;
    int x = 0,y=0;
    bool Sc150=false,Sc50=false;
    public float xt;
    int i = 1, j = 1;
        //bool scoreupd=false;
    // Start is called before the first frame update
    void Start()
    {
        Gamecmp.text = "";
        xt = 0;
        tim.text = "Time - " + xt;
        gameSt = Time.time;
        Info.text = " ";
        InVal = scoreVal;
        scoreVal = 0;
        score.text = "Score - " + scoreVal;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            Debug.Log("Hekk");
        tim.text = "Time - " + (int)xt;
        if(xt<=20)
            xt = Time.time - gameSt;
        else
        {
            if(scoreVal<=150)
            {
                Gamecmp.color = Color.red;
                Gamecmp.text = "Game Over\n+ "+scoreVal;
                            }
            else
            {
                Gamecmp.color = Color.blue;
                Gamecmp.text = "Level Complete\n" + scoreVal;
            }
            Info2.color = Color.black;
            Info2.fontStyle = FontStyle.Italic;
            Info2.text = "Press ENTER to continue";
        }
            
        if ((scoreVal >= 150) || (scoreVal <= -50))
        {
            switch (y)
            {
                case 0:
                    y = 1;
                    infoST2 = Time.time;
                    break;
                case 1:
                    if (Time.time < infoST + infoTP)
                    {
                        if (scoreVal >= i*150 && !Sc150)
                        {
                            i++;
                            Info2.color = Color.blue;
                            Info2.text = "You have gained a brain!!";
                            //Sc150 = true;
                        }
                        else if (scoreVal <=j* -50 && !Sc50)
                        {
                            j++;
                            Info2.color = Color.red;
                            Info2.text = "You have lost a brain!!";
                            //Sc50 = true;

                        }


                    }
                    else
                    {
                        Info2.text = "";
                        y = 0;
                    }
                    break;
            }
        }
        else
        {
            i = 1;
            j = 1;
            Sc150 = false;
            Sc50 = false;
        }
        
        score.text = "Score -  " + scoreVal;
        if (InVal != scoreVal)
        {
            switch (x)
            {
                case 0:
                    infoST = Time.time;
                    valChn = scoreVal - InVal;
                    x = 1;
                    break;
                case 1:
                    if (Time.time < infoST + infoTP)
                    {
                        if (valChn > 0)
                        {
                            Info.color = Color.green;
                            Info.text = "+" + valChn;
                        }
                        else
                        {
                            Info.color = Color.red;
                            Info.text = "" + valChn;
                        }
                    }
                    else
                    {
                        Info.text = "";
                        InVal = scoreVal;
                        x = 0;
                    }
                    break;
            }
        }

       /* Vector2 pos;
        pos.x = Input.mousePosition.x;
        pos.y = Input.mousePosition.y;
        //Debug.Log(GameObject.Find("Spark").GetComponent<Spark>().speed);
        
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
                if (hit.collider.tag == "Player")
                {
                    Debug.Log(hit.collider.gameObject.name);
                }
                else
                    scoreVal -= 20;
            }*/

    }       
    
}
