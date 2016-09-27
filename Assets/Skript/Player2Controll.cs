using System.Collections;
using UnityEngine;
public class Player2Controll : MonoBehaviour {
	float [] Movements = new float[1];
	float [] save = new float[0];
	public static float [] Positionsx2 = new float[1];
	public static float [] Positionsy2 = new float[1];
	public static int lenpos2;
	// i + z
	public static  int number2;
	int z;
	int len;
	float input;
	public static float direction2;
	public static float x2;
	public static float y2;
	public static float timer2;
	public static float snakepiececount2;
	public GameObject snakepiece;
	public static bool reset2 = false;
	public static float Geschwindigkeit2;
	public float KeyGeschwindigkeit;
	public float GroesseSpielfeld;
	// Use this for initialization
	void Start () {
		Geschwindigkeit2 = 0.25f;
		len = 0;
		lenpos2 = 1;
		timer2 = Geschwindigkeit2;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (snakepiececount2 > 0){
			SpawnSnakePiece();
			snakepiececount2 = snakepiececount2 - 1;
		}
		
		addInputtolist();
		timer2 = timer2 - Time.deltaTime;
		
		if (timer2 <= 0) {
			timer2 = timer2 + Geschwindigkeit2;
			Positionsx2[0] = x2; 
			Positionsy2[0] = y2;
			Move ();
		}
		
		
		//comparision
	}
	
	void FixedUpdate(){
		//	if (ListenVerwalten.Comparision(Positionsx, Positionsy,lenpos,x,y) ){
		//		Debug.Log("Collision");
		//		reset = true;
		//		transform.position = new Vector3(0f,0f,0f);
		//		x = 0;
		//		y = 0;
		//		Positionsx = new float[1];
		//		Positionsy = new float[1];
		//		lenpos = 1;
		//	number = 0;
		
		//}
		//else {
		//	Debug.Log(x);
		//	Debug.Log(y);
		//	reset = false;}
		
		
		if (Mods.ListCollision(x2,y2,Positionsx2,Positionsy2,0.005f,0.005f,lenpos2,1) == true){
			reset2 = true;
			transform.position = new Vector3(0f,0f,0f);
			x2 = 0;
			y2 = 0;
			Positionsx2 = new float[1];
			Positionsy2 = new float[1];
			lenpos2 = 1;
			number2 = 0;
		}

		else if (Mods.ListCollision(x2,y2,PlayerControll.Positionsx,PlayerControll.Positionsy,0.005f,0.005f, PlayerControll.lenpos,1) == true){
			reset2 = true;
			transform.position = new Vector3(0f,0f,0f);
			x2 = 0;
			y2 = 0;
			Positionsx2 = new float[1];
			Positionsy2 = new float[1];
			PlayerControll.snakepiececount += lenpos2;
			lenpos2 = 1;
			number2 = 0;
		}
		else if (Mods.ListCollision(x2,y2,Player3Controll.Positionsx3,Player3Controll.Positionsy3,0.005f,0.005f, Player3Controll.lenpos3,1) == true){
			reset2 = true;
			transform.position = new Vector3(0f,0f,0f);
			x2 = 0;
			y2 = 0;
			Positionsx2 = new float[1];
			Positionsy2 = new float[1];
			Player3Controll.snakepiececount3 += lenpos2;
			lenpos2 = 1;
			number2 = 0;
		}
		//else if ( x2 == PlayerControll.x && y2 == PlayerControll.y){
		//	reset2 = true;
		//	transform.position = new Vector3(0f,0f,0f);
		//	x2 = 0;
		//	y2 = 0;
		//	Positionsx2 = new float[1];
		//	Positionsy2 = new float[1];
		//	lenpos2 = 1;
		//	number2 = 0;
		//}
		else {
			reset2 = false;
		}




	}
	void Move(){
		z = 0;
		while (len > 0 && z == 0) {
			if (Movements [0] == 1 && direction2 != 3 && direction2 != 1) {
				direction2 = 1;
				z = 1;
				Movements = ListenVerwalten.removethefirst(Movements,save,len);
				len = ListenVerwalten.lenminus1(len);
			} else if (Movements [0] == 2 && direction2 != 4 && direction2 != 2) {
				direction2 = 2;
				z = 1;  
				Movements = ListenVerwalten.removethefirst(Movements,save,len);
				len = ListenVerwalten.lenminus1(len);
			} else if (Movements [0] == 3 && direction2 != 1 && direction2 != 3) {
				direction2 = 3;
				z = 1;
				Movements = ListenVerwalten.removethefirst(Movements,save,len);
				len = ListenVerwalten.lenminus1(len);
			} else if (Movements [0] == 4 && direction2 != 2 && direction2 != 4) {
				direction2 = 4;
				z = 1;
				Movements = ListenVerwalten.removethefirst(Movements,save,len);
				len = ListenVerwalten.lenminus1(len);
			}
			else {
				Movements = ListenVerwalten.removethefirst(Movements,save,len);
				len = ListenVerwalten.lenminus1(len);
			}
			
		}
		
		if (direction2 == 1) {
			x2 = x2 - 0.01f;
		}
		if (direction2 == 2) {
			y2 = y2 + 0.01f;
		}
		if (direction2 == 3) {
			x2 = x2 + 0.01f;
		}
		if (direction2 == 4) {
			y2 = y2 - 0.01f;
		}
		if (y2 < GroesseSpielfeld * -1){
			y2 = GroesseSpielfeld;
		}
		if (y2 > GroesseSpielfeld){
			y2 = GroesseSpielfeld * -1;
		}
		
		if (x2 < GroesseSpielfeld * -1){
			x2 = GroesseSpielfeld;
		}
		if (x2 > GroesseSpielfeld){
			x2 = GroesseSpielfeld * -1;
		}
		
		transform.position = new Vector3 (x2, y2, 0f);
	}
	void addInputtolist(){
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			input = 1;
			Movements = ListenVerwalten.addtoList(Movements,len,input,save);
			len = ListenVerwalten.lenplus1(len);
		}
		else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			input = 2;
			Movements = ListenVerwalten.addtoList(Movements,len,input,save);
			len = ListenVerwalten.lenplus1(len);
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow)) {
			input = 3;
			Movements = ListenVerwalten.addtoList(Movements,len,input,save);
			len = ListenVerwalten.lenplus1(len);
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			input = 4;
			Movements = ListenVerwalten.addtoList(Movements,len,input,save);
			len = ListenVerwalten.lenplus1(len);
		}
		
		
		
	}
	void SpawnSnakePiece(){
		number2 = number2 + 1;
		Positionsx2 = ListenVerwalten.addtoList(Positionsx2,lenpos2,100,save);
		Positionsy2 = ListenVerwalten.addtoList(Positionsy2,lenpos2,100,save);
		lenpos2 = ListenVerwalten.lenplus1(lenpos2);
		Instantiate (snakepiece,new Vector3(100f, 100f,0f),transform.rotation);
	}
}