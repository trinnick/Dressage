using UnityEngine;
using System.Xml;
using System;
using System.Collections;

public class HorseMovement : MonoBehaviour {
	
	//Reference to the class where all variables are stored
	public GlobalSettings gs = new GlobalSettings();
	
	// Use this for initialization
	IEnumerator Start () {
		yield return StartCoroutine(LoadXML());
	}
	
	//This method takes the external file selected in the GlobalSettings class
	//and loads the XML file into temporary object
	IEnumerator LoadXML(){
		//Load XML data from external file (In this case from a url web address)
		//This is collected from the Global Settings script
		string dir = gs.getFileAddress();
		TextAsset xml = (TextAsset) Resources.Load(dir);
		
		//Wait for complete download of external file from url source above.
		yield return xml;
		//Create new XML document from loaded data
		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.LoadXml(xml.text);
		
		//This is important to set a yield return, since the program
		//would continue to run normally without the yeild. What we want it
		//to do is run the Coroutine and have the program run through the frame
		//exectution as normal.
		yield return StartCoroutine(ExtractMovement(xmlDoc));	
	}
	
	//This method extracts the data from the temporary XML object and places it
	//in runtime movement object that will be processed on the spot.
	IEnumerator ExtractMovement(XmlDocument xml){
		Movement movement;
		
		//Set the name of the test being run in the global variable
		gs.setTestName(xml.SelectSingleNode("Test/Name").InnerText);

		//Move through each tagged item within the xml document
		foreach (XmlNode node in xml.SelectNodes("Test/Movement")){
			movement = new Movement();

			//Extract and assign tagged items within the xmlDoc to object variables within Movement class
			movement.MovementID = node.SelectSingleNode("MovementId").InnerText;
			movement.MovementDesc = node.SelectSingleNode("MovementDesc").InnerText;

			//Assign MovementDetails to Movement Class variables
			foreach (XmlNode detail in node.SelectNodes("MovementDetail")){
				movement.Sequence = detail.SelectSingleNode("SequenceId").InnerText;
				movement.Path = detail.SelectSingleNode("Path").InnerText;
				movement.PathDesc = detail.SelectSingleNode("PathDesc").InnerText;
				movement.Gait = detail.SelectSingleNode("Gait").InnerText;

				//Call LoadMovement Coroutine method and pass movement object
				//and wait for the finish of Coroutine to process further information.
				yield return StartCoroutine(ProcessMovement(movement));
			}
		}
	}
	
	//Process movements based on collected variable information
	IEnumerator ProcessMovement(Movement movement){
		
		//Set temporary holders of 3D position coordinates for 
		//extracted waypoints
		Vector3 firstPosition = new Vector3();
		Vector3 secondPosition = new Vector3();
		Vector3 thirdPosition = new Vector3();
		Vector3 fourthPosition = new Vector3();
		Vector3 fifthPosition = new Vector3();

		//Split the string of path and place in array elements based on seperator character -
		String[] path = movement.Path.Split('-');
		String[] pathDesc = movement.PathDesc.Split('_');
		
		//Set global variables of movement data to be used elsewhere in the application
		gs.setMovementID(movement.MovementID);
		gs.setMovementDesc(movement.MovementDesc.Split('.'));		
		gs.setSequence(movement.Sequence);
		gs.setGait(movement.Gait);
		gs.setPath(path);
		gs.setPathDesc(pathDesc);
		
		//Assign the firstPosition based on the first element of the array path
		firstPosition = GameObject.Find(path[0]).transform.position;

		//Assign the secondPosition based on the second elemnt of the array path
		//The GameObject.Find function allows for you to find any game object
		//created in the GUI game editor based on it's name (this was extracted
		//from the path at array index of 1 when having split it from the original
		//string earlier
		secondPosition = GameObject.Find(path[1]).transform.position;

		//If there is a third element in path, assign it to the thirdPosition variable
		if(path.Length >= 3){
			thirdPosition = GameObject.Find(path[2]).transform.position;
		}

		//If there is a fourth element in path, assign it to the fourthPosition variable
		if(path.Length >= 4){
			fourthPosition = GameObject.Find(path[3]).transform.position;
		}

		//If there is a fifth element in path, assign it to the fifthPosition variable
		if(path.Length >= 5){
			fifthPosition = GameObject.Find(path[4]).transform.position;
		}

		if(movement.PathDesc == "Line" || movement.PathDesc =="Diagonal"){

			//Call movement based on Coroutine and yield commands

			if(path.Length>=2){
				yield return StartCoroutine(StraightLinePath(firstPosition,secondPosition));
			}

			if(path.Length >= 3){
				yield return StartCoroutine(StraightLinePath(secondPosition,thirdPosition));
			}

			if(path.Length >= 4){
				yield return StartCoroutine(StraightLinePath(thirdPosition,fourthPosition));
			}

			if(path.Length >= 5){
				yield return StartCoroutine(StraightLinePath(fourthPosition,fifthPosition));
			}
		}
		//If it isn't a straightline path, check for the type of arcs created
		else{						
			if(pathDesc[0] == "HalfCircle"){
				yield return StartCoroutine(HalfCirclePath(firstPosition,secondPosition,pathDesc[3], path[0], path[1], float.Parse(pathDesc[2])));
			}
			if(pathDesc[0] == "FullCircle"){
				float diameter = float.Parse(gs.getPathDesc()[2]);
				yield return StartCoroutine(FullCirclePath(firstPosition,diameter,path[0], pathDesc[1]));
			}
			if(pathDesc[0] == "Serpentine"){
				yield return StartCoroutine(SerpentinePath(firstPosition,secondPosition,pathDesc[1]));
			}
		}				
	}

	void OnGUI(){				
		String movementDescFormatted = null;
		
		String[] movementDescUnformatted = gs.getMovementDesc();
		for(int i=0;i<movementDescUnformatted.Length;i++){
			movementDescFormatted +=  "\n" + movementDescUnformatted[i];
		}
		
		if(gs.getHUDToggle()){
			GUI.Box (new Rect (0,0,300,120), "Movement Description:\n" + movementDescFormatted);
			GUI.Box (new Rect (Screen.width/2 - 75,0,150,50), "Test: \n" + gs.getTestName());
			GUI.Box (new Rect (Screen.width - 100,0,100,50), "Movement ID: \n" + gs.getMovementID());
			GUI.Box (new Rect (Screen.width - 100,55,100,50), "Sequence: \n" + gs.getSequence());
			GUI.Box (new Rect (Screen.width - 150,110,150,50), "Path Description: \n" + gs.getPathDesc()[0]);
		}
		
		if(gs.getPause()){
			GUI.Box (new Rect (Screen.width/2 - 100, Screen.height/2 - 50, 200, 300), "");
			GUI.Label (new Rect (Screen.width/2 - 30, Screen.height/2 - 40, 60, 20), "PAUSED");
			GUI.backgroundColor = Color.green;
			if(GUI.Button (new Rect (Screen.width/2 - 80, Screen.height/2 - 10, 75, 20), "Resume")){
				gs.setPause(false);
			}
			GUI.backgroundColor = Color.red;
			if(GUI.Button (new Rect (Screen.width/2, Screen.height/2 - 10, 75, 20), "Exit Test")){
				Application.LoadLevel(0);
			}
			GUI.Label (new Rect (Screen.width/2 - 30, Screen.height/2 + 20, 60, 20), "Hotkeys");
			GUI.Box (new Rect (Screen.width/2 - 90, Screen.height/2 + 40, 180, 100), 
				"Spacebar = Pause\n" +
				"Alpha 1 = 3rd Person View\n" +
				"Alpha 2 = Top-Down View\n" +
				"Alpha 3 = West Stand View\n" +
				"Alpha 4 = East Stand View\n" +
				"Down Arrow = HUD Toggle");
		}
	}
	
	void Update(){
		CameraToggle tg = new CameraToggle();
		
		//This was put here, because the system doesn't listen for
		//input from the OnGUI method
		if(Input.GetKeyDown(KeyCode.DownArrow) && gs.getHUDToggle() == false){
			gs.setHUDToggle(true);
		}
		else if(Input.GetKeyDown(KeyCode.DownArrow) && gs.getHUDToggle() == true){
			gs.setHUDToggle(false);
		}
			
		pauseMovement();	
		tg.toggle();
	}
	
	IEnumerator StraightLinePath(Vector3 first, Vector3 second){
	    float dist = Vector3.Distance(first, second);
	
	    for (float i = 0.0f; i < 1.0f; i += ((gs.getRateOfMovement() * Time.deltaTime)/dist)) {
	        transform.position = Vector3.Lerp(first, second, i);
			yield return null;		
	    }
	}
	
	IEnumerator HalfCirclePath(Vector3 first, Vector3 second, string direction, string markerOne, string markerTwo, float diameter){
		int arcDirection = 0;
		//Checking for whether it is up or down, we can assign direction
		if(direction == "Down"){
			arcDirection = 1;
		}
		
		if(direction == "Up"){
			arcDirection = -1;
		}
		
		float distance = Vector3.Distance(first,second);
		Vector3 radius =  new Vector3(arcDirection * distance,0.0f,0.0f)/2;
		
		if((markerOne == "H" && markerTwo == "K") || (markerOne == "K" && markerTwo == "H")){
			distance = 20.0f;
			radius =  new Vector3(0.0f,0.0f,arcDirection * distance)/2;
		}
		
		Vector3 center = (first + second)/2;
		Vector3 tempOne = first + radius;
		Vector3 tempTwo = second + radius;
		Vector3 midPoint = center + radius;
	    float dist = (float)Math.PI * (distance)/2;
	
	    for (float i = 0.0f; i < 1.0f; i += ((gs.getRateOfMovement() * Time.deltaTime)/dist)*2) {
	        Vector3 bp1 = Vector3.Lerp(first, tempOne, i);
	        Vector3 bp2 = Vector3.Lerp(tempOne, midPoint, i);
	
	        transform.position = Vector3.Lerp(bp1, bp2, i);
			yield return null;
	    }
	
	    for (float i = 0.0f; i < 1.0f; i += ((gs.getRateOfMovement() * Time.deltaTime)/dist)*2) {
	        Vector3 bp1 = Vector3.Lerp(midPoint, tempTwo, i);
	        Vector3 bp2 = Vector3.Lerp(tempTwo, second, i);
	
	        transform.position = Vector3.Lerp(bp1, bp2, i);
			yield return null;
	    }
	}
	
	IEnumerator FullCirclePath(Vector3 first, float diameter, string marker, string circleDirection){
		int circleDir = 0;
		/*
		 * Change the diameter so that the "horse" doesn't go over the
		 * top of the fence since the actual width of the arena is 20m
		*/
		if(diameter == 20){
			diameter = 18;
		}
		
		if(marker == "G" || marker == "I" || marker == "X" || marker == "L" || marker == "D"){
			diameter -= 1.0f;
		}
		
		float radius = (diameter)/2;
	    float dist = (float)Math.PI * (diameter);
		Vector3 second = new Vector3();
		int flip = 1;

		if(marker == "A" || marker == "C"){
			if(circleDirection == "Left"){
				circleDir = -1;
			}
			else{
				circleDir = 1;
			}
			if(marker == "A"){
				flip = -1;
			}
			second = new Vector3((flip * diameter) + first.x,first.y,first.z);
		}
			
		if(marker == "H" || marker == "S" || marker == "E" || marker == "V" || marker == "K" ||
			marker == "M" || marker == "R" || marker == "B" || marker == "P" || marker == "F"){
			if(circleDirection == "Left"){
				circleDir = 1;
			}
			else{
				circleDir = -1;
			}
			if(marker == "M" || marker == "R" || marker == "B" || marker == "P" || marker == "F"){
				flip = -1;
			}
			second = new Vector3(first.x,first.y,(flip * diameter) + first.z);
		}
			
		if(marker == "G" || marker == "I" || marker == "X" || marker == "L" || marker == "D"){
			if(circleDirection == "Left"){
				circleDir = 1;
				flip = -1;
			}
			else{
				circleDir = -1;
			}
			second = new Vector3(first.x,first.y,(flip * diameter) + first.z);
		}
		
		float distance = Vector3.Distance(first,second);
		
		radius *= flip;
		
		for (int x = 0; x < 2; x++){
			Vector3 tempOne = new Vector3();
			Vector3 tempTwo = new Vector3();
			Vector3 midPoint = new Vector3();
			
			if(marker == "A" || marker == "C"){
				Vector3 center = new Vector3(radius + first.x,first.y,first.z);
				tempOne = new Vector3(first.x,first.y,(circleDir * radius) + first.z);
				tempTwo = new Vector3(second.x,second.y,(circleDir * radius) + second.z);
				midPoint = new Vector3(center.x,center.y,(circleDir * radius) + center.z);
			}
			
			else{
				Vector3 center = new Vector3(first.x,first.y,radius + first.z);
				tempOne = new Vector3((circleDir * radius) + first.x,first.y,first.z);
				tempTwo = new Vector3((circleDir * radius) + second.x,second.y,second.z);
				midPoint = new Vector3((circleDir * radius) + center.x,center.y,center.z);
			}
		
		    for (float i = 0.0f; i < 1.0f; i += ((gs.getRateOfMovement() * Time.deltaTime)/dist)*4) {
		        Vector3 bp1 = Vector3.Lerp(first, tempOne, i);
		        Vector3 bp2 = Vector3.Lerp(tempOne, midPoint, i);
		
		        transform.position = Vector3.Lerp(bp1, bp2, i);
				yield return null;
		    }
		
		    for (float i = 0.0f; i < 1.0f; i += ((gs.getRateOfMovement() * Time.deltaTime)/dist)*4) {
		        Vector3 bp1 = Vector3.Lerp(midPoint, tempTwo, i);
		        Vector3 bp2 = Vector3.Lerp(tempTwo, second, i);
		
		        transform.position = Vector3.Lerp(bp1, bp2, i);
				yield return null;
		    }
			
			radius *= -1;
			Vector3 reversal = first;
			first = second;
			second = reversal;
		}
	}
	
	IEnumerator SerpentinePath(Vector3 first, Vector3 second, string side){
		int flip = -1;
		int direction = 1;
		
		if(side == "Right"){
			direction = -1;
		}
		if(side == "Left"){
			direction = 1;
		}
		
		float distance = Vector3.Distance(first,second);
		Vector3 diameter = new Vector3(0.0f,0.0f,18.0f); //Width of arena
		Vector3 radius =  flip * (diameter/2);
		Vector3 oneThird = new Vector3(direction * distance/3.0f,0.0f,0.0f);
		
		
		Vector3 center = first + (oneThird/2);
		Vector3 tempOne = first + radius;
		second = first + oneThird;
		Vector3 tempTwo = second + radius;
		Vector3 midPoint = center + radius;
	    float dist = (float)Math.PI * (18.0f/2.0f) * 3.0f;
	
		for (int x = 0; x < 3; x++){
		    for (float i = 0.0f; i < 1.0f; i += ((gs.getRateOfMovement() * Time.deltaTime)/dist)*6) {
		        Vector3 bp1 = Vector3.Lerp(first, tempOne, i);
		        Vector3 bp2 = Vector3.Lerp(tempOne, midPoint, i);
		
		        transform.position = Vector3.Lerp(bp1, bp2, i);
				yield return null;
		    }
		
		    for (float i = 0.0f; i < 1.0f; i += ((gs.getRateOfMovement() * Time.deltaTime)/dist)*6) {
		        Vector3 bp1 = Vector3.Lerp(midPoint, tempTwo, i);
		        Vector3 bp2 = Vector3.Lerp(tempTwo, second, i);
		
		        transform.position = Vector3.Lerp(bp1, bp2, i);
				yield return null;
		    }
			flip *= -1;
			first += oneThird;
			tempOne += oneThird + (flip * diameter);
			midPoint += oneThird + (flip * diameter);
			tempTwo += oneThird + (flip * diameter);
			second += oneThird;
		}
	}
	
	public void pauseMovement(){
			if(Input.GetKeyDown(KeyCode.Space) && gs.getPause() == false){
				gs.setPause(true);
			}
			else if(Input.GetKeyDown(KeyCode.Space) && gs.getPause() == true){
				gs.setPause(false);
			}
			
			if(gs.getPause() == true){
				Time.timeScale = 0;
			}
			
			else if(gs.getPause() == false){
				Time.timeScale = 1;
			}		
	}
}