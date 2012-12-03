/* Created By: Douglas A. Stewart
 * Project Duration: Fall 2012
 * Purpose: Capstone Project for UHCL Masters of Sceince in Software Engineering
*/using UnityEngine;
using System;
using System.Collections;

public class CameraToggle{

	public void toggle() {
		
		GlobalSettings gs = new GlobalSettings();
			
		//The following if statements run if specified keys are pressed and change the current camera depth, higher shows on top
		if (Input.GetKeyDown(KeyCode.Alpha1)){
			GameObject.Find(gs.getCamera1()).camera.depth = 1;
			GameObject.Find(gs.getCamera2()).camera.depth = 0;
			GameObject.Find(gs.getCamera3()).camera.depth = 0;
			GameObject.Find(gs.getCamera4()).camera.depth = 0;
	    }
	
		if (Input.GetKeyDown(KeyCode.Alpha2)){
			GameObject.Find(gs.getCamera1()).camera.depth = 0;
			GameObject.Find(gs.getCamera2()).camera.depth = 1;
			GameObject.Find(gs.getCamera3()).camera.depth = 0;
			GameObject.Find(gs.getCamera4()).camera.depth = 0;
	    }
	
		if (Input.GetKeyDown(KeyCode.Alpha3)){
			GameObject.Find(gs.getCamera1()).camera.depth = 0;
			GameObject.Find(gs.getCamera2()).camera.depth = 0;
			GameObject.Find(gs.getCamera3()).camera.depth = 1;
			GameObject.Find(gs.getCamera4()).camera.depth = 0;
	    }
	
		if (Input.GetKeyDown(KeyCode.Alpha4)){
			GameObject.Find(gs.getCamera1()).camera.depth = 0;
			GameObject.Find(gs.getCamera2()).camera.depth = 0;
			GameObject.Find(gs.getCamera3()).camera.depth = 0;
			GameObject.Find(gs.getCamera4()).camera.depth = 1;
	    }
	}
}
