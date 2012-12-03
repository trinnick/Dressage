/* Reference Source: http://wiki.unity3d.com/index.php?title=PopupList
 * Project Duration: Fall 2012
 * Purpose: Capstone Project for UHCL Masters of Sceince in Software Engineering
*/
using UnityEngine;
using System.Collections;
 
public class TestSelection : MonoBehaviour
{
	GlobalSettings gs = new GlobalSettings();
	
	GUIContent[] comboBoxList;
	private ComboBox comboBoxControl;// = new ComboBox();
	private GUIStyle listStyle = new GUIStyle();
 
	private void Start()
	{
		//This is the list that we want to show up in our combobox options
		comboBoxList = new GUIContent[12];
		comboBoxList[0] = new GUIContent("First Level Test 1");
		comboBoxList[1] = new GUIContent("First Level Test 2");
		comboBoxList[2] = new GUIContent("First Level Test 3");
		comboBoxList[3] = new GUIContent("Second Level Test 1");
		comboBoxList[4] = new GUIContent("Second Level Test 2");
		comboBoxList[5] = new GUIContent("Second Level Test 3");
		comboBoxList[6] = new GUIContent("Third Level Test 1");
		comboBoxList[7] = new GUIContent("Third Level Test 2");
		comboBoxList[8] = new GUIContent("Third Level Test 3");
		comboBoxList[9] = new GUIContent("Fourth Level Test 1");
		comboBoxList[10] = new GUIContent("Fourth Level Test 2");
		comboBoxList[11] = new GUIContent("Fourth Level Test 3");
 
		listStyle.normal.textColor = Color.white; 
		listStyle.onHover.background =
		listStyle.hover.background = new Texture2D(2, 2);
		listStyle.padding.left =
		listStyle.padding.right =
		listStyle.padding.top =
		listStyle.padding.bottom = 4;
 
		comboBoxControl = new ComboBox(new Rect(Screen.width/2 -130, Screen.height/2 - 25, 150, 20), comboBoxList[0], comboBoxList, "button", "box", listStyle);
	}
 
	private void OnGUI () 
	{
		//This will be only drawn at the initial start of the scene, because of the above code being processed in start
		GUI.depth = 1;
		gs.setFileAddress(comboBoxControl.Show());
	}
}