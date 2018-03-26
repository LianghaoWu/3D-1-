using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
	int [,] chess = new int[3,3];
	int player = 1;
	// Use this for initialization
	void Start () {
		reset ();
	}


	void OnGUI () {
		if (GUI.Button(new Rect(420,300,100,50),"重新开始")) reset();
		
		int result = isWin();
		if ( result == 1) {
			GUI.Label(new Rect(450,30,100,50),"O方胜利！");
			GUI.Label(new Rect(430,50,100,50),"请点击重新开始按钮重启游戏！");
		}
		else if (result == -1) {
			GUI.Label(new Rect(450,30,100,50),"X方胜利！");
			GUI.Label(new Rect(430,50,100,50),"请点击重新开始按钮重启游戏！");
		}
		else if (result == 2) {
			GUI.Label(new Rect(450,30,100,50),"平局！");
			GUI.Label(new Rect(430,50,100,50),"请点击重新开始按钮重启游戏！");
		}
		for (int i=0;i<3;i++) {
			for(int j=0;j<3;j++) {
				if(chess[i,j]==1) {
					GUI.Button(new Rect(400+i*50,100+j*50,50,50),"O");
				}
				if (chess[i,j]== -1) {
					GUI.Button(new Rect(400+i*50,100+j*50,50,50),"X");
				}
				if (GUI.Button(new Rect(400+i*50,100+j*50,50,50),"")) {
					if (result == 0) {
						chess[i,j]=player;
						player= -1*player;
					}
				}
			}
		}
	}

	void reset () {
		player = 1;
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				chess [i, j] = 0;
			}
		}
	}

	int isWin() {
		for (int i = 0; i < 3; i++) {
			if (chess [i, 0] != 0 && chess [i, 0] == chess [i, 1]&& chess [i, 1]== chess [i, 2]) {
				Debug.Log ("O");
				return chess [i, 0];
			}
		}
		for (int j = 0; j < 3; j++) {
			if (chess [0, j] != 0 && chess [0, j] == chess [1, j]&& chess [1, j]== chess [2, j]) {
				Debug.Log ("X");
				return chess [0, j];
			}
		}
		if (chess [1, 1] != 0 && chess [0, 0] == chess [1, 1] && chess [1, 1] == chess [2, 2] || chess [0, 2] == chess [1, 1] && chess [1, 1] == chess [2, 0]) {
			return chess [1, 1];
		}
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				if (chess [i, j] == 0) {
					return 0;
				}
			}
		}
		Debug.Log ("P");
		return 2;
	}
}
