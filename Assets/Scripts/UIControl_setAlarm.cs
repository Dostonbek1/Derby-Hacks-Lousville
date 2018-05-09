using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIControl_setAlarm : MonoBehaviour {
	string hours;
	string mins;
	public InputField hoursIF;
	public InputField minsIF;
	public Button amBtn;
	public Button pmBtn;
	public string temp1;
	public string temp2;
	public bool isAm = true;
	public void Update(){
		temp1 = hoursIF.text;
		temp2 = minsIF.text;
	}
	public void saveButton_Press(){
		temp1 = hoursIF.text;
		temp2 = minsIF.text;
		if (isAm) {
			string curTime = temp1 + ":" + temp2 + " AM";
			PlayerPrefs.SetString ("alarm1", curTime);
		} else if (!isAm) {
			string curTime = temp1 + ":" + temp2 + " PM";
			PlayerPrefs.SetString ("alarm1", curTime);
		}


	}
	public void backButton_Press(){
		SceneManager.LoadScene ("main_Scene");
	}
	public void setAlarmBtn_Click() {
		SceneManager.LoadScene ("setAlarm_scene");
	}
	public void amBtn_Press(){
		amBtn.interactable = false;
		pmBtn.interactable = true;
		isAm = true;
	}
	public void pmBtn_Press(){
		pmBtn.interactable = false;
		amBtn.interactable = true;
		isAm = false;
	}
}
