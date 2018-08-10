using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {

	LineRenderer lineRendered;
	float counter;
	float dist;

	public Transform origin;

	public float lineDrawSpeed = 5f;

	PlayerMove pm;
	GameObject end;

	// Use this for initialization
	void Start () {
		pm = PlayerMove.Instance;

		lineRendered = GetComponent<LineRenderer>();
		
		
	}
	
	// Update is called once per frame
	void Update () {
		end = pm.pass_gm();
		if(end)
		{
			DrawLine_Now(origin, end.transform);
		}
		else{
			DrawLine_Now(origin, origin);
		}
	}


	void DrawLine_Now(Transform a, Transform b)
	{
		lineRendered.SetPosition(0, a.position);
		lineRendered.startWidth =0.15f ;
		lineRendered.endWidth = 0.15f;
		lineRendered.SetPosition(1, b.position);
	}

}
