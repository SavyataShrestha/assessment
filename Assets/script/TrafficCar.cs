using UnityEngine;

public class TrafficCar : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 8f;
    public float rotationSpeed = 8f;
    public float reachDistance = 1f;

    int current = 0;

    void Update()
    {
        if (waypoints == null || waypoints.Length == 0) return;

        Transform target = waypoints[current];
        if (target == null) return;

        Vector3 targetPosition = new Vector3(
            target.position.x,
            transform.position.y,
            target.position.z
        );

        // Move
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            speed * Time.deltaTime
        );

        // Rotate ONLY on Y axis
        Vector3 dir = targetPosition - transform.position;
        dir.y = 0;

        if (dir.sqrMagnitude > 0.01f)
        {
            Quaternion targetRot = Quaternion.LookRotation(dir);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRot,
                rotationSpeed * Time.deltaTime
            );
        }

        // Next waypoint
        if (Vector3.Distance(transform.position, targetPosition) < reachDistance)
        {
            current = (current + 1) % waypoints.Length;
        }
    }
}