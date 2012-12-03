using System;
using UnityEngine;
using System.Collections;

public class GlobalSettings{
	
	private float rateOfMovement = 10.0f;
	private int levelSelect = 1;
	
	private string testName = "N/A";
	private string movementID = "N/A";
	private String[] movementDesc = {"N/A"};
	private String[] pathDesc = {"N/A"};
	private string sequence = "N/A";
	private String[] path = {"N/A"};
	private string gait = "N/A";
	
	private bool pause = false;
	private bool hudToggle = true;
	
	private string Camera1 = "CameraHorse";
	private string Camera2 = "CameraAbove";
	private string Camera3 = "CameraWestStand";
	private string Camera4 = "CameraEastStand";
	
	private string[] file = {
		"FirstLevelTest1",
		"FirstLevelTest2",
		"FirstLevelTest3",
		"SecondLevelTest1",
		"SecondLevelTest2",
		"SecondLevelTest3",
		"ThirdLevelTest1",
		"ThirdLevelTest2",
		"ThirdLevelTest3",
		"FourthLevelTest1",
		"FourthLevelTest2",
		"FourthLevelTest3"
	};
	
	private static string fileAddress = "";
	
	public GlobalSettings(){
	}
	
	/***********************Setters and Getters******************************/
	
	public int getLevelSelect(){
		return levelSelect;
	}
	
	public void setLevelSelect(int selected){
		levelSelect = selected;
	}
	
	public float getRateOfMovement(){
		return rateOfMovement;
	}
	
	public void setRateOfMovement(float rate){
		rateOfMovement = rate;
	}
	
	public string getCamera1(){
		return Camera1;
	}
	
	public void setCamera1(string c1){
		Camera1 = c1;
	}
	
	public string getCamera2(){
		return Camera2;
	}
	
	public void setCamera2(string c2){
		Camera2 = c2;
	}
	
	public string getCamera3(){
		return Camera3;
	}
	
	public void setCamera3(string c3){
		Camera3 = c3;
	}
	
	public string getCamera4(){
		return Camera4;
	}
	
	public void setCamera4(string c4){
		Camera4 = c4;
	}
	
	public bool getPause(){
		return pause;
	}
	
	public void setPause(bool p){
		pause = p;
	}
	
	public bool getHUDToggle(){
		return hudToggle;
	}
	
	public void setHUDToggle(bool hud){
		hudToggle = hud;
	}
	
	public String[] getPathDesc(){
		return pathDesc;
	}
	
	public void setPathDesc(String[] path){
		pathDesc = path;
	}
	
	public string getFileAddress(){
		return fileAddress;
	}
	
	public void setFileAddress(int i){
		fileAddress = file[i];
	}
	
	public String[] getMovementDesc(){
		return movementDesc;
	}
	
	public void setMovementDesc(String[] mDesc){
		movementDesc = mDesc;
	}
	
	public string getMovementID(){
		return movementID;
	}
	
	public void setMovementID(string id){
		movementID = id;
	}
	
	public string getSequence(){
		return sequence;
	}
	
	public void setSequence(string seq){
		sequence = seq;
	}
	
	public string getTestName(){
		return testName;
	}
	
	public void setTestName(string tName){
		testName = tName;
	}
	
	public String[] getPath(){
		return movementDesc;
	}
	
	public void setPath(String[] p){
		path = p;
	}
	
	public string getGait(){
		return gait;
	}
	
	public void setGait(string g){
		gait = g;
	}
}
