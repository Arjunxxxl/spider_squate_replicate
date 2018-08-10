using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {


	public float gravity_mul = 5.0f;
	public float smooth = 1f;

	public float up_velocity = 5.0f;
	public float len = 0.0f;

	bool draw = false;
	bool isDead = false;

	bool moveDxn = true;

	float back_len;

	GameObject line_end;

	public GameObject gameover;


	#region Singleton
	public static PlayerMove Instance;
	private void Awake() {
		Instance = this;
	}
	#endregion
	

	// Use this for initialization
	void Start () {
		gameover.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(!isDead){
		if(Input.GetKey(KeyCode.Space))
		{
			
			move2();
		}
		else{
		applyGravity();
		Rot();
		if(line_end){
			Destroy(line_end);
		}
		line_end = null;
		//isBack = true;
		draw = true;
		}
		
		}
		else{
			Time.timeScale = 0.0f;
		}

	}

	void applyGravity()
	{
		float y = transform.position.y;
		Vector3 current_pos = transform.position;
		Vector3 final_pos = new Vector3(transform.position.x-len, y-gravity_mul, transform.position.z);
		transform.position = Vector3.Lerp(current_pos, final_pos, Time.deltaTime * smooth);
	}

	void Rot()
	{
		transform.Rotate(0,0, -Time.deltaTime * len *40f, Space.World);
	}

	public GameObject pass_gm()
	{
		return line_end;
	}


	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Enemy"))
		{
			isDead = true;
			gameover.SetActive(true);
		}
	}

	void move()
	{
			len = 10 - transform.position.y;

			/*if(isBack)
			{
				isBack = false;
				back_len = len/2;
			}*/

			Vector3 current_pos1 = transform.position;
			//if(len > back_len){
			Vector3 final_pos1 = new Vector3(transform.position.x-len, transform.position.y+up_velocity, transform.position.z);
			transform.position = Vector3.Lerp(current_pos1, final_pos1, Time.deltaTime * smooth);
			/*}else{
				Vector3 final_pos1 = new Vector3(transform.position.x+len, transform.position.y+up_velocity, transform.position.z);
				transform.position = Vector3.Lerp(current_pos1, final_pos1, Time.deltaTime * smooth);
			}*/
			transform.Rotate(0,0, -Time.deltaTime * len *8f, Space.World);

			if(draw){
			line_end = new GameObject();
			line_end.transform.position = new Vector3(transform.position.x-3.0f,10,0);
			draw = false;
			}
	}

float fw;
	void move2()
	{
			len = 10 - transform.position.y;

			float t = len/(len*0.5f);
			float s = 2/Mathf.Sqrt(5);
			float c = 1/Mathf.Sqrt(5);
			
			fw =0f;
			

			if(draw){
			line_end = new GameObject();
			line_end.transform.position = new Vector3(transform.position.x-len*0.5f,10,0);
			fw = transform.position.x - (len * ((1 + c) / 2));
			//fw = line_end.transform.position.x - 0.1f;
			draw = false;
			}
			
			if(fw == transform.position.x){
				moveDxn =false;
				Debug.Log(moveDxn);
			}
			else if(fw < transform.position.x)
			{
				moveDxn = true;
				Debug.Log(moveDxn);
			}

			if(moveDxn){
			Vector3 current_pos1 = transform.position;
			Vector3 final_pos1 = new Vector3(transform.position.x-len, transform.position.y+up_velocity, transform.position.z);
			transform.position = Vector3.Lerp(current_pos1, final_pos1, Time.deltaTime * smooth);
			transform.Rotate(0,0, -Time.deltaTime * len *8f, Space.World);
			}else{
			Vector3 current_pos1 = transform.position;
			Vector3 final_pos1 = new Vector3(transform.position.x+len*150f, (transform.position.y+up_velocity/20), transform.position.z);
			transform.position = Vector3.Lerp(current_pos1, final_pos1, Time.deltaTime * smooth);
			transform.Rotate(0,0, -Time.deltaTime * len *8f, Space.World);
			}

	}



}
