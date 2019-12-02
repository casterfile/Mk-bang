using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRemove : MonoBehaviour {
	public GameObject Missed;
	// Use this for initialization
	void Start () {
		Missed.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col)
	{

		GameObject  CountryObjact = col.gameObject.transform.GetChild (0).gameObject;
		GameObject  FoodObject1 = CountryObjact.transform.GetChild (1).gameObject;

		if (FoodObject1.activeSelf) {
			int FoodNumber = 0;

			if(FoodObject1.name == "Food (1)"){
				FoodNumber = 1;
			}else if(FoodObject1.name == "Food (2)"){
				FoodNumber = 2;
			}else if(FoodObject1.name == "Food (3)"){
				FoodNumber = 3;
			}else if(FoodObject1.name == "Food (4)"){
				FoodNumber = 4;
			}else if(FoodObject1.name == "Food (5)"){
				FoodNumber = 5;
			}
			if(CharacterController.PublicDelayRemoveLife == false){
				if (CharacterController.ranData == FoodNumber) {

					StartCoroutine(FuncMissed(1.0f));

					bool RunOnce = false;
					if(RunOnce == false){
						RunOnce = true;
//						if(CharacterController.LiveCount == 1){
//							CharacterController.LiveCount = 0;
//						}else if(CharacterController.LiveCount == 2){
//							CharacterController.LiveCount = 1;
//						}else if(CharacterController.LiveCount == 3){
//							CharacterController.LiveCount = 2;
//						}
						CharacterController.isEatting = 2;
						CharacterController.FoodDesire = 2;
					}
				}
			}


		}
		Destroy(col.gameObject);
	}

	IEnumerator FuncMissed(float Delay)
	{
		Missed.SetActive (true);
		yield return new WaitForSeconds(Delay);
		Missed.SetActive (false);
	}

}
