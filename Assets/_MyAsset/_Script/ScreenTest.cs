using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenTest : MonoBehaviour {
	public Text Info;
	public static bool isTablet;
	public static bool deviceIsIphoneX = false;

    public static bool deviceIsIphoneXUnknown = false;
    public static bool deviceIsIphoneXiPhoneXR = false;
    public static bool deviceIsIphoneXiPhoneXSMax= false; 
    public static bool deviceIsIphoneXiPhoneXS= false; 
    public static bool deviceIsIphoneXiPhoneX= false; 
    float delay = 2.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		#if UNITY_IOS
		
		#endif
        deviceIsIphoneXiPhoneXR = UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPhoneXR;
        deviceIsIphoneXUnknown = UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPhoneUnknown;
        deviceIsIphoneXiPhoneXSMax = UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPhoneXSMax;
        deviceIsIphoneXiPhoneXS = UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPhoneXS;
        deviceIsIphoneXiPhoneX = UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPhoneX;

        if(deviceIsIphoneXiPhoneXR == true || deviceIsIphoneXUnknown == true || deviceIsIphoneXiPhoneXSMax == true ||
           deviceIsIphoneXiPhoneXS == true ||deviceIsIphoneXiPhoneX == true){
            deviceIsIphoneX = true;
        }else{
            deviceIsIphoneX = false;
        }

        if (deviceIsIphoneX == true)
        {
            print("IPhoneX");
            Info.text = UnityEngine.iOS.Device.generation+"";//"IPhoneX";
            isTablet = false;
            StartCoroutine(DelayStart(delay));
        }
        else
        {
            if (IsTablet() == true)
            {
                print("IPad");
                Info.text = "Tablet/IPad";
                isTablet = true;
                StartCoroutine(DelayStart(delay));
            }
            else
            {
                print("IPhone");
                Info.text = "Mobile Phone";
                isTablet = false;
                StartCoroutine(DelayStart(delay));
            }
        }
		#if UNITY_IOS
		
		#endif

//		Info.text = UnityEngine.iOS.Device.generation+"";
//		Info.text =Info.text+"_____" + UnityEngine.iOS.DeviceGeneration.iPhoneUnknown+"";

	}

	public static bool IsTablet(){

		float ssw;
		if(Screen.width>Screen.height){ssw=Screen.width;}else{ssw=Screen.height;}

		if(ssw<800) return false;

		if(Application.platform==RuntimePlatform.Android || Application.platform==RuntimePlatform.IPhonePlayer){
			float screenWidth = Screen.width / Screen.dpi;
			float screenHeight = Screen.height / Screen.dpi;
			float size = Mathf.Sqrt(Mathf.Pow(screenWidth, 2) + Mathf.Pow(screenHeight, 2));
			if(size >= 6.5f) return true;
		}

		return false;
	}

	IEnumerator DelayStart(float Delay)
	{
		
		yield return new WaitForSeconds(Delay);
        //deviceIsIphoneX = UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPhoneXR;
		if(deviceIsIphoneX == true){
			Application.LoadLevel ("Scene01_Intro");//Scene01_IntroPX
		}else{
			if (IsTablet () == true) {
				Application.LoadLevel ("Scene01_Intro");

			} else {
				Application.LoadLevel ("Scene01_Intro_Mobile");
			}
		}
	}
}
