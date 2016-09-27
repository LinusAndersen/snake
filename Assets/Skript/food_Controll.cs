using UnityEngine;
using System.Collections;

public class food_Controll : MonoBehaviour {
	public static float xx = 0;
	public static float yy= 0;
	public static int x1 = 0;
	public static int y1 =0;
	public int Spawnradius;
	public float Hitboxradius;
	float Spawnradius2;
	int i = 0;
	int z = 0;
	// Use this for initialization
	void Start () {
		Move ();
		transform.position = new Vector3(xx , yy , 0f);
		Spawnradius2 = Mods.inttofloat(Spawnradius);
	}
	
	// Update is called once per frame
	void Update () {   
		if (Mods.Collision(PlayerControll.Positionsx[0] , PlayerControll.Positionsy[0],xx,yy,Hitboxradius,Hitboxradius) == true ){
			PlayerControll.snakepiececount += 1;
			Move(); 
		}
		if (Mods.Collision(Player2Controll.Positionsx2[0] , Player2Controll.Positionsy2[0],xx,yy,0.005f,0.005f) == true ){
			Player2Controll.snakepiececount2 += 1;
			Move();
		}
		if (Mods.Collision(Player3Controll.Positionsx3[0] , Player3Controll.Positionsy3[0],xx,yy,0.005f,0.005f) == true ){
			Player3Controll.snakepiececount3 += 1;
			Move();
		}



		transform.position = new Vector3(xx , yy , 0f);
}
	void Move(){
		i = 0;
		while (i == 0){
		x1 = Random.Range( 0,Spawnradius * 2);
		xx= Mods.inttofloat(x1);
		xx = xx * 0.01f;
		y1 = Random.Range(0,Spawnradius * 2);
		yy = Mods.inttofloat(y1);
		yy = yy * 0.01f;
			xx = xx - Spawnradius2 * 0.01f;
			yy = yy - Spawnradius2 * 0.01f;
			z = 0;
			while (z < PlayerControll.lenpos){
				if (Mods.Collision(PlayerControll.Positionsx[z] , PlayerControll.Positionsy[z],xx,yy,0.005f,0.005f) == true ){
					i = 1;
				}

				else if ( xx == Portal1.xp1 && yy == Portal1.yp1 ){
					i = 1;
				}
				else if ( xx == Portal2.xp2 && yy == Portal2.yp2 ){
					i = 1;
				}


				z = z + 1;
				}
			z = 0;
			while (z < Player2Controll.lenpos2){
				if (Mods.Collision(Player2Controll.Positionsx2[z] , Player2Controll.Positionsy2[z],xx,yy,0.005f,0.005f) == true ){
					i = 1;
				}

				else if ( xx == Portal1.xp1 && yy == Portal1.yp1 ){
					i = 1;
				}
				else if ( xx == Portal2.xp2 && yy == Portal2.yp2 ){
					i = 1;
				}
				
				
				z = z + 1;
			}
			z = 0;
			while (z < Player3Controll.lenpos3){
				if (Mods.Collision(Player3Controll.Positionsx3[z] , Player3Controll.Positionsy3[z],xx,yy,0.005f,0.005f) == true ){
					i = 1;
				}
				
				else if ( xx == Portal1.xp1 && yy == Portal1.yp1 ){
					i = 1;
				}
				else if ( xx == Portal2.xp2 && yy == Portal2.yp2 ){
					i = 1;
				}
				
				
				z = z + 1;
			}
			if (i == 1){
				i = 0;
			}
			else{
				i = 1;
			}
			
		}
	}
	//xx == PlayerControll.Positionsx[z] && yy == PlayerControll.Positionsy[z]
}

