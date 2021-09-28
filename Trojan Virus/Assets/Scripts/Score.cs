using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text score;
    [SerializeField] Text Info;
    [SerializeField] Text tim;
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
        //bool scoreupd=false;
    // Start is called before the first frame update
    void Start()
    {
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
        xt = Time.time - gameSt;
        tim.text = "Time - " + (int)xt;
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
                        if (scoreVal >= 150 && !Sc150)
                        {
                            Info2.text = "You have gained a brain!!";
                            Sc150 = true;
                        }
                        else if (scoreVal <= -50 && !Sc50)
                        {
                            Info2.text = "You have lost a brain!!";
                            Sc50 = true;

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
                            Info.text = "+" + valChn;
                        else
                            Info.text = "" + valChn;
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
