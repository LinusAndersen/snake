using UnityEngine;
using System.Collections;

public class SnakePiece3Controller : MonoBehaviour {
	int personalnumber;
	float x;
	float y;
	float timer;
	
	// Use this for initialization
	void Start () {
		timer = Player3Controll.timer3;
		personalnumber = Player3Controll.number3;
	}
	
	// Update is called once per frame
	void Update () {
		if (Player3Controll.reset3 == true){
			Destroy(gameObject);
		}
		else {
			timer = timer - Time.deltaTime;
			// als erstes Position reinschreiben.
			PositioninList();
			// als zweites zur Position gehen.
			if (timer <= 0){
				timer = timer + Player3Controll.Geschwindigkeit3;
				nextposAbfragen();
			}
		}
	}
	void PositioninList(){
		Player3Controll.Positionsx3[personalnumber] = transform.position.x;
		Player3Controll.Positionsy3[personalnumber] = transform.position.y;
	}
	void nextposAbfragen(){
		x = Player3Controll.Positionsx3[personalnumber - 1];
		y = Player3Controll.Positionsy3[personalnumber - 1];
		transform.position = new Vector3(x,y,0f);
	}
}