using UnityEngine;

public class RandomPathGenerator : MonoBehaviour
{
    public int minPoints = 15;
    public int maxPoints = 25;
    public float spawnBias = 5f; // Bias factor for point generation near spawn point
    public float speed = 5f; // Speed of the moving object
    public float rotationSpeed = 720f; // Rotation speed of the object in degrees per second
    public Color sphereColor = Color.red; // Color of the sphere gizmos
    public Color lineColor = Color.green; // Color of the line gizmos
    public bool showGizmos = true; // Enable or disable gizmo display

    public GameObject objectToMove; // GameObject that moves along the path

    Vector3[] points;
    int currentPointIndex = 0; // Index of the current target point on the path

    void OnEnable()
    {
        if (!Application.isPlaying)
            return;

        points = GenerateRandomPoints(minPoints, maxPoints, transform.position);
    }

    void Update()
    {
        if (!showGizmos || objectToMove == null)
            return;

        // Move the object along the path
        Vector3 targetPosition = points[currentPointIndex];
        float step = speed * Time.deltaTime;
        objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, targetPosition, step);

        // Rotate the object towards the next point on the path
        Vector3 direction = (targetPosition - objectToMove.transform.position).normalized;
        direction.y = 0f; // Ignore Y-axis
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        objectToMove.transform.rotation = Quaternion.RotateTowards(objectToMove.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // If the object reaches the current target point, move to the next point
        if (Vector3.Distance(objectToMove.transform.position, targetPosition) < 0.001f)
        {
            currentPointIndex = (currentPointIndex + 1) % points.Length;
        }
    }

    void OnDrawGizmos()
    {
        if (showGizmos && points != null) // Add null check for points array
        {
            DrawPoints(points, sphereColor);
            DrawPath(points, lineColor);
        }
    }

    Vector3[] GenerateRandomPoints(int minPoints, int maxPoints, Vector3 spawnPoint)
    {
        int numPoints = Random.Range(minPoints, maxPoints + 1);
        Vector3[] generatedPoints = new Vector3[numPoints];

        for (int i = 0; i < numPoints; i++)
        {
            float x = Random.Range(-12.5f, 12.5f); // Adjust range to fit your area
            float y = Random.Range(-6.25f, 6.25f); // Adjust range to fit your area
            float z = Random.Range(-12.5f, 12.5f);

            // Bias the point generation towards the spawn point
            float biasX = Random.Range(-spawnBias, spawnBias);
            float biasZ = Random.Range(-spawnBias, spawnBias);

            generatedPoints[i] = new Vector3(x + biasX, y, z + biasZ) + spawnPoint; // Adjust position based on the spawn point
        }

        return generatedPoints;
    }

    void DrawPoints(Vector3[] points, Color color)
    {
        Gizmos.color = color;
        foreach (Vector3 point in points)
        {
            Gizmos.DrawSphere(point, 0.5f); // Draw spheres as gizmos
        }
    }

    void DrawPath(Vector3[] points, Color color)
    {
        Gizmos.color = color;
        for (int i = 0; i < points.Length; i++)
        {
            Gizmos.DrawLine(points[i], points[(i + 1) % points.Length]);
        }
    }
}
