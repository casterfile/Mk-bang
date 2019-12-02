using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodButtonControl : MonoBehaviour {
	public Button FoodButton;
	public int FoodNumber;
	public GameObject  CharacterHands;
	private Image img;
	private bool isClick = false;

	private AudioSource audioSource;
	public AudioClip Points,Wrong;

	// Use this for initialization
	void Start () {
//		FoodButton = GetComponent<Button>();
//
//		FoodButton.onClick.AddListener(() => FuncFoodButton());
		audioSource = GameObject.Find ("Audio").GetComponent<AudioSource>();

		CharacterHands.SetActive (false);

		img = gameObject.GetComponent<Image>();
		img.color = new Color(1, 1, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void FuncFoodButton(){
//		if (CharacterController.PublicOneLifeRemove == false) {
			if (isClick == false) {
				isClick = true;
				if (CharacterController.ranData == FoodNumber) {
					CharacterHands.SetActive (true);
					CharacterController.ScoreCount++;
					CharacterController.isEatting = 1;
					CharacterController.FoodDesire = 1;
					gameObject.name = "Empty";
					audioSource.PlayOneShot (Points, 0.7F);
					//print ("isEatting: "+CharacterController.isEatting+" CharacterController.ranData "+ CharacterController.ranData + " FoodNumber "+FoodNumber);
					StartCoroutine (FadeImage (true));
				} else {
					CharacterHands.SetActive (true);


					CharacterController.isEatting = 2;
					CharacterController.FoodDesire = 2;

					audioSource.PlayOneShot (Wrong, 0.7F);
					//print ("isEatting: "+CharacterController.isEatting+" CharacterController.ranData "+ CharacterController.ranData + " FoodNumber "+FoodNumber);
					StartCoroutine (FadeImage (true));
				}
			}
//		}
	}

	IEnumerator FadeImage(bool fadeAway)
	{
		// fade from opaque to transparent
		if (fadeAway)
		{
			// loop over 1 second backwards
			for (float i = 1; i >= 0; i -= Time.deltaTime)
			{
				// set color with i as alpha
				img.color = new Color(1, 1, 1, i);
				if(i < 0.1){
					FoodButton.gameObject.SetActive(false);
					CharacterHands.SetActive (false);
				}
				yield return null;
			}
		}
		// fade from transparent to opaque
//		else
//		{
//			// loop over 1 second
//			for (float i = 0; i <= 1; i += Time.deltaTime)
//			{
//				// set color with i as alpha
//				img.color = new Color(1, 1, 1, i);
//				yield return null;
//			}
//		}
	}

//	void OnCollisionEnter2D(Collision2D col)
//	{
//		Destroy(gameObject);
//	}
}
