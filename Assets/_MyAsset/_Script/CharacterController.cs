using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour {
	public static int FoodDesire = 1;
	public static string Country = "Filipino";
	public static int ranData;
	public static int isEatting = 0;
	public static int ScoreCount = 0;
	public static int SpeedCounter = 1;
	public static string isPause = "NotPuase",isWhatPause = "";
	public static bool PublicSlowTime = false;
	public static bool PublicDelayRemoveLife = false;
	public static bool PublicOneLifeRemove = false;
	public static bool PublicChangeMind = false;
	public static bool isThinking = false;

	private GameObject TBubbleList;
	private GameObject  TBubbleList_Country, TBubbleList_Country_Food_1,TBubbleList_Country_Food_2,TBubbleList_Country_Food_3,TBubbleList_Country_Food_4,TBubbleList_Country_Food_5;
	private GameObject CharacterEating, CharacterStatic, Characterangry,CharacterDead;

	public static int LiveCount = 3;
	private bool isPowerUp = true;
	private int PowerUpLivesCount = 0;
	private int PowerUpTimeCount = 0;
	private GameObject Live1, Live2, Live3;
	private GameObject Live1_Anim, Live2_Anim, Live3_Anim;
	private GameObject LiveAdd_Heart0,LiveAdd_Heart1,LiveAdd_Heart2,LiveAdd_Heart3;
	private GameObject TimeSlow_Time0,TimeSlow_Time1,TimeSlow_Time2,TimeSlow_Time3;
	private Text ScoreText,TotalScore, HighScore;
	private GameObject Pause,Congrats,EnterLeaderboards,PowerUpsboards;
	private InputField IFEnterLeaderboards;
	private GameObject ThinkingBubble;

	private Coroutine VarEatChangesDelay;
	bool isEndGame = false;
	private GameObject ImmuneShow;
	// Use this for initialization
	void Start () {
//		PlayerPrefs.DeleteAll();
		PublicOneLifeRemove = false;
		PublicDelayRemoveLife = false;
		PublicSlowTime = false;
		PublicChangeMind = false;
		isThinking = false;
		isEndGame = false;

		isPause = "NotPuase";
		isWhatPause = "";
		LiveCount = 3;
		ScoreCount = 0;
		SpeedCounter = 1;
		FoodDesire = 1;
		isEatting = 0;

		if(PlayerPrefs.HasKey("PowerUpLivesCount")){
			PowerUpLivesCount = PlayerPrefs.GetInt ("PowerUpLivesCount");
		}

		if(PlayerPrefs.HasKey("PowerUpTimeCount")){
			PowerUpTimeCount = PlayerPrefs.GetInt ("PowerUpTimeCount");
		}

		if(PlayerPrefs.HasKey("HighScore")){
			MK_GetTop.HighestScore = PlayerPrefs.GetInt ("HighScore");
		}

		ImmuneShow = GameObject.Find ("ImmuneShow");
		ImmuneShow.SetActive (false);

		ThinkingBubble  = GameObject.Find ("ThinkingBubble");
		ThinkingBubble.SetActive (false);

		LiveAdd_Heart0 = GameObject.Find ("Powerup/LiveAdd/List/Heart0");
		LiveAdd_Heart1 = GameObject.Find ("Powerup/LiveAdd/List/Heart1");
		LiveAdd_Heart2 = GameObject.Find ("Powerup/LiveAdd/List/Heart2");
		LiveAdd_Heart3 = GameObject.Find ("Powerup/LiveAdd/List/Heart3");

		TimeSlow_Time0 = GameObject.Find ("Powerup/TimeSlow/List/Time0");
		TimeSlow_Time1 = GameObject.Find ("Powerup/TimeSlow/List/Time1");
		TimeSlow_Time2 = GameObject.Find ("Powerup/TimeSlow/List/Time2");
		TimeSlow_Time3 = GameObject.Find ("Powerup/TimeSlow/List/Time3");




		ScoreText = GameObject.Find ("Scorebar/ScoreText").GetComponent<Text>();
		TotalScore = GameObject.Find ("TotalScore").GetComponent<Text>();
		HighScore = GameObject.Find ("HighScore").GetComponent<Text>();
		Live1 = GameObject.Find ("Scorebar/Heart/Live1");
		Live2 = GameObject.Find ("Scorebar/Heart/Live2");
		Live3 = GameObject.Find ("Scorebar/Heart/Live3");

		Live1_Anim = GameObject.Find ("Scorebar/Heart/Live1_Anim");
		Live2_Anim = GameObject.Find ("Scorebar/Heart/Live2_Anim");
		Live3_Anim = GameObject.Find ("Scorebar/Heart/Live3_Anim");
		Live1_Anim.SetActive (false);
		Live2_Anim.SetActive (false);
		Live3_Anim.SetActive (false);

		Pause = GameObject.Find ("Pause");
		Congrats = GameObject.Find ("Congrats");
		EnterLeaderboards = GameObject.Find ("EnterLeaderboards");
		PowerUpsboards = GameObject.Find ("PowerUpsboards");
		IFEnterLeaderboards = GameObject.Find ("IFEnterLeaderboards").GetComponent<InputField>();

		TBubbleList = GameObject.Find ("TBubbleList");
		CharacterStatic = GameObject.Find ("Character/CharacterStatic");
		CharacterEating = GameObject.Find ("Character/CharacterEating");
		Characterangry = GameObject.Find ("Character/Characterangry");
		CharacterDead = GameObject.Find ("Character/CharacterDead");


		if(Country == "Filipino"){
			TBubbleList_Country = TBubbleList.transform.GetChild (0).gameObject;
		}

		TBubbleList_Country_Food_1 = TBubbleList_Country.transform.GetChild (0).gameObject;
		TBubbleList_Country_Food_2 = TBubbleList_Country.transform.GetChild (1).gameObject;
		TBubbleList_Country_Food_3 = TBubbleList_Country.transform.GetChild (2).gameObject;
		TBubbleList_Country_Food_4 = TBubbleList_Country.transform.GetChild (3).gameObject;
		TBubbleList_Country_Food_5 = TBubbleList_Country.transform.GetChild (4).gameObject;
		HideFood ();

//		StartCoroutine(EatWell(1.0f));

//		Invoke("CreateRandom", 2);
		//StartCoroutine (EatChangesDelay (1.0f));

		VarEatChangesDelay = StartCoroutine (EatChangesDelay (1.0f));

		CharacterStatic.SetActive(false);
		CharacterEating.SetActive(false);
		Characterangry.SetActive (false);
		CharacterDead.SetActive (false);
	}

	public void LiveAdd_HeartAdd(){
		if(LiveCount < 3){
			if(PowerUpLivesCount > 0){
				PowerUpLivesCount--;
				LiveCount++;
			}
		}
	}

	public void TimeSlow_TimeAdd(){
		if(PowerUpTimeCount > 0){
			PowerUpTimeCount--;
			PublicSlowTime = true;
			StartCoroutine (FuncSlowTime (30.0f));
		}

	}

	IEnumerator FuncSlowTime(float Delay)
	{
		
		yield return new WaitForSeconds(Delay);
		PublicSlowTime = false;
		print ("PublicSlowTime: "+PublicSlowTime);
	}

	private void PowerUp(){
		if(isPowerUp == true){
			LiveAdd_Heart0.SetActive (false);
			LiveAdd_Heart1.SetActive (false);
			LiveAdd_Heart2.SetActive (false);
			LiveAdd_Heart3.SetActive (false);

			TimeSlow_Time0.SetActive (false);
			TimeSlow_Time1.SetActive (false);
			TimeSlow_Time2.SetActive (false);
			TimeSlow_Time3.SetActive (false);

			if(PowerUpLivesCount == 0){
				LiveAdd_Heart0.SetActive (true);
			}else if(PowerUpLivesCount == 1){
				LiveAdd_Heart1.SetActive (true);
			}else if(PowerUpLivesCount == 2){
				LiveAdd_Heart2.SetActive (true);
			}else if(PowerUpLivesCount == 3){
				LiveAdd_Heart3.SetActive (true);
			}

			if(PowerUpTimeCount == 0){
				TimeSlow_Time0.SetActive (true);
			}else if(PowerUpTimeCount == 1){
				TimeSlow_Time1.SetActive (true);
			}else if(PowerUpTimeCount == 2){
				TimeSlow_Time2.SetActive (true);
			}else if(PowerUpTimeCount == 3){
				TimeSlow_Time3.SetActive (true);
			}

			if(PowerUpTimeCount == 0 && PowerUpLivesCount == 0){
				isPowerUp = false;
			}

		}else{
			LiveAdd_Heart0.SetActive (true);
			LiveAdd_Heart1.SetActive (false);
			LiveAdd_Heart2.SetActive (false);
			LiveAdd_Heart3.SetActive (false);

			TimeSlow_Time0.SetActive (true);
			TimeSlow_Time1.SetActive (false);
			TimeSlow_Time2.SetActive (false);
			TimeSlow_Time3.SetActive (false);
		}

		PlayerPrefs.SetInt("PowerUpTimeCount", PowerUpTimeCount);
		PlayerPrefs.SetInt("PowerUpLivesCount", PowerUpLivesCount);


	}

	public void PopUpForm(string FormName){
		isWhatPause = FormName;
	}

	public void BuyPowerUps(){
		PowerUpTimeCount = 3;
		PowerUpLivesCount = 3;
		PlayerPrefs.SetInt("PowerUpTimeCount", PowerUpTimeCount);
		PlayerPrefs.SetInt("PowerUpLivesCount", PowerUpLivesCount);
		print ("BuyPowerUps");
	}

	public void SavePlayerName(){
		string PlayerName = IFEnterLeaderboards.text;



		if (PlayerPrefs.HasKey ("SavePlayerScore")) {
			int ConStringToInt = int.Parse (PlayerPrefs.GetString ("SavePlayerScore"));
			MK_GetTop.HighestScore = ConStringToInt;
			MK_GetTop.LastScore = ScoreCount;
			if(MK_GetTop.HighestScore < MK_GetTop.LastScore){
				PlayerPrefs.SetString("SavePlayerName", PlayerName);
				PlayerPrefs.SetString("SavePlayerScore", ScoreCount+"");
				MK_RegisterUpdate.UpdateData = true;
				print ("ScoreCount: "+ScoreCount+ " PlayerName: "+PlayerName+ " ConStringToInt: "+ConStringToInt);
			}


		} else {
			PlayerPrefs.SetString("SavePlayerName", PlayerName);
			PlayerPrefs.SetString("SavePlayerScore", ScoreCount+"");
			MK_RegisterUpdate.UpdateData = true;
			print ("ScoreCount: "+ScoreCount+ " PlayerName: "+PlayerName);
		}



	}
	IEnumerator PlayerIsDead(float Delay)
	{
		if (LiveCount == 0) {
			CharacterStatic.SetActive (false);
			CharacterEating.SetActive (false);
			Characterangry.SetActive (false);

			CharacterDead.SetActive (true);
			isEatting = 3;
		} else {
			isPause = "Puase";
		}


		yield return new WaitForSeconds(1);
		yield return new WaitForSeconds(Delay);
		if (LiveCount == 0) {
			isEndGame = true;
			isWhatPause = "BuyNow2";
			//			isPause = "Puase";
		} else {
			isPause = "NotPuase";
		}
	}

	// Update is called once per frame
	void Update () {
		PowerUp ();

		if(LiveCount == 3){
			Live1.SetActive (true);
			Live2.SetActive (true);
			Live3.SetActive (true);
		}else if(LiveCount == 2){
			Live1.SetActive (true);
			Live2.SetActive (true);
			Live3.SetActive (false);

			Live3_Anim.SetActive (true);
		}else if(LiveCount == 1){
			Live1.SetActive (true);
			Live2.SetActive (false);
			Live3.SetActive (false);

			Live2_Anim.SetActive (true);
		}else if(LiveCount == 0){
			Live1.SetActive (false);
			Live2.SetActive (false);
			Live3.SetActive (false);

			Live1_Anim.SetActive (true);
			isPause = "Puase";
			if(isWhatPause == ""){
				StartCoroutine(PlayerIsDead(3.0f));
			}

		}




		if (isEndGame == true) {
			CharacterStatic.SetActive (false);
			CharacterEating.SetActive (false);
			Characterangry.SetActive (false);
			if (isWhatPause == "BuyNow2") {
				Congrats.SetActive (false);
				EnterLeaderboards.SetActive (false);
				PowerUpsboards.SetActive (true);
			} 
			if (isWhatPause == "CongratsScore") {
				EnterLeaderboards.SetActive (false);
				PowerUpsboards.SetActive (false);
				Congrats.SetActive (true);
			} 
			if (isWhatPause == "EnterLeaderboards") {
				Congrats.SetActive (false);
				PowerUpsboards.SetActive (false);
				EnterLeaderboards.SetActive (true);
			}
		} else {
//			print ("isEndGame: 2");
			if (isPause == "Puase") {
				if (LiveCount == 0) {
					isWhatPause = "BuyNow2";

				} else {
					if(PublicOneLifeRemove == false){
						Pause.SetActive (true);
						Congrats.SetActive (false);
						EnterLeaderboards.SetActive (false);
						PowerUpsboards.SetActive (false);
					}
				}
			} else {
				Pause.SetActive (false);
				Congrats.SetActive (false);
				EnterLeaderboards.SetActive (false);
				PowerUpsboards.SetActive (false);
			}
		}



		TotalScore.text = ScoreCount+"";
		HighScore.text = HighScore+"";

		MK_GetTop.LastScore = ScoreCount;

		if (MK_GetTop.HighestScore < MK_GetTop.LastScore) {
			HighScore.text = ScoreCount + "";
			MK_GetTop.HighestScore = ScoreCount;
			PlayerPrefs.SetInt("HighScore", MK_GetTop.HighestScore);
//			print ("HighScore1: "+ HighScore.text);
		} else {
			HighScore.text = MK_GetTop.HighestScore +"";
//			print ("HighScore2: "+ HighScore.text);
		}



		if (ScoreCount < 10) {
			ScoreText.text = "00000" + ScoreCount + "";
		} else if (ScoreCount < 100) {
			ScoreText.text = "0000" + ScoreCount + "";
		} else if (ScoreCount < 1000) {
			ScoreText.text = "000" + ScoreCount + "";
		}  else if (ScoreCount < 10000) {
			ScoreText.text = "00" + ScoreCount + "";
		}  else if (ScoreCount < 100000) {
			ScoreText.text = "0" + ScoreCount + "";
		} else {
			ScoreText.text = ""+ScoreCount+"";
		}


		if (LiveCount == 0) {
			CharacterStatic.SetActive (false);
			CharacterEating.SetActive (false);
			Characterangry.SetActive (false);
		} else {
			if (isEatting == 0) {
				CharacterStatic.SetActive (true);
				CharacterEating.SetActive (false);
				Characterangry.SetActive (false);

			} else if (isEatting == 1) {
				CharacterStatic.SetActive (false);
				CharacterEating.SetActive (true);
				Characterangry.SetActive (false);

			} else if (isEatting == 2) {
				CharacterStatic.SetActive (false);
				CharacterEating.SetActive (false);
				Characterangry.SetActive (true);
			}
		}


		if(FoodDesire == 2){
			FoodDesire = 0;

			if (ScoreCount >= 0) {
				isEatting = 2;
				if(PublicOneLifeRemove == false){
					StartCoroutine(FuncOneLifeRemove(4.0f));
					StartCoroutine(PlayerIsDead(2.0f));
//					CancelInvoke("EatWell");
//					StopCoroutine(VarEatChangesDelay);
//					StartCoroutine (EatChangesDelay (4));
					LiveCount--;
				}
				StartCoroutine(CharReturnStatic(1.0f));
			}
		}
		else if(FoodDesire == 1){
			


			if (ScoreCount > 0) {
				
				isEatting = 1;
				SpeedCounter = ScoreCount;
				//StartCoroutine (CharReturnStatic (1.0f));
			}


		}
	}

	//Creating Base on current Speed
	private void CreateRandom(){
		
		float Count = 10;

		if(CharacterController.SpeedCounter < 10){
			Count = 10;
		}else if(CharacterController.SpeedCounter < 20){
			Count = 9;
		}else if(CharacterController.SpeedCounter < 30){
			Count = 8;
		}

		float speedCount = Count;
		Invoke("EatWell", speedCount);

	}


	private void EatWell()
	{
		if(PublicDelayRemoveLife == false){
			PublicDelayRemoveLife = true;
		}
		HideFood ();

		float Count = 4;

		if(CharacterController.SpeedCounter < 10){
			Count = 4;
		}else if(CharacterController.SpeedCounter < 20){
			Count = 3;
		}else if(CharacterController.SpeedCounter < 30){
			Count = 2;
		}else if(CharacterController.SpeedCounter < 40){
			Count = 2;
		}

		float speedCount = Count;
		StartCoroutine (EatChangesDelay (speedCount));
	}



	IEnumerator EatChangesDelay(float Delay)
	{
		
		ThinkingBubble.SetActive (true);
		isThinking = true;
		HideFood ();
		yield return new WaitForSeconds(Delay);

//		if (ScoreCount > 5) {
//			ranData = Random.Range(1, 6);
//		} else {
//			ranData = Random.Range(1, 3);
//		}
		ranData = SpawnObject.LastRan;



//		print ("ranData: "+ranData);
		FoodDesire = 0;
		ThinkingBubble.SetActive (false);
		isThinking = false;
		if(ranData == 1){
			TBubbleList_Country_Food_1.SetActive (true);
		}else if(ranData == 2){
			TBubbleList_Country_Food_2.SetActive (true);
		}else if(ranData == 3){
			TBubbleList_Country_Food_3.SetActive (true);
		}else if(ranData == 4){
			TBubbleList_Country_Food_4.SetActive (true);
		}else if(ranData >= 5){
			TBubbleList_Country_Food_5.SetActive (true);
		}

		yield return new WaitForSeconds(3);
		PublicDelayRemoveLife = false;
		isThinking = false;

		CreateRandom();

		isEatting = 0;
	}
		

	//ThinkingBubble

	private void HideFood(){
		TBubbleList_Country_Food_1.SetActive (false);
		TBubbleList_Country_Food_2.SetActive (false);
		TBubbleList_Country_Food_3.SetActive (false);
		TBubbleList_Country_Food_4.SetActive (false);
		TBubbleList_Country_Food_5.SetActive (false);
	}


	IEnumerator CharReturnStatic(float Delay)
	{
		
		yield return new WaitForSeconds(Delay);
		isEatting = 0;
	}

	public void ShowPause(){
		if (isPause == "Puase") {
			isPause = "NotPuase";
		} else {
			isPause = "Puase";
		}
	}


	IEnumerator FuncOneLifeRemove(float Delay)
	{
		PublicOneLifeRemove = true;
		ImmuneShow.SetActive (true);

		float second = Delay - 1.5f;
		yield return new WaitForSeconds(second);
		ImmuneShow.SetActive (false);

		yield return new WaitForSeconds(Delay);
		PublicOneLifeRemove = false;


	}
		
}
