using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrullaje : MonoBehaviour
{
    public Transform[] patrolPoints; 
    public float waitTime = 1f; 
    private int currentPointIndex = 0;
    private bool waiting = false; 
    private Mru mru; 

    void Start()
    {
        transform.position = patrolPoints[currentPointIndex].position;
        mru = GetComponent<Mru>();
        StartCoroutine(PatrolRoutine());
    }

    IEnumerator PatrolRoutine()
    {
        while (true)
        {
            if (!waiting)
            {
                Vector3 direction = (patrolPoints[currentPointIndex].position - transform.position).normalized;
                mru.Move(direction);

                if (Vector3.Distance(transform.position, patrolPoints[currentPointIndex].position) < 0.1f)
                {
                    waiting = true;
                    yield return new WaitForSeconds(waitTime);
                    waiting = false;
                    currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
                }
            }
            yield return null;
        }
    }
}
