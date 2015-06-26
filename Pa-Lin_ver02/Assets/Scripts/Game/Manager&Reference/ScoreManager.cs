using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// ScoreManagerの説明
/// </summary>
public class ScoreManager : MonoBehaviour {

	public static int score;
	public static int hightScore;
	[SerializeField] Image bonusFillImage;
	[SerializeField] Button bounusItemBtn;
//	private float bounusMaxScore = 300;
//	private float playerBonusScore = 0;
	[SerializeField] Text scoreText;
//	[SerializeField] Text scoreAnimationText;

	/// <summary>
	/// 初期化の呼び出し
	/// ハイスコアを取得
	/// </summary>
	void Awake (){
		InitScore ();
		hightScore = PlayerPrefs.GetInt (ConstantData.HIGH_SCORE_KEY, -1);
	}

	/// <summary>
	/// スコアを0からスタート
	/// </summary>
	public void InitScore() {
		score = 0;
		scoreText.text = "000";
	}


	/// <summary>
	/// 加点
	/// </summary>
	/// <param name="addScore">何点分プラスするか</param>
	public void AddScore(int addScore) {
		score += addScore;
		scoreText.text = score.ToString ();
	}


	/// <summary>
	/// ボーナスアイテム　加点用
	/// bounusMaxScore分点数が集まったら、フィーバータイムに遷移
	/// </summary>
	/// <param name="addScore">何点分プラスするか</param>
//	public void AddBonusScore(float addScore) {
//		// ボーナス追加
//		playerBonusScore += addScore;
//		bonusFillImage.fillAmount = ((bounusMaxScore - playerBonusScore) / bounusMaxScore); 
//
//		// ボーナスがマックスになった時の処理
//		if (bonusFillImage.fillAmount == 0) {
//			GameReference.gameController.isFiverTime = true;
//			GameReference.gameController.timePanel.SetBool("isFiverTime", true);
////			GameReference.gameController.timePanelImage.color = new Color (11f/255f, 19f/255f, 255f/255f, 0.8f);
//			GameReference.mainCamera.backgroundColor = new Color (50f/255f, 50f/255f, 50f/255f,1f);
//		}
//	}

	/// <summary>
	/// フィーバータイムから,フィーバータイムに発火するためのボーナススコアをリセットする
	/// </summary>
//	public void RessetBonusScoreFolder () {
//		if(!GameReference.gameController.isFiverTime)
//		bonusFillImage.fillAmount = 1;
//		playerBonusScore = 0;
//	}
	
	/// <summary>
	/// 最終的なプレイヤーのスコア
	/// bounusMaxScore分点数が集まったら、フィーバータイムに遷移
	/// </summary>
	/// <returns name = "score"> 最終的なプレイヤーのスコア </returns>
	public static int PlayerFinalScore() {
		CompareHightScoreAndPlayerNewScore (score);
		return score;
	}
	
	/// <summary>
	/// ハイスコア更新されたかどうか
	/// </summary>
	/// <param name="score">プレイヤーの1ゲームの最終点数</param>
	public static void CompareHightScoreAndPlayerNewScore(int score) {
		if (score > hightScore) {
			hightScore = score;
		}
		SaveHightScore (hightScore);
	}
	
	/// <summary>
	/// ハイスコア更新
	/// </summary>
	/// <param name="hightScore">ハイスコア記録</param>
	public static void SaveHightScore(int hightScore) {
		PlayerPrefs.SetInt (ConstantData.HIGH_SCORE_KEY, hightScore);
		PlayerPrefs.Save();
	}
}