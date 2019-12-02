//////////////////////////////////////////////////////////////////////////////
// bl_Ranking.cs
//
//
//                       Lovatto Studio 2015
//////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MK_GetTop : MonoBehaviour {

	private string GetTopPHP_Url = "https://immersivemedia.ph/MukbangFilipino/MK_GetTop.php"; //be sure to add a ? to your url
    private bool isget = false;
    private int LastFount = 0;
	public static int HighestScore = 0;
	public static int LastScore = 0;
    void Start()
    {
        StartCoroutine(GetTop());
    }

    // Get the scores from the MySQL DB.
    // remember to use StartCoroutine when calling this function!
    IEnumerator GetTop()
    {
		int count = 1;
        if (isget)//if alredy load info
            yield return null;

        isget = true;//notify is load now
       
        WWW www = new WWW(GetTopPHP_Url);
        yield return www;//wait for response

        if (www.error != null)
        {
            print("There was an error getting the high score: " + www.error);
        }
        else
        {
            
            //get info from data base
            string result = www.text;
            //get and separate users
            string[] splituser = result.Split("\n"[0]);

            int numbers = 0;
            bool mtype = false;

            foreach (string u in splituser)
            {
                numbers++;
                mtype = !mtype;
                //get separate info user
                string[] splitinfo = u.Split("-"[0]);

                if (u != string.Empty && u != null)
                {
					string Data1 = numbers + "";
					string Data2 = splitinfo[0];
					string Data3 = splitinfo [1];
					PlayerPrefs.SetString ("ScoreListName"+count, Data2);
					PlayerPrefs.SetString ("ScoreListScore"+count, Data3);

//					HighestScore = int.Parse (Data3);
//					print ("Data:"+ x + " "+Data1+Data2+Data3);
					count++;
                }
            }

        }
        
        isget = false;
    }
		
}