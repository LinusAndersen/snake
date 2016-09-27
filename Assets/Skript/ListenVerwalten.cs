using UnityEngine;
using System.Collections;

public class ListenVerwalten : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//eine Länge wird plus eins gerechnet
	public static int lenplus1 (int len){
		len = len + 1;
		return (len);
	}
	//eine variable wird in eine Liste eingefügt. Hierbei wird aber nochnicht die Länge geändert.
	public static float[] addtoList(float []neueListe,int len,float input,float []save){
		int l = 0;
		save = new float[len + 1];
		while (l < len) {
			save[l] = neueListe[l];
			l = l + 1;
		}
		l = 0;
		save [len] = input;
		neueListe = save;
		return (neueListe);
	}
	//hier wird die [0]. stelle einer Liste entfernt. Hierbei wird aber nochnicht die Länge geändert.
	public static float[] removethefirst(float[] Liste,float[]save,int len){
		int p = 0;
		save = new float[len - 1];
		while (p < len - 1) {
			save [p] = Liste [p + 1];
			p = p + 1;
		}
		p= 0;
		Liste = save;
		return(Liste);
	}
	// die Länge ist gleich die Länge minus 1;
	public static int lenminus1 (int len){
		len = len - 1;
		return (len);
	}
	//dies Zeigt an,
	public static float howoftenitcontains (float[] Liste,float Wert,int len){
		int i = 0;
		float z = 0;
		while (i < len){
			if (Liste [i] == Wert){
				z = z + 1;
			}
			i = i + 1;
		}

		return(z);
	} 
	public static float whereitcontains (float[] Liste,float Wert,int len,float welcher){
		int i = 0;
		float z = welcher;
		float y = 0;
		float savey = 0;
		while (i < len){
			if (Liste [i] == Wert){
				z = z - 1;
				if (z == 0){
					savey = y;
				}
			}
			i = i + 1;
			y = y + 1;
		}
		
		return(savey);
	}  
	//is on one place in two lists the same Value?
	public static bool Comparision(float [] Liste1,float[] Liste2, int len,float Wert,float Wert2){
		float p = 0;
		float o = 0;
		float h = howoftenitcontains(Liste1,Wert ,len ) - 1;
		float h2 = howoftenitcontains(Liste2,Wert2 ,len) - 1;
		float speicher = 0f;
		float speicher2 = 0f;
		bool b = false;
		while(p < howoftenitcontains(Liste1,Wert ,len ) - 1){
			p = p + 1f;
			speicher = whereitcontains(Liste1,Wert,len,h + 1f);
			h = h - 1f;
			o = 0f;
			while(o < howoftenitcontains(Liste2,Wert2 ,len) - 1 ){
				o = o + 1f;
				speicher2 = whereitcontains(Liste2,Wert2,len,h2 + 1f);
				h2 = h2 - 1f;
				if (speicher == speicher2){
					b = true;
				}
			}
			h2 = howoftenitcontains(Liste2,Wert2 ,len) - 1;
		}
		return(b);
	}
}