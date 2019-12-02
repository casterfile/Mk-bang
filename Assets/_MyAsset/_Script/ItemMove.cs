using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMove : MonoBehaviour {
//	public Button FoodButton_1,FoodButton_2,FoodButton_3,FoodButton_4,FoodButton_5;

	public Transform ItemTargetStart, ItemTargetEnd;

	public float speed = 60;
	public GameObject Immune;
	private float resize = 100;
	private float TotalSpeed, TotalSpeedTemp;
	float stepGoingBack,step;
	// Use this for initialization
	void Start () {

		transform.position = new Vector2(ItemTargetStart.position.x, ItemTargetStart.position.y);
		Immune.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		if (CharacterController.isPause == "NotPuase") {
			if (CharacterController.PublicSlowTime == false) {
				TotalSpeed = (Screen.width / 300.0f) * (speed + (CharacterController.SpeedCounter * 2)); 
				TotalSpeedTemp = TotalSpeed;
				TotalSpeed = TotalSpeedTemp; //(GameController.ScoreCount * 10) +
				step = TotalSpeed * Time.deltaTime;
				stepGoingBack = TotalSpeedTemp * Time.deltaTime;

				transform.position = Vector3.MoveTowards (transform.position, ItemTargetEnd.position, step);
				//		Image.rectTransform.sizeDelta = new Vector2(100, 100);

				if (transform.position == ItemTargetEnd.position) {
					//			Destroy(gameObject);
				}
			} else {
				TotalSpeed = (Screen.width / 300.0f * speed);
				TotalSpeedTemp = TotalSpeed;
				TotalSpeed = TotalSpeedTemp; //(GameController.ScoreCount * 10) +
				step = TotalSpeed * Time.deltaTime;
				stepGoingBack = TotalSpeedTemp * Time.deltaTime;

				transform.position = Vector3.MoveTowards (transform.position, ItemTargetEnd.position, step);
			}

		}

		if (CharacterController.PublicOneLifeRemove == true) {
			//Immune.SetActive (true);
		} else {
			//Immune.SetActive (false);
		}

	}
}
