using UnityEngine;

public class Spark : MonoBehaviour
{
    [SerializeField] Transform pos;
    public float speed;
    [SerializeField] GameObject SparkLs;
    Vector3 targetpos;
    float Sparktime;                    // start of sparks runtime
    float timelapse;                    // timeperiod of each cycle
    [SerializeField] float freezeTime;
    float freezeStart;
    public static int checkSt = 0;                    //running status of spark
    public static bool checkClick=false;
    public bool CheckClkna = checkClick;
    public int checkStna = checkSt;
    GameObject spark;
    // Start is called before the first frame update
    void Start()
    {
        Sparktime = Time.time;
        timelapse = Random.Range(4, 10)*0.2f;
        TargetPos();
    }

    // Update is called once per frame
    void Update()
    {
        checkStna = checkSt;
        CheckClkna = checkClick;
        if (pos.position != targetpos)
        {
            pos.position=Vector3.MoveTowards(pos.position,targetpos,speed*Time.deltaTime);
        }

        else
        {
            if (Time.time >= Sparktime + timelapse)
            {
                switch (checkSt)
                {
                    case 0:
                        freezeStart = Time.time;
                        checkSt = 1;
                        speed = 0;
                        break;
                    case 1:
                        if (checkClick)
                        {
                            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
                            if (hit.collider.tag == "Player")
                            {
                                GameObject.Find("GridManager").GetComponent<Score>().scoreVal += 30;
                            }
                            else
                                GameObject.Find("GridManager").GetComponent<Score>().scoreVal -= 20;
                            
                            speed = 40;
                            checkClick = false;
                            GenerateSpark();
                        }
                        if (Time.time >= freezeStart + freezeTime)
                        {
                           
                            Sparktime = Time.time;
                            timelapse = Random.Range(4, 10) * 0.2f;
                            speed = 40;
                            checkSt= 0;
                            TargetPos();
                        }
                        break;
                }
            }
            else
            {
                TargetPos();
            }
        }

    }
    private void TargetPos()
    {
        targetpos.x = (Random.Range(0,3)-1)*5.2f;
        targetpos.y = (Random.Range(0,3)-1)*5.2f;
        targetpos.z = 0.0f;
        }
    void OnMouseDown()
    {
        if (checkSt == 1)
        {
            checkClick = true;
        }
            }
    void GenerateSpark()
    {
        int i = Random.Range(0, 3);
        float x = (i - 1) * 5.2f;
        int j = Random.Range(0, 3);
        float y = (j - 1) * 5.2f;
        spark = Instantiate(SparkLs, new Vector2((float)x, (float)y), Quaternion.Euler(transform.eulerAngles));
        checkClick = false;
        checkSt = 0;
        Destroy(this.gameObject);
        
    }

}
