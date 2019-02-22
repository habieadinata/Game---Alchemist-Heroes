﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : MonoBehaviour {

    public Transform target;

    [SerializeField]
    float speed = 1f;
    Vector3[] path;
    int targetIndex;

	void Start () {
        PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
	}


    public void OnPathFound(Vector3[] newPath, bool pathsuccessful)
    {
        if (pathsuccessful)
        {
            path = newPath;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    private void Update()
    {
        FollowPath();
        OnDrawGizmos();
    }

    IEnumerator FollowPath()
    {
        Vector3 currentWayPoint = path[0];

        while (true)
        {
            if (transform.position == currentWayPoint)
            {
                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    yield break;
                }
                currentWayPoint = path[targetIndex];
            }
            transform.position = Vector3.MoveTowards(transform.position, currentWayPoint, speed * Time.deltaTime);
            yield return null;
        }
    }

    public void OnDrawGizmos()
    {
        if(path != null)
        {
            for (int i = targetIndex; i < path.Length; i++)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawCube(path[i], Vector3.one);

                if(i == targetIndex)
                {
                    Gizmos.DrawLine(transform.position, path[i]);
                    
                }
                else
                {
                    
                    Gizmos.DrawLine(path[i - 1], path[i]);
                }
            }
        }
    }


}
