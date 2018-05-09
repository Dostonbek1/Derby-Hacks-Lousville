using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour {
	public Text currentTime;
	public Button setAlarmBtn;
	public Button calibrate_btn;
	private string currentTime_text;
	string alarm1;
	public UIControl_setAlarm uiman;

	public void calibrateBtn_Press(){
		SceneManager.LoadScene("calibrate_Scene");
	}
	public void setAlarmBtn_Press(){
		SceneManager.LoadScene ("setAlarm_scene");
	}

	// Use this for initialization
	public void Start () {
		alarm1 = PlayerPrefs.GetString ("alarm1");
		Debug.Log (alarm1);



	}




	// Update is called once per frame
	void Update () {
		
		DateTime now = DateTime.Now;
		currentTime_text = now.ToString ("hh:mm tt");
		currentTime.text = currentTime_text;

		/*int timeStr = currentTime_text [0] + currentTime_text [1];
		int timeInt = System.Convert.ToInt32 (timeStr);
		if (timeInt > 12 && timeInt < 23) {
			timeInt = timeInt - 12;
			timeStr = timeInt;
			if (uiman.isAm) {
				currentTime.text = timeStr + ":" + uiman.temp2 + "AM";
			} else if (!uiman.isAm) {
				currentTime.text = timeStr + ":" + uiman.temp2 + "PM";
			}
		}*/

		if (currentTime.text == alarm1) {
			SceneManager.LoadScene ("alarmRing_Scene");
		} 



	


	}
}
