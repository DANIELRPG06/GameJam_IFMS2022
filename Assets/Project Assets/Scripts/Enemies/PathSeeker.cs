using UnityEngine;
using Pathfinding;

public class PathSeeker : MonoBehaviour {
    public Vector2 targetPosition;

    private Seeker seeker;
    private TopDownCharacterMotor motor;

    public Path path;

    public float speed = 2;

    public float nextWaypointDistance = 3;

    private int currentWaypoint = 0;

    public bool reachedEndOfPath;

    public void Start () {
        seeker = GetComponent<Seeker>();       
        motor = GetComponent<TopDownCharacterMotor>();
    }

    public void SetTarget(Vector2 target) {
        targetPosition = target;
        seeker.StartPath(transform.position, targetPosition, OnPathComplete);
    }

    public void OnPathComplete (Path p) {
        if (!p.error) {
            path = p;
            // Reset the waypoint counter so that we start to move towards the first point in the path
            currentWaypoint = 0;
        }
    }

    public void Update () {
        if (path == null) {
            return;
        }

        // Check in a loop if we are close enough to the current waypoint to switch to the next one.
        // We do this in a loop because many waypoints might be close to each other and we may reach
        // several of them in the same frame.
        reachedEndOfPath = false;
        // The distance to the next waypoint in the path
        float distanceToWaypoint;
        while (true) {
            distanceToWaypoint = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
            if (distanceToWaypoint < nextWaypointDistance) {
                // Check if there is another waypoint or if we have reached the end of the path
                if (currentWaypoint + 1 < path.vectorPath.Count) {
                    currentWaypoint++;
                } else {
                    reachedEndOfPath = true;
                    break;
                }
            } else {
                break;
            }
        }


        // Direction to the next waypoint
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
       
        motor.SetMove(dir);
        motor.SetLook(dir);

    }
}