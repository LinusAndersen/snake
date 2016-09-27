	using UnityEngine;
using System.Collections;

public class PlayerControll : MonoBehaviour {
	float [] Movements = new float[1];
	float [] save = new float[0];
	  public static float [] Positionsx = new float[1];
	  public static float [] Positionsy = new float[1];
	  public static int lenpos;
	// i + z
	public static  int number;
	int z;
	int len;
	float input;
	public static float direction;
	public static float x;
	public static float y;
	public static float timer;
	public static float snakepiececount;
	public GameObject snakepiece;
	public static bool reset = false;
	public static float Speed;
	public float KeySpeed;
	public float SizeGameField;
	// Use this for initialization
	void Start () {
		Speed = 0.25f;
		len = 0;
		lenpos = 1;
		timer = Speed;
	}
	
	// Update is called once per frame
	void Update () {

		if (snakepiececount > 0){
			SpawnSnakePiece();
			snakepiececount = snakepiececount - 1;
		}

		addInputtolist();
		timer = timer - Time.deltaTime;

		if (timer <= 0) {
			timer = timer + Speed;
			Positionsx[0] = x; 
			Positionsy[0] = y;
			Move ();
		}


		//comparision
	}

	void FixedUpdate(){
		//Collisions


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


		if (Mods.ListCollision(x,y,Positionsx,Positionsy,0.005f,0.005f,lenpos,1) == true){
			reset = true;
			transform.position = new Vector3(0f,0f,0f);
			x = 0;
			y = 0;
			Positionsx = new float[1];
			Positionsy = new float[1];
			lenpos = 1;
			number = 0;
		}
		else if (Mods.ListCollision(x,y,Player2Controll.Positionsx2,Player2Controll.Positionsy2,0.005f,0.005f,Player2Controll.lenpos2,1) == true){
			reset = true;
			transform.position = new Vector3(0f,0f,0f);
			x = 0;
			y = 0;
			Positionsx = new float[1];
			Positionsy = new float[1];
			Player2Controll.snakepiececount2 += lenpos;
			lenpos = 1;
			number = 0;
		}
		else if (Mods.ListCollision(x,y,Player3Controll.Positionsx3,Player3Controll.Positionsy3,0.005f,0.005f,Player3Controll.lenpos3,1) == true){
			reset = true;
			transform.position = new Vector3(0f,0f,0f);
			x = 0;
			y = 0;
			Positionsx = new float[1];
			Positionsy = new float[1];
			Player3Controll.snakepiececount3 += lenpos;
			lenpos = 1;
			number = 0;
		}

//		else if ( x == Player2Controll.x2 && y == Player2Controll.y2){
//			reset = true;
//			transform.position = new Vector3(0f,0f,0f);
//			x = 0;
//			y = 0;
//			Positionsx = new float[1];
//			Positionsy = new float[1];
//			lenpos = 1;
//			number = 0;
//		}
		else {
			reset = false;
		}



	}
	void Move(){
		z = 0;
		while (len > 0 && z == 0) {
			if (Movements [0] == 1 && direction != 3 && direction != 1) {
				direction = 1;
				z = 1;
				Movements = ListenVerwalten.removethefirst(Movements,save,len);
				len = ListenVerwalten.lenminus1(len);
			} else if (Movements [0] == 2 && direction != 4 && direction != 2) {
				direction = 2;
				z = 1;  
				Movements = ListenVerwalten.removethefirst(Movements,save,len);
				len = ListenVerwalten.lenminus1(len);
			} else if (Movements [0] == 3 && direction != 1 && direction != 3) {
				direction = 3;
				z = 1;
				Movements = ListenVerwalten.removethefirst(Movements,save,len);
				len = ListenVerwalten.lenminus1(len);
			} else if (Movements [0] == 4 && direction != 2 && direction != 4) {
				direction = 4;
				z = 1;
				Movements = ListenVerwalten.removethefirst(Movements,save,len);
				len = ListenVerwalten.lenminus1(len);
			}
			else {
				Movements = ListenVerwalten.removethefirst(Movements,save,len);
				len = ListenVerwalten.lenminus1(len);
			}
		
		}

		if (direction == 1) {
			x = x - 0.01f;
		}
		if (direction == 2) {
			y = y + 0.01f;
		}
		if (direction == 3) {
			x = x + 0.01f;
		}
		if (direction == 4) {
			y = y - 0.01f;
		}
		if (y < SizeGameField * -1){
			y = SizeGameField;
		}
		if (y > SizeGameField){
			y = SizeGameField * -1;
		}

		if (x < SizeGameField * -1){
			x = SizeGameField;
		}
		if (x > SizeGameField){
			x = SizeGameField * -1;
		}

		transform.position = new Vector3 (x, y, 0f);
	}
	void addInputtolist(){
		if (Input.GetKeyDown(KeyCode.A)) {
			input = 1;
			Movements = ListenVerwalten.addtoList(Movements,len,input,save);
			len = ListenVerwalten.lenplus1(len);
		}
		else if (Input.GetKeyDown (KeyCode.W)) {
			input = 2;
			Movements = ListenVerwalten.addtoList(Movements,len,input,save);
			len = ListenVerwalten.lenplus1(len);
		}
		else if (Input.GetKeyDown(KeyCode.D)) {
			input = 3;
			Movements = ListenVerwalten.addtoList(Movements,len,input,save);
			len = ListenVerwalten.lenplus1(len);
		}
		else if (Input.GetKeyDown(KeyCode.S)) {
			input = 4;
			Movements = ListenVerwalten.addtoList(Movements,len,input,save);
			len = ListenVerwalten.lenplus1(len);
		}
				


		}
	 void SpawnSnakePiece(){
		number = number + 1;
		Positionsx = ListenVerwalten.addtoList(Positionsx,lenpos,100,save);
		Positionsy = ListenVerwalten.addtoList(Positionsy,lenpos,100,save);
		lenpos = ListenVerwalten.lenplus1(lenpos);
		Instantiate (snakepiece,new Vector3(100f, 100f,0f),transform.rotation);
	}
	}

