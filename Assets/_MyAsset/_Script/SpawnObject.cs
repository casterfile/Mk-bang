using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

using System.Security.Cryptography;
using System.Text;

public class SpawnObject : MonoBehaviour {
	//	public Transform prefab;
	public GameObject prefab1;
	int ranData;
	private bool isContinue = false;
	private bool isChangeMind = false;
	public static int LastRan = 0;
	public static int SaveRan = 0;
//	public Transform parentOfHint;
	// Use this for initialization
	void Start () {
		SaveRan = 1;
		LastRan = 2;
		isChangeMind = false;

//		InvokeRepeating("fallingObject", 2f, 2f);
		Invoke("CreateRandom", 1);

	}

//	void Update(){
//		if(isContinue == false){
//			isContinue = true;
//			CreateRandom ();
//		}
//
//		if(CharacterController.isPause == true){
//			isContinue = false;
//		}
//	}

	private void CreateRandom(){
		if (CharacterController.PublicSlowTime == false) {
			float Count = 2;
			if(CharacterController.SpeedCounter < 10){
				Count = 2;
			}else if(CharacterController.SpeedCounter < 100){
				Count = 1;
			}else if(CharacterController.SpeedCounter < 300){
				Count = 0.5f;
			}
			float speedCount = Count;
			Invoke("fallingObject", speedCount);
		} else {
			float Count = 2;
			float speedCount = Count;
			Invoke("fallingObject", speedCount);
		}




	}

//	public void StartAgain(){
//		Invoke("fallingObject", 3);
//	}

	public void fallingObject(){
		CreateRandom ();
		if(CharacterController.isPause == "NotPuase"){
			//ranData = Random.Range(1, 6);

//			if (CharacterController.ScoreCount > 5) {
//				ranData = Random.Range(1, 6);
//			} 
//			else {
//				ranData = Random.Range(1, 4);
//				if(LastRan == 0){
//					LastRan = ranData;
//				}
//
//				if (ranData == 1) {
//					SaveRan = 2;
//				} else if (ranData == 2) {
//					SaveRan = 3;
//				}
//			}





			if (CharacterController.isThinking == true) {
				ranData = Random.Range(1, 6);
				if(isChangeMind == false){
					isChangeMind = true;
					LastRan = SaveRan;
//					print ("Hello World");
					while(ranData == SaveRan && LastRan == SaveRan)
					{
						SaveRan = Random.Range(1, 6);
					}

					if(LastRan == SaveRan){
						while(LastRan == SaveRan)
						{
							SaveRan = Random.Range(1, 6);
						}
					}

				}

				ranData = Random.Range(1, 6);
				while(ranData == SaveRan && LastRan == SaveRan)
				{
					ranData = Random.Range(1, 6);
				}

				if(LastRan == ranData){
					while(LastRan == ranData)
					{
						ranData = Random.Range(1, 6);
					}
				}

			} else {
				isChangeMind = false;
				ranData = Random.Range(1, 6);
				while(ranData == SaveRan)
				{
					ranData = Random.Range(1, 6);
				}
			}

//			print ("LastRan: "+ LastRan + " ranData: "+ranData + " SaveRan: "+SaveRan);

//			if (LastRan == ranData) {
//				
//			} else {
//				LastRan = ranData;
//			}
//
//			if (CharacterController.ranData == LastRan) {
//				
//			}


			GameObject instantiatedHint = Instantiate(prefab1, transform.position, Quaternion.identity);
//			if (ScreenTest.isTablet == true) {
//				
//				if (Screen.width > 800) {
//					instantiatedHint.transform.localScale = new Vector3(1f, 1f, 0f);
//				} else {
//					instantiatedHint.transform.localScale = new Vector3(.5f, .5f, 0f);
//				}
//			} else {
//
//				if (Screen.width > 800) {
//					instantiatedHint.transform.localScale = new Vector3(2f, 2f, 0f);
//				} else {
//					instantiatedHint.transform.localScale = new Vector3(1f, 1f, 0f);
//				}
//
//			}

//			float width = prefab1.transform.localScale.x;
//			width = width * 2;
//			float height = prefab1.transform.localScale.y;
//			height = height * 2;

			float width = prefab1.transform.lossyScale.x;
			float height = prefab1.transform.lossyScale.y;

			instantiatedHint.transform.localScale = new Vector3(width, height, 0f);

			instantiatedHint.transform.parent = transform;

			instantiatedHint.GetComponent<ItemMove>().enabled = true;
			GameObject  CountryObjact = instantiatedHint.transform.GetChild (0).gameObject;
			GameObject  FoodObject1 = CountryObjact.transform.GetChild (0).gameObject;
			GameObject  FoodObject2 = CountryObjact.transform.GetChild (1).gameObject;
			GameObject  FoodObject3 = CountryObjact.transform.GetChild (2).gameObject;
			GameObject  FoodObject4 = CountryObjact.transform.GetChild (3).gameObject;
			GameObject  FoodObject5 = CountryObjact.transform.GetChild (4).gameObject;
			GameObject  FoodObject6 = CountryObjact.transform.GetChild (5).gameObject;


			FoodObject2.GetComponent<Button>().enabled = false;
			FoodObject3.GetComponent<Button>().enabled = false;
			FoodObject4.GetComponent<Button>().enabled = false;
			FoodObject5.GetComponent<Button>().enabled = false;
			FoodObject6.GetComponent<Button>().enabled = false;

			FoodObject1.SetActive (true);
			FoodObject2.SetActive (false);
			FoodObject3.SetActive (false);
			FoodObject4.SetActive (false);
			FoodObject5.SetActive (false);
			FoodObject6.SetActive (false);

			if(ranData == 1){
				FoodObject2.SetActive (true);

				Destroy (FoodObject3);
				Destroy (FoodObject4);
				Destroy (FoodObject5);
				Destroy (FoodObject6);

				FoodObject2.GetComponent<Button>().enabled = true;
			}else if(ranData == 2){
				FoodObject3.SetActive (true);


				Destroy (FoodObject2);
				Destroy (FoodObject4);
				Destroy (FoodObject5);
				Destroy (FoodObject6);

				FoodObject3.GetComponent<Button>().enabled = true;
			}else if(ranData == 3){
				FoodObject4.SetActive (true);


				Destroy (FoodObject2);
				Destroy (FoodObject3);
				Destroy (FoodObject5);
				Destroy (FoodObject6);

				FoodObject4.GetComponent<Button>().enabled = true;
			}else if(ranData == 4){
				FoodObject5.SetActive (true);


				Destroy (FoodObject2);
				Destroy (FoodObject3);
				Destroy (FoodObject4);
				Destroy (FoodObject6);

				FoodObject5.GetComponent<Button>().enabled = true;
			}else if(ranData == 5){
				FoodObject6.SetActive (true);


				Destroy (FoodObject2);
				Destroy (FoodObject3);
				Destroy (FoodObject4);
				Destroy (FoodObject5);

				FoodObject6.GetComponent<Button>().enabled = true;
			}
		}

	}


}


