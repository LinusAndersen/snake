using UnityEngine;
using System.Collections;

public class SnakePieceContoll : MonoBehaviour {
	int personalnumber;
	float x;
	float y;
	float timer;

	// Use this for initialization
	void Start () {
		timer = PlayerControll.timer;
		personalnumber = PlayerControll.number;
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerControll.reset == true){
			Destroy(gameObject);
		}
		else {
		timer = timer - Time.deltaTime;
	// als erstes Position reinschreiben.
		PositioninList();
	// als zweites zur Position gehen.
		if (timer <= 0){
			timer = timer + PlayerControll.Speed;
		nextposAbfragen();
		}
		}
	}
	void PositioninList(){
		PlayerControll.Positionsx[personalnumber] = transform.position.x;
		PlayerControll.Positionsy[personalnumber] = transform.position.y;
	}
	void nextposAbfragen(){
 		x = PlayerControll.Positionsx[personalnumber - 1];
		y = PlayerControll.Positionsy[personalnumber - 1];
		transform.position = new Vector3(x,y,0f);
	}
}
