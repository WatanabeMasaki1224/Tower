using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1.0f;
    private List<Transform> wayPoint;
    private int wayPointIndex = 0;

    public void Setup(List<Transform> path)
    {
        wayPoint = path;
        transform.position = wayPoint[0].position;
    }

    private void Update()
    {
        if(wayPoint == null || wayPointIndex >= wayPoint.Count)
        {
            return;
        }

        Transform target = wayPoint[wayPointIndex];
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            wayPointIndex++;
            if (wayPointIndex >= wayPoint.Count)
            {
                ReachGoal();
            }
        }
    }

    void ReachGoal()
    {
        // ƒS[ƒ‹“’B‚Ìˆ—
        Destroy(gameObject);
    }
}



