using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneChanges : MonoBehaviour {
	string LocalSceneName;
	GameObject LoadingIn, LoadingOut;
	public string SceneName;
	private InputField IFEnterLeaderboards;

	// Use this for initialization
	void Awake(){
		
	}

	void Start () {
		LoadingIn = GameObject.Find ("LoadingIn");
		LoadingOut = GameObject.Find ("LoadingOut");

		LoadingIn.SetActive (false);
		LoadingOut.SetActive (false);
		LoadingOut.SetActive (true);

		StartCoroutine(RemoveLoading(1.0f));
		if(SceneName != "Scene01_Intro"){
			

		}

	}

	// Update is called once per frame
	public void UpdateSceneByPass (string SceneName) {
		LocalSceneName = SceneName;
		StartCoroutine(ChangeSceneLocationIN(1.5f));

	}

	// Update is called once per frame
	public void UpdateScene (string SceneName) {
		LocalSceneName = SceneName;

		if (LocalSceneName != "Scene02_Game") {
			print ("Hello world");
			IFEnterLeaderboards = GameObject.Find ("IFEnterLeaderboards").GetComponent<InputField> ();
			string PlayerName = IFEnterLeaderboards.text;
			if (PlayerName != "") {
				StartCoroutine(ChangeSceneLocationIN(1.5f));
			}

		} else {
			StartCoroutine(ChangeSceneLocationIN(1.5f));
		}

	}

	IEnumerator ChangeSceneLocationIN(float Delay)
	{
		LoadingIn.SetActive (true);
		yield return new WaitForSeconds(Delay);
		if (ScreenTest.deviceIsIphoneX == true) {
			Application.LoadLevel (LocalSceneName + "PX");
		} else {
			if (ScreenTest.isTablet == true) {
				Application.LoadLevel (LocalSceneName);
			} else {
				LocalSceneName = LocalSceneName + "_Mobile";
				Application.LoadLevel (LocalSceneName);
			}
		}

	}

	IEnumerator RemoveLoading(float Delay)
	{
		
		yield return new WaitForSeconds(Delay);
		Destroy (LoadingOut);
	}
}
