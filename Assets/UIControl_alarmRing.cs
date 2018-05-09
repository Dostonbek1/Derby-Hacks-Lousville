using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class UIControl_alarmRing : MonoBehaviour {
	public GPS2 localGPS;
	public string bedPosLon;
	public string bedPosLat;
	public string curPosLon;
	public string curPosLat;
	public string setDist;
	public double curDist;
	public Button stopButton;
	public AudioSource audioAlarm;
	public Text currentTime;
	public Text curposlontext;
	public Text curposlattext;
	private string currentTime_text;

	void Start(){
		//localGPS.Start ();
	
	}
	/*public void Start(){
		bedPosLon = PlayerPrefs.GetString ("bedCornLon");
		bedPosLat = PlayerPrefs.GetString ("bedCornLat");
		setDist = PlayerPrefs.SetString ("setDist");
	}*/
	public void snoozeBtn_Press(){
		audioAlarm.volume = audioAlarm.volume + 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		DateTime now = DateTime.Now;
		currentTime_text = now.ToString ("hh:mm tt");
		currentTime.text = currentTime_text;
		setDist = PlayerPrefs.GetString ("setDist");
		localGPS.Start ();
		StartCoroutine("callGPS");
		curposlontext.text = PlayerPrefs.GetString ("curPosLon").ToString();
		curposlattext.text = PlayerPrefs.GetString ("curPosLat").ToString();

		findCurDist ();
		double setDistTemp;
		Double.TryParse(setDist, out setDistTemp);
		if (curDist >= setDistTemp) {
			stopButton.interactable = true;

		}
		Debug.Log ("Loop running");

	}

	IEnumerator callGPS(){
		yield return new WaitForSeconds (4); 
		PlayerPrefs.SetString ("curPosLon", GPS.Instance.longitude.ToString());
		PlayerPrefs.SetString ("curPosLat", GPS.Instance.latitude.ToString());

		findCurDist ();

	}

	public void findCurDist(){
		double x1;
		Double.TryParse(curPosLon, out x1);
		double x2;
		Double.TryParse(bedPosLon, out x2);
		double y1;
		Double.TryParse(curPosLat, out y1);
		double y2;
		Double.TryParse(bedPosLat, out y2);
		curDist = System.Math.Sqrt ((x1-x2)*(x1-x2) + (y1 - y2)*(y1-y2));
	}
	public void stopButton_Press(){
		audioAlarm.Stop ();
		SceneManager.LoadScene ("main_Scene");
	}
}
