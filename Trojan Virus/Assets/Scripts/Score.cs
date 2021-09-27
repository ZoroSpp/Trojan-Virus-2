using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text score;
    [SerializeField] Text Info;
    [SerializeField] GameObject spark;
    [SerializeField] Spark sc;
    public int scoreVal;
    int InVal, valChn;
    float infoST;
    [SerializeField]float infoTP;
    int x = 0;
        //bool scoreupd=false;
    // Start is called before the first frame update
    void Start()
    {
        Info.text = " ";
        InVal = scoreVal;
        scoreVal = 0;
        score.text = "Score - " + scoreVal;
    }

    // Update is called once per frame
    void Update()
    {
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

        Vector2 pos;
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
            }

    }       
    
}
