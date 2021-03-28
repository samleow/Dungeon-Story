using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
//using Facebook.Unity; //for Facebook SDK

public class SocialMedia : MonoBehaviour
{
    

    // public Text shareUnlockWorld = null;

    // public Text shareUnlockSection2 = null;
    // public Text shareUnlockSection3 = null;

    // For Twitter

    //Twitter Share Link
    string twitter_add = "http://twitter.com/intent/tweet";

    //Language
    string twitter_lang = "en";

	//This is the text which you want to show
	string textToDisplay=" is unlock. Please access Dungeon Story to complete your gameplay.";

    // For Facebook

    //App ID from FB devloper FB account: ntu.cz3003@gmail.com  cz3003ssad
	string appID = "1616124625249442";

	//This link is attached to this post
	string link = "https://www.ntu.edu.sg";

	//The URL of a picture attached to this post. The Size must be atleat 200px by 200px.
	string picture = "";

	//The Caption of the link appears beneath the link name
	string caption = "Announcements Level Unlock!";

	//The Description of the link
	string description = "";

    string pageName ="";

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("WorldPage"))
        {
            pageName = "New World";
        }

        if (SceneManager.GetActiveScene().name.Equals("SectionPage"))
        {
            pageName = "New Section";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Twitter Share Button	
	public void shareOnTwitter () 
	{
		//Application.OpenURL (TWITTER_ADDRESS + "?text=" + WWW.EscapeURL(textToDisplay) + score.points + "&amp;lang=" + WWW.EscapeURL(TWEET_LANGUAGE));

		//Application.OpenURL (twitter_add + "?text=" + UnityWebRequest.EscapeURL(textToDisplay) + "100" + "&amp;lang=" + UnityWebRequest.EscapeURL(twitter_lang));
        string display = pageName + textToDisplay;
        Application.OpenURL (twitter_add + "?text=" + UnityWebRequest.EscapeURL(display) + "&amp;lang=" + UnityWebRequest.EscapeURL(twitter_lang));

	}

    // Facebook Share Button
	public void shareOnFacebook ()
	{
        string display = pageName + textToDisplay;
		Application.OpenURL ("https://www.facebook.com/dialog/feed?" + "app_id=" + appID + "&link=" + link + "&picture=" + picture
		                     + "&caption=" + display + "&description=" + display);

        // this code below is for Facebook SDK and only export to WEBGL work
		//FB.ShareLink(new Uri("https://www.ntu.edu.sg"),"Title","Score 100",null,ShareCallback);

		//FB.FeedShare(AppID,new Uri("https://www.ntu.edu.sg"),"Title","Score 100",null,null,null,ShareCallback);
	}

    /*
    // this code below is for Facebook SDK and only export to WEBGL work

    private void ShareCallback (IShareResult result) {
        if (result.Cancelled || !string.IsNullOrEmpty(result.Error)) {
            Debug.Log("ShareLink Error: "+result.Error);
        } else if (!string.IsNullOrEmpty(result.PostId)) {
            // Print post identifier of the shared content
            Debug.Log(result.PostId);
        } else {
            // Share succeeded without postID
            Debug.Log("ShareLink success!");
        }
    }

	private void Awake()
    {
        if (!FB.IsInitialized) {
            // Initialize the Facebook SDK
            FB.Init(InitCallback, OnHideUnity);
        } else {
            // Already initialized, signal an app activation App Event
            FB.ActivateApp();
        }
    }

    private void InitCallback ()
    {
        if (FB.IsInitialized) {
            // Signal an app activation App Event
            FB.ActivateApp();
            // Continue with Facebook SDK
            // ...
        } else {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
    }

    private void OnHideUnity (bool isGameShown)
    {
        if (!isGameShown) {
            // Pause the game - we will need to hide
            Time.timeScale = 0;
        } else {
            // Resume the game - we're getting focus again
            Time.timeScale = 1;
        }
    }

    */


}
