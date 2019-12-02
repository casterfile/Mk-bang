using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoards : MonoBehaviour {
	
	private GameObject Leaderboards;
	private Text ScoreListName1, ScoreListScore1;
	private Text ScoreListName2, ScoreListScore2;
	private Text ScoreListName3, ScoreListScore3;
	private Text ScoreListName4, ScoreListScore4;
	private Text ScoreListName5, ScoreListScore5;
	private Text ScoreListName6, ScoreListScore6;
	private Text ScoreListName7, ScoreListScore7;
	private Text ScoreListName8, ScoreListScore8;
	private Text ScoreListName9, ScoreListScore9;
	private Text ScoreListName10, ScoreListScore10;
	// Use this for initialization
	void Start () {
		ScoreListName1 = GameObject.Find ("Leaderboards/Form/ScoreList/Number (1)/Name").GetComponent<Text>();
		ScoreListScore1 = GameObject.Find ("Leaderboards/Form/ScoreList/Number (1)/Score").GetComponent<Text>();

		ScoreListName2 = GameObject.Find ("Leaderboards/Form/ScoreList/Number (2)/Name").GetComponent<Text>();
		ScoreListScore2 = GameObject.Find ("Leaderboards/Form/ScoreList/Number (2)/Score").GetComponent<Text>();

		ScoreListName3 = GameObject.Find ("Leaderboards/Form/ScoreList/Number (3)/Name").GetComponent<Text>();
		ScoreListScore3 = GameObject.Find ("Leaderboards/Form/ScoreList/Number (3)/Score").GetComponent<Text>();

		ScoreListName4 = GameObject.Find ("Leaderboards/Form/ScoreList/Number (4)/Name").GetComponent<Text>();
		ScoreListScore4 = GameObject.Find ("Leaderboards/Form/ScoreList/Number (4)/Score").GetComponent<Text>();

		ScoreListName5 = GameObject.Find ("Leaderboards/Form/ScoreList/Number (5)/Name").GetComponent<Text>();
		ScoreListScore5 = GameObject.Find ("Leaderboards/Form/ScoreList/Number (5)/Score").GetComponent<Text>();

		ScoreListName6 = GameObject.Find ("Leaderboards/Form/ScoreList/Number (6)/Name").GetComponent<Text>();
		ScoreListScore6 = GameObject.Find ("Leaderboards/Form/ScoreList/Number (6)/Score").GetComponent<Text>();

		ScoreListName7 = GameObject.Find ("Leaderboards/Form/ScoreList/Number (7)/Name").GetComponent<Text>();
		ScoreListScore7 = GameObject.Find ("Leaderboards/Form/ScoreList/Number (7)/Score").GetComponent<Text>();

		ScoreListName8 = GameObject.Find ("Leaderboards/Form/ScoreList/Number (8)/Name").GetComponent<Text>();
		ScoreListScore8 = GameObject.Find ("Leaderboards/Form/ScoreList/Number (8)/Score").GetComponent<Text>();

		ScoreListName9 = GameObject.Find ("Leaderboards/Form/ScoreList/Number (9)/Name").GetComponent<Text>();
		ScoreListScore9 = GameObject.Find ("Leaderboards/Form/ScoreList/Number (9)/Score").GetComponent<Text>();

		ScoreListName10 = GameObject.Find ("Leaderboards/Form/ScoreList/Number (10)/Name").GetComponent<Text>();
		ScoreListScore10 = GameObject.Find ("Leaderboards/Form/ScoreList/Number (10)/Score").GetComponent<Text>();

//		int count= 0;
//		for(int x=0; x <= 10; x++){
//			count = x;
//			PlayerPrefs.SetString ("ScoreListName"+count, "Name"+count);
//			PlayerPrefs.SetString ("ScoreListScore"+count, "Score"+count);
//
//			print (PlayerPrefs.GetString("ScoreListName"+count));
//			print (PlayerPrefs.GetString("ScoreListScore"+count));
//		}



		Leaderboards = GameObject.Find ("Leaderboards");
		Leaderboards.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		ScoreListName1.text = PlayerPrefs.GetString("ScoreListName1");
		ScoreListScore1.text =  PlayerPrefs.GetString("ScoreListScore1");

		ScoreListName2.text = PlayerPrefs.GetString("ScoreListName2");
		ScoreListScore2.text =  PlayerPrefs.GetString("ScoreListScore2");

		ScoreListName3.text = PlayerPrefs.GetString("ScoreListName3");
		ScoreListScore3.text =  PlayerPrefs.GetString("ScoreListScore3");

		ScoreListName4.text = PlayerPrefs.GetString("ScoreListName4");
		ScoreListScore4.text =  PlayerPrefs.GetString("ScoreListScore4");

		ScoreListName5.text = PlayerPrefs.GetString("ScoreListName5");
		ScoreListScore5.text =  PlayerPrefs.GetString("ScoreListScore5");

		ScoreListName6.text = PlayerPrefs.GetString("ScoreListName6");
		ScoreListScore6.text =  PlayerPrefs.GetString("ScoreListScore6");

		ScoreListName7.text = PlayerPrefs.GetString("ScoreListName7");
		ScoreListScore7.text =  PlayerPrefs.GetString("ScoreListScore7");

		ScoreListName8.text = PlayerPrefs.GetString("ScoreListName8");
		ScoreListScore8.text =  PlayerPrefs.GetString("ScoreListScore8");

		ScoreListName9.text = PlayerPrefs.GetString("ScoreListName9");
		ScoreListScore9.text =  PlayerPrefs.GetString("ScoreListScore9");

		ScoreListName10.text = PlayerPrefs.GetString("ScoreListName10");
		ScoreListScore10.text =  PlayerPrefs.GetString("ScoreListScore10");
	}

	public void LeaderboardsShow(){
		Leaderboards.SetActive (true);
	}

	public void LeaderboardsHide(){
		Leaderboards.SetActive (false);
	}

}
