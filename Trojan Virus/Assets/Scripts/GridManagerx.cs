using UnityEngine;

public class GridManagerx : MonoBehaviour
{
    /* [SerializeField] GameObject spark;
     [SerializeField] Spark SparkLife;

     //[SerializeField] private bool mouseclick;
     private bool check = true;
     // Start is called before the first frame update
     void Start()
     {
         //GenerateSpark();
     }*/

    // Update is called once per frame
    void Update()
    {
        /*bool x=GameObject.Find("Spark").GetComponent<Spark>().checkClick;
        //if (x)
        {
            Debug.Log("Hello");
            GenerateSpark();
        }
        /*private bool checkmouseclick()
        {
            mouseclick = Input.GetButtonDown(KeyCode.Mouse(0))
            //Input.GetMouseButtonDown(1)
        }*/
        /*if(check)
            GenerateSpark();*/
    }

    private void GenerateSpark()
    {
        /*Debug.Log("Hell");
        int i = Random.Range(0, 3);
        float x = (i - 1) * 5.2f;
        int j = Random.Range(0, 3);
        float y = (j - 1) * 5.2f;
        var _lightspark = Instantiate(spark, new Vector2((float)x, (float)y), Quaternion.identity);
        //_lightspark.Name = $"LightSpark {i} {j}";
        //GameObject.Find("Spark").GetComponent<Spark>().checkClick = false;
        }*/
    }
}
