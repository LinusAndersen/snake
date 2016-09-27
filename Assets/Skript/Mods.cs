using UnityEngine;
using System.Collections;

public class Mods : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static float inttofloat(int i){
		float f = 0;
		while (i > 0){
			i = i - 1;
			f = f + 1;
		}
		return(f);

	}
	public static float doubleintofloat(double i){
		float f = 0;
		while (i > 0){
			i = i - 1;
			f = f + 1;
		}
		return(f);
		
	}
	public static bool Collision(float x,float y,float x1,float y1, float xlen, float ylen){
		if (x - xlen < x1 && x + xlen > x1 && y - ylen < y1 && y + ylen > y1){
			return(true);
		}
		else {
			return (false);
		}
	}
	public static bool ListCollision(float x, float y, float[]xPos, float[] yPos,float xlen, float ylen, float Listlen,int start){
		int i = start;
		bool b = false;
		while (i < Listlen){
			if (Collision(x,y,xPos[i],yPos[i],xlen,ylen) == true){
				b = true;
			}
			i = i + 1;
		}
		return (b);
	}
}