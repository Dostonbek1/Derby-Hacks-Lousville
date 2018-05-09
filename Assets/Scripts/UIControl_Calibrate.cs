using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;
using System;
using UnityEngine.SceneManagement;
public class UIControl_Calibrate : MonoBehaviour {
	public GPS localGPS;
	public Text checkIfDone;
	public Text bedLonText;
	public Text bedLatText;
	public Text batLonText;
	public Text batLatText;
	public Text setDistText;
	public Text setDistXText;
	public Text setDistYText;
	public Button bedBtn;
	public Button batBtn;
	public Button backBtn;
	public double setDist;
	//Use this for initialization
	void Start(){
		//PlayerPrefs.DeleteAll ();
		int hasCalibrated;
		hasCalibrated = PlayerPrefs.GetInt ("hasCalibrated");
		if (hasCalibrated==1) {
			bedBtn.interactable = false;
		}


	}

	void Update () {
		bedLonText.text = PlayerPrefs.GetString ("bedCornLon");
		bedLatText.text = PlayerPrefs.GetString("bedCornLat");
		batLonText.text = PlayerPrefs.GetString ("batCornLon");
		batLatText.text = PlayerPrefs.GetString("batCornLat");
		findSetDist ();
	}
	
	public void bedCord(){
		bedBtn.interactable = false;
		checkIfDone.text = "Please Wait..";
		localGPS.Start ();
		StartCoroutine ("waitFiveSecondsBed");
		string bedCordLon = PlayerPrefs.GetString ("bedCornLon");
		string bedCordLat = PlayerPrefs.GetString ("bedCornLat");

		batBtn.interactable = true;
	}
	public void bathroomCord(){
		batBtn.interactable = false;
		checkIfDone.text = "Please Wait..";
		localGPS.Start ();
		StartCoroutine ("waitFiveSecondsBat");
		string batCordLon = PlayerPrefs.GetString ("batCornLon");
		string batCordLat = PlayerPrefs.GetString ("batCornLat");

	}
	IEnumerator waitFiveSecondsBed(){
		yield return new WaitForSeconds (5);
		PlayerPrefs.SetString ("bedCornLon", GPS.Instance.longitude.ToString());
		PlayerPrefs.SetString ("bedCornLat", GPS.Instance.latitude.ToString());
		checkIfDone.text = "Done calibrating bed.";
	}
	IEnumerator waitFiveSecondsBat(){
		yield return new WaitForSeconds (5);
		PlayerPrefs.SetString ("batCornLon", GPS.Instance.longitude.ToString());
		PlayerPrefs.SetString ("batCornLat", GPS.Instance.latitude.ToString());
		checkIfDone.text = "Done calibrating bathroom.";
		findSetDist ();
		Debug.Log ("finSetDist called");
		PlayerPrefs.SetInt ("hasCalibrated", 1);
	}
	void findSetDist(){
		double x1;
		Double.TryParse(bedLonText.text, out x1);
		double x2;
		Double.TryParse(batLonText.text, out x2);
		double y1;
		Double.TryParse(bedLatText.text, out y1);
		double y2;
		Double.TryParse(batLatText.text, out y2);
		setDist = System.Math.Sqrt ((x1-x2)*(x1-x2) + (y1 - y2)*(y1-y2));
		setDistText.text = setDist.ToString ();
		PlayerPrefs.SetString ("setDist", setDistText.text);
	}
	public void backButton_Press(){
		SceneManager.LoadScene ("main_Scene");
	}
}
