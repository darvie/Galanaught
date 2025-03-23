using System.Collections;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public Transform waypointParent;
    public Transform[] waypoints;
    public float moveSpeed;
    public float waitTime;

    public bool loopWaypoints = true;
    private bool isWaiting;
    private int currentWaypointIdx;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waypoints = new Transform[waypointParent.childCount];
        for (int i = 0; i < waypointParent.childCount; i++)
        {
            waypoints[i] = waypointParent.GetChild(i);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isWaiting)
        {
            return;
        }
        Move();
        
    }

    private void Move()
    {
        Transform target = waypoints[currentWaypointIdx];

        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime); ;
            if(Vector2.Distance(transform.position, target.position) < 1f)
        {
            StartCoroutine(WaitAtWaypoint());
        }
        
    }


IEnumerator WaitAtWaypoint()
    {

        if (currentWaypointIdx == waypoints.Length - 1)
        {
            isWaiting = true;
            yield return new WaitForSeconds(waitTime);
        }

        // if looping enabled, incriment  and wrap if required
        // if not lop incriment but do not pass last waypoint
        currentWaypointIdx = loopWaypoints ? (currentWaypointIdx + 1) % waypoints.Length : Mathf.Min(currentWaypointIdx + 1, waypoints.Length - 1);

        isWaiting = false;
    }

}
