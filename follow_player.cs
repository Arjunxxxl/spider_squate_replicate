using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class follow_player : MonoBehaviour {

	public GameObject player;
	public Vector3 offset;
	string current;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
		current = SceneManager.GetActiveScene().name;
		Time.timeScale = 1.0f;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;
		if(Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene(current);
		}
	}
}
