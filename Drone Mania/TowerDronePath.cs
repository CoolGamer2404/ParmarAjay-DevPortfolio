using UnityEngine;

public class TowerDronePath : MonoBehaviour
{
    public GameObject towerObject; // Reference to the tower game object
    public int minPoints = 15;
    public int maxPoints = 25;
    public float spawnRadius = 10f; // Radius for spawning points around the tower
    public LayerMask obstacleLayer; // Layer mask for obstacles to avoid
    public bool visualizePath = true; // Toggle to visualize the path

    private Vector3[] pathPoints; // Array to store the generated path points

    void Start()
    {
        GeneratePath();
    }

    void GeneratePath()
    {
        if (towerObject == null)
        {
            Debug.LogError("Tower object not assigned.");
            return;
        }

        // Generate random points around the tower
        pathPoints = new Vector3[Random.Range(minPoints, maxPoints + 1)];
        for (int i = 0; i < pathPoints.Length; i++)
        {
            Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
            Vector3 spawnPosition = new Vector3(randomCircle.x, 0f, randomCircle.y) + towerObject.transform.position;
            spawnPosition.y = 0f; // Ensure Y position is at ground level
            pathPoints[i] = spawnPosition;
        }

        // Connect the points to create a path, avoiding collisions with tower
        for (int i = 0; i < pathPoints.Length - 1; i++)
        {
            Vector3 startPoint = pathPoints[i];
            Vector3 endPoint = pathPoints[i + 1];

            // Raycast from startPoint to endPoint
            RaycastHit hit;
            if (Physics.Raycast(startPoint, endPoint - startPoint, out hit, Vector3.Distance(startPoint, endPoint), obstacleLayer))
            {
                // If hit, regenerate the path
                GeneratePath();
                return;
            }
        }

        // If no obstacles were hit, connect the points
        for (int i = 0; i < pathPoints.Length - 1; i++)
        {
            Gizmos.DrawLine(pathPoints[i], pathPoints[i + 1]);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (visualizePath)
        {
            if (pathPoints != null)
            {
                Gizmos.color = Color.green;
                for (int i = 0; i < pathPoints.Length - 1; i++)
                {
                    Gizmos.DrawLine(pathPoints[i], pathPoints[i + 1]);
                }
            }
        }
    }
}
