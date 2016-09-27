using UnityEngine;
using System.Collections;

public class SnakePiece2Controll : MonoBehaviour {
	int personalnumber;
	float x;
	float y;
	float timer;
	
	// Use this for initialization
	void Start () {
		timer = Player2Controll.timer2;
		personalnumber = Player2Controll.number2;
	}
	
	// Update is called once per frame
	void Update () {
		if (Player2Controll.reset2 == true){
			Destroy(gameObject);
		}
		else {
			timer = timer - Time.deltaTime;
			// als erstes Position reinschreiben.
			PositioninList();
			// als zweites zur Position gehen.
			if (timer <= 0){
				timer = timer + Player2Controll.Geschwindigkeit2;
				nextposAbfragen();
			}
		}
	}
	void PositioninList(){
		Player2Controll.Positionsx2[personalnumber] = transform.position.x;
		Player2Controll.Positionsy2[personalnumber] = transform.position.y;
	}
	void nextposAbfragen(){
		x = Player2Controll.Positionsx2[personalnumber - 1];
		y = Player2Controll.Positionsy2[personalnumber - 1];
		transform.position = new Vector3(x,y,0f);
	}
}