using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
	float [] test = new float[4];
	float [] test2 = new float[4];
	int len = 4;
	void Start () {
		test[0] = 1f;
		test[1] = 2f;
		test[2] = 1f;
		test[3] = 1f;
		test2[0] = 2f;
		test2[1] = 1f;
		test2[2] = 1f;
		test2[3] = 2f;
		Debug.Log(ListenVerwalten.Comparision(test,test2, len,test[0],test2[0]));
	}
	void FixedUpdate(){

	}


}
