using UnityEngine;
using System.Collections;

public class Portal2 : MonoBehaviour {
	float xx = 0;
	float yy= 0;
	int x1 = 0;
	int y1 =0;
	public int Spawnradius;
	float Spawnradius2;
	int i = 0;
	int z = 0;
	public static float xp2;
	public static float yp2;
	public GameObject Gameobjekt;
	public GameObject Gameobjekt2;
	// Use this for initialization
	void Start () {
		Move ();
	}
	
	// Update is called once per frame
	void Update () { 
		if (Mods.Collision(PlayerControll.Positionsx[0] , PlayerControll.Positionsy[0],xx,yy,0.005f,0.005f) == true  && Portal1.timerp1 < 0){
			Portal1.timerp1 = 0.5f;
			PlayerControll.x = Portal1.xp1;
			PlayerControll.y = Portal1.yp1;
			Gameobjekt.transform.position = new Vector3(Portal2.xp2,Portal2.yp2,0f);
			Spawnradius2 = Mods.inttofloat(Spawnradius);
			Move();
		}
		if (Mods.Collision(Player2Controll.Positionsx2[0] , Player2Controll.Positionsy2[0],xx,yy,0.005f,0.005f) == true  && Portal1.timerp1 < 0){
			Portal1.timerp1 = 0.5f;
			Player2Controll.x2 = Portal1.xp1;
			Player2Controll.y2 = Portal1.yp1;
			Gameobjekt2.transform.position = new Vector3(Portal2.xp2,Portal2.yp2,0f);
			Spawnradius2 = Mods.inttofloat(Spawnradius);
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
			if (i == 1){
				i = 0;
			}
			else{
				i = 1;
			}
			
		}
		xp2 = xx;
		yp2 = yy;
	}
	//xx == PlayerControll.Positionsx[z] && yy == PlayerControll.Positionsy[z]
}