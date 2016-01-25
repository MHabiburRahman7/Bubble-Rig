using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path : MonoBehaviour {

	public Transform myTransform;
	
	public GameObject waypointContainer;
	List <Transform> waypoints ;
	Transform[] potentialWaypoints;
	public float Dist;
	public float tmpDist;
	public int bestWaypoint;
	public int currentWaypoint;
	public float currentAngle;
	Vector3 RelativeWaypointPosition;
	Vector3 RelativeWaypointDir;

	//////////////////////////// waypoints ///////////////////////

	void Start ()
	{
		GetWaypoints();
		FindClosest(); ///// tried this (bestWaypoint); //(potentialWaypoints[]);
		currentWaypoint = bestWaypoint;
	}
	
	void GetWaypoints ()
	{
		if (waypointContainer!=null) 
		{
			Transform[] potentialWaypoints = waypointContainer.GetComponentsInChildren <Transform> ();
			
			waypoints = new List <Transform> ();
			
			foreach (Transform potentialWaypoint in potentialWaypoints) 
			{
				for (int i=0;i<waypoints.Count;i++);
				if (potentialWaypoint != waypointContainer.transform)
					waypoints.Add (potentialWaypoint);
				    Debug.Log("foundpotentialWaypoint");
			}
		}
	}    
	
	void FindClosest () {
		
		Dist = (waypoints[0].transform.position - transform.position).sqrMagnitude;
		bestWaypoint = 0;
		
		for (int i=1;i<waypoints.Count;i++) {
			tmpDist = (waypoints[i].transform.position - transform.position).sqrMagnitude;
			if (tmpDist < Dist)
				bestWaypoint = i;
		}
	}
	//        return waypoints[bestWaypoint];
}
