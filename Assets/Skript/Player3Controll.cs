using System.Collections;
using UnityEngine;
public class Player3Controll : MonoBehaviour {
	float [] Movements = new float[1];
	float [] save = new float[0];
	public static float [] Positionsx3 = new float[1];
	public static float [] Positionsy3 = new float[1];
	public static int lenpos3;
	// i + z
	public static  int number3;
	int z;
	int len;
	float input;
	public static float direction3;
	public static float x3;
	public static float y3;
	public static float timer3;
	public static float snakepiececount3;
	public GameObject snakepiece;
	public static bool reset3 = false;
	public static float Geschwindigkeit3;
	public float KeyGeschwindigkeit;
	public float GroesseSpielfeld;
	// Use this for initialization
	void Start () {
		Geschwindigkeit3 = 0.25f;
		len = 0;
		lenpos3 = 1;
		timer3 = Geschwindigkeit3;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (snakepiececount3 > 0){
			SpawnSnakePiece();
			snakepiececount3 = snakepiececount3 - 1;
		}
		
		addInputtolist();
		timer3 = timer3 - Time.deltaTime;
		
		if (timer3 <= 0) {
			timer3 = timer3 + Geschwindigkeit3;
			Positionsx3[0] = x3; 
			Positionsy3[0] = y3;
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
		
		
		if (Mods.ListCollision(x3,y3,Positionsx3,Positionsy3,0.005f,0.005f,lenpos3,1) == true){
			reset3 = true;
			transform.position = new Vector3(0f,0f,0f);
			x3 = 0;
			y3 = 0;
			Positionsx3 = new float[1];
			Positionsy3 = new float[1];
			lenpos3 = 1;
			number3 = 0;
		}
		
		else if (Mods.ListCollision(x3,y3,PlayerControll.Positionsx,PlayerControll.Positionsy,0.005f,0.005f, PlayerControll.lenpos,1) == true){
			reset3 = true;
			transform.position = new Vector3(0f,0f,0f);
			x3 = 0;
			y3 = 0;
			Positionsx3 = new float[1];
			Positionsy3 = new float[1];
			PlayerControll.snakepiececount += lenpos3;
			lenpos3 = 1;
			number3 = 0;
		}
		else if (Mods.ListCollision(x3,y3,Player2Controll.Positionsx2,Player2Controll.Positionsy2,0.005f,0.005f, Player2Controll.lenpos2,1) == true){
			reset3 = true;
			transform.position = new Vector3(0f,0f,0f);
			x3 = 0;
			y3 = 0;
			Positionsx3 = new float[1];
			Positionsy3 = new float[1];
			Player2Controll.snakepiececount2 += lenpos3;
			lenpos3 = 1;
			number3 = 0;
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
			reset3 = false;
		}
		
		
		
		
	}
	void Move(){
		z = 0;
		while (len > 0 && z == 0) {
			if (Movements [0] == 1 && direction3 != 3 && direction3 != 1) {
				direction3 = 1;
				z = 1;
				Movements = ListenVerwalten.removethefirst(Movements,save,len);
				len = ListenVerwalten.lenminus1(len);
			} else if (Movements [0] == 2 && direction3 != 4 && direction3 != 2) {
				direction3 = 2;
				z = 1;  
				Movements = ListenVerwalten.removethefirst(Movements,save,len);
				len = ListenVerwalten.lenminus1(len);
			} else if (Movements [0] == 3 && direction3 != 1 && direction3 != 3) {
				direction3 = 3;
				z = 1;
				Movements = ListenVerwalten.removethefirst(Movements,save,len);
				len = ListenVerwalten.lenminus1(len);
			} else if (Movements [0] == 4 && direction3 != 2 && direction3 != 4) {
				direction3 = 4;
				z = 1;
				Movements = ListenVerwalten.removethefirst(Movements,save,len);
				len = ListenVerwalten.lenminus1(len);
			}
			else {
				Movements = ListenVerwalten.removethefirst(Movements,save,len);
				len = ListenVerwalten.lenminus1(len);
			}
			
		}
		
		if (direction3 == 1) {
			x3 = x3 - 0.01f;
		}
		if (direction3 == 2) {
			y3 = y3 + 0.01f;
		}
		if (direction3 == 3) {
			x3 = x3 + 0.01f;
		}
		if (direction3 == 4) {
			y3 = y3 - 0.01f;
		}
		if (y3 < GroesseSpielfeld * -1){
			y3 = GroesseSpielfeld;
		}
		if (y3 > GroesseSpielfeld){
			y3 = GroesseSpielfeld * -1;
		}
		
		if (x3< GroesseSpielfeld * -1){
			x3 = GroesseSpielfeld;
		}
		if (x3 > GroesseSpielfeld){
			x3 = GroesseSpielfeld * -1;
		}
		
		transform.position = new Vector3 (x3, y3, 0f);
	}
	void addInputtolist(){
		if (Input.GetKeyDown(KeyCode.J)) {
			input = 1;
			Movements = ListenVerwalten.addtoList(Movements,len,input,save);
			len = ListenVerwalten.lenplus1(len);
		}
		else if (Input.GetKeyDown (KeyCode.I)) {
			input = 2;
			Movements = ListenVerwalten.addtoList(Movements,len,input,save);
			len = ListenVerwalten.lenplus1(len);
		}
		else if (Input.GetKeyDown(KeyCode.L)) {
			input = 3;
			Movements = ListenVerwalten.addtoList(Movements,len,input,save);
			len = ListenVerwalten.lenplus1(len);
		}
		else if (Input.GetKeyDown(KeyCode.K)) {
			input = 4;
			Movements = ListenVerwalten.addtoList(Movements,len,input,save);
			len = ListenVerwalten.lenplus1(len);
		}
		
		
		
	}
	void SpawnSnakePiece(){
		number3 = number3 + 1;
		Positionsx3 = ListenVerwalten.addtoList(Positionsx3,lenpos3,100,save);
		Positionsy3 = ListenVerwalten.addtoList(Positionsy3,lenpos3,100,save);
		lenpos3 = ListenVerwalten.lenplus1(lenpos3);
		Instantiate (snakepiece,new Vector3(100f, 100f,0f),transform.rotation);
	}
}