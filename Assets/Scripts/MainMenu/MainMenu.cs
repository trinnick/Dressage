/* Created By: Douglas A. Stewart
 * Project Duration: Fall 2012
 * Purpose: Capstone Project for UHCL Masters of Sceince in Software Engineering
*/
using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	Texture btnTexture;
	Texture btnView;
		
	void  OnGUI (){
		GUI.depth = 10;
		GUI.Box (new Rect (Screen.width/2 - 150,Screen.height/2 - 75,300,300), "");
		GUI.Label (new Rect (Screen.width/2 - 40, Screen.height/2 - 70, 80, 20), "Start Menu");
		GUI.Label(new Rect(Screen.width/2 -130, Screen.height/2 - 50, 100, 20), "Select a Test");
		GUI.backgroundColor = Color.green;
 	  	if(GUI.Button( new Rect(Screen.width/2 + 75,Screen.height/2,50,20),"Start")) 
 	  		Application.LoadLevel(1);
		GUI.backgroundColor = Color.red;
 	  	if(GUI.Button( new Rect(Screen.width/2 + 75,Screen.height/2 + 25,50,20), "Quit")) 
 	  		Application.Quit();
		
		
	}
}