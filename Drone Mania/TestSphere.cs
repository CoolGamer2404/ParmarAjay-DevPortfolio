using UnityEngine;

public class TestSphere : MonoBehaviour
{
    Vector3[] pointsLeft;
    Vector3[] pointsRight;
    [SerializeField] private GameObject[] sphere;

    public Color color1;
    public Color color2;

    public int totaLPoints = 35;

    public bool isAnimate = false;
    // Start is called before the first frame update
    void Start()
    {
        OnDrawGizmos();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        if (!Application.isPlaying)
            return;

        pointsLeft = GeneratePointsLeft();
        pointsRight = GeneratePointsRight();
    }

    public void LightShow1()
    {

    }

    void OnDrawGizmos()
    {
        if (isAnimate == false)
        {
            Debug.Log("Start");
            DrawPoints(pointsLeft, Color.red);
            DrawPoints(pointsRight, Color.red);
        }
        if (isAnimate)
        {
            Debug.Log("You Pressed");
            for (int i = 0; i < totaLPoints; i++)
            {
                DrawPoint(pointsLeft[i],color1);
                /*for (int j = 0; j < totaLPoints; i++)
                {
                    DrawPoint(pointsLeft[j], color1);
                    DrawPoint(pointsRight[j], color1);
                }
                DrawPoint(pointsLeft[i], color2);
                DrawPoint(pointsRight[i], color2);*/
            }
        }
    }

    Vector3[] GeneratePointsLeft()
    {
        Vector3[] generatedPointsMidToLeft = new Vector3[totaLPoints];

        for (int i = 0; i < totaLPoints; i++)
        {
            //float x = (float)i+i*3; // Adjust range to fit your area
            float y = (float)75 - i * 2; // Adjust range to fit your area
            float z = (float)i + i * 3;

            //Debug.Log(x.ToString());Debug.Log(y.ToString());Debug.Log(z.ToString());


            generatedPointsMidToLeft[i] = new Vector3(0, y, z); // Adjust position based on the spawn point
            Debug.Log(generatedPointsMidToLeft[i].ToString());
        }
        return generatedPointsMidToLeft;
    }
    Vector3[] GeneratePointsRight()
    {
        Vector3[] generatedPointsMidToRight = new Vector3[totaLPoints];
        for (int i = 1; i < totaLPoints; i++)
        {
            //float x = (float)i+i*3; // Adjust range to fit your area
            float y = (float)75 - i * 2; // Adjust range to fit your area
            float z = -((float)i + i * 3);

            //Debug.Log(x.ToString());Debug.Log(y.ToString());Debug.Log(z.ToString());


            generatedPointsMidToRight[i] = new Vector3(0, y, z); // Adjust position based on the spawn point
            Debug.Log(generatedPointsMidToRight[i].ToString());
        }


        return generatedPointsMidToRight;
    }

    void DrawPoints(Vector3[] points, Color color)
    {
        Debug.Log("Started");
        Gizmos.color = color;
        foreach (Vector3 point in points)
        {
            Gizmos.DrawSphere(point, 0.5f); // Draw spheres as gizmos
        }
    }

    void DrawPoint(Vector3 point, Color color)
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(point, 0.5f);
    }
}
