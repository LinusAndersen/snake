using UnityEngine;
using System.Collections;

public class HackP1 : MonoBehaviour {
	float timer;
	// Use this for initialization
	void Start () {
		timer = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (Input.GetKey(KeyCode.Y)){
			PlayerControll.Speed -= 0.01f;
		}
		if (Input.GetKey(KeyCode.X)){
			PlayerControll.Speed += 0.01f;
		}
		if (Input.GetKey(KeyCode.C)){
			PlayerControll.Speed = 0.25f;
		}
		if (Input.GetKeyDown(KeyCode.Q)){
			if (timer < 0f){
			PlayerControll.snakepiececount += 1;
				timer = 0.5f;
		}
		}
		if (Input.GetKeyDown(KeyCode.Alpha1)){
			if (Player3Controll.direction3 != 3){
			Player3Controll.direction3 = 1f;
			}
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)){
			if (Player3Controll.direction3 != 4){
			Player3Controll.direction3 = 2f;
			}
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)){
			if (Player3Controll.direction3 != 1){
			Player3Controll.direction3 = 3f;
			}
		}
		if (Input.GetKeyDown(KeyCode.Alpha4)){
			if (Player3Controll.direction3 != 2){
			Player3Controll.direction3 = 4f;
			}
		}

	}
}
