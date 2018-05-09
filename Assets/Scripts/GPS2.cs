﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPS2 : MonoBehaviour
{
	public static GPS2 Instance { set; get; }

	public float latitude;
	public float longitude;

	public void Start()
	{
		Debug.Log ("Started GPS method");
		Instance = this;
		DontDestroyOnLoad(gameObject);
		StartCoroutine(StartLocationService());
	}

	private IEnumerator StartLocationService()
	{
		if (!Input.location.isEnabledByUser)
		{
			Debug.Log("User has not enabled GPS");
			yield break;
		}

		Input.location.Start();
		int maxWait = 20;
		while(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
		{
			yield return new WaitForSeconds(1);
			maxWait--;
		}

		if (maxWait <= 0)
		{
			Debug.Log("Timed out");
			yield break;
		}

		if (Input.location.status == LocationServiceStatus.Failed)
		{
			Debug.Log("Unable to determine device location");
			yield break;
		}

		latitude = Input.location.lastData.latitude;
		longitude = Input.location.lastData.longitude;

		yield break;
	}


}      