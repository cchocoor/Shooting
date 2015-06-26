using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// ResultSceneControllerの説明
/// </summary>
public class ResultSceneController : MonoBehaviour {

	public Text scoreText;
	public Text hightScoreText;
	public GameObject howToPlayCanvas;

	//=================================================================================
	//初期化
	//=================================================================================
	void Awake (){
		scoreText.text = "Score : " + ScoreManager.PlayerFinalScore ().ToString ();
//		ScoreCountUpAnimation ();
		hightScoreText.text = "HightScore : " + PlayerPrefs.GetInt(ConstantData.HIGH_SCORE_KEY, -1);
	}

	void Start() {

	}
	public void CloseHowToPlayCanvas() {
		howToPlayCanvas.SetActive (false);
	}	
}