using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Security;
using System.Collections;

public class MK_RegisterUpdate : MonoBehaviour {

	private string SecretKey = "123456";
	private string RegisterPHP_Url = "https://immersivemedia.ph/MukbangFilipino/MK_RegisterUpdate.php";

	protected string MK_RegisterUpdate_UUID = "";
	protected string MK_RegisterUpdate_Name = "";
	protected string MK_RegisterUpdate_Score = "";
    private bool isRegister = false;
	public static bool UpdateData = false;

	// Use this for initialization
	void Start () {
		MK_RegisterUpdate_UUID = SystemInfo.deviceUniqueIdentifier;
		MK_RegisterUpdate_Name = PlayerPrefs.GetString("SavePlayerName");
		MK_RegisterUpdate_Score = PlayerPrefs.GetString("SavePlayerScore");

//		int TestData = int.Parse (MK_RegisterUpdate_Score);
//		if (MK_GetTop.HighestScore < MK_GetTop.LastScore) {
//			Register ();
//			print ("MK_GetTop.HighestScore222 "+MK_GetTop.HighestScore );
//			print ("MK_GetTop.HighestScore222 "+MK_GetTop.LastScore );
//		} else {
//			print ("MK_GetTop.HighestScore "+MK_GetTop.HighestScore );
//			print ("MK_GetTop.LastScore "+MK_GetTop.LastScore );
//		}

		if(UpdateData == true){
			UpdateData = false;
			Register ();
		}
	}
	
	// Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public void Register()
    {
        if (isRegister)
            return;

		if (MK_RegisterUpdate_UUID != string.Empty && MK_RegisterUpdate_Name != string.Empty && MK_RegisterUpdate_Score != string.Empty)
        {
			StartCoroutine(RegisterProcess());
        }
    }

    IEnumerator RegisterProcess()
    {
        if (isRegister)
            yield return null;

        isRegister = true;
        //Used for security check for authorization to modify database

        //Assigns the data we want to save
        //Where -> Form.AddField("name" = matching name of value in SQL database
        WWWForm mForm = new WWWForm();
		mForm.AddField("MK_RegisterUpdate_UUID", MK_RegisterUpdate_UUID); // adds the player name to the form
		mForm.AddField("MK_RegisterUpdate_Name", MK_RegisterUpdate_Name); // adds the player password to the form
		mForm.AddField("MK_RegisterUpdate_Score", MK_RegisterUpdate_Score); // adds the kill total to the form

        //Creates instance of WWW to runs the PHP script to save data to mySQL database
        WWW www = new WWW(RegisterPHP_Url, mForm);
        Debug.Log("Processing...");
        yield return www;

        Debug.Log("" + www.text);
        if (www.text == "Done")
        {
            Debug.Log("Registered Successfully.");

        }
        else
        {
            Debug.Log(www.text);

        }
        isRegister = false;
    }
}
