using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Timer
/// ゲームやイベントの経過時間をカウントするクラス
/// </summary>
public class TimerController : MonoBehaviour {

	public Text timerText;
	public Image timerFillMaterImage;
	private float countDownTime;
	private float firstCountDownTime;
//	private float fiverTime = 8f;
//	private float surplusFiverTime;
	[SerializeField] private Image feverFillImage;
	[SerializeField] private Slider feverFillImageSlider;
	bool willTimeOver = false;
	bool isAlreadyTimeOver = false;
	public bool isFeverTIme = false;

//	int fiverTImeCount;

	//=================================================================================
	//初期化
	//=================================================================================
	void Awake (){
		InitTimer ();
//		InitFeverTimer ();
	}

	//=================================================================================
	// ゲームスタート時のタイマーと、フィーバータイムをカウント
	//=================================================================================
	void Update () {
		if (GameReference.gameController.isFinishedCountDownAnimation)
			CountDown ();
//		if(GameReference.gameController.isFiverTime)
//			FeverTime();
	}

	/// <summary>
	/// Timer
	/// カウントダウン時間のリセット
	/// タイマーテキストに文字表示
	/// フィーバータイムの初期値保存
	/// </summary>
	public void InitTimer() {
		GameReference.gameController.isFinishedCountDownAnimation = false;
		countDownTime = ConstantData.INIT_TIMW_LIMIT;
		firstCountDownTime = countDownTime;
		timerText.text = countDownTime.ToString("N1");
		StopWillTimeOverAnimation ();
	}

	/// <summary>
	/// InitFeverTimer
	/// カウントダウン時間のリセット
	/// タイマーテキストに文字表示
	/// フィーバータイムの初期値保存
	/// </summary>
//	public void InitFeverTimer() {
//		surplusFiverTime = fiverTime;
//		feverFillImageSlider.value = 1.0f;
//		fiverTImeCount = 0;
//	}

	/// <summary>
	/// タイムをカウントダウンする
	/// <list type="CountDown">
	/// <item>Time.deltaTimeで時間をカウント</item>
	/// <item>もしポーズ画面表示時は、カウントダウンストップ</item>
	/// </summary>
	void CountDown() {
		if (!GameReference.gameController.isActivePausePanelflag && GameReference.gameController.isAliveBattery) {
			countDownTime -= Time.deltaTime;
			timerText.text = countDownTime.ToString("N1");
			timerFillMaterImage.fillAmount = countDownTime/firstCountDownTime;

			if (countDownTime <= 5.5f && 4.5f <= countDownTime) {
				if(!willTimeOver) {
					WillTimeOverAnimation();
				}
			}
			if (countDownTime <= 0) {
				if(!isAlreadyTimeOver) {
					TimeOverAnimation();
				}
				timerText.text = "0";
			}
		}
	}
	
	/// <summary>
	/// 時間が伸びるアイテムを触ったら、時間がプラスされる
	/// </summary>
	/// <param name="addTimeCount">
	public void AddTime(float addTimeCount) {
		countDownTime += addTimeCount;
		timerText.text = "TIME：" + countDownTime.ToString();
	}

	/// <summary>
	/// TimeOver Effect
	/// GameControllerのゲームオーバーアニメーションを表示
	/// **** タイムオーバーもゲームオーバーも同じエフェクト ****
	/// </summary>
	public void TimeOverEffect() {
		GameReference.gameController.StartGameOverAnimation ();
	}

	/// <summary>
	/// FeverTime
	/// 砲台が弾にあたっても死ななくなる
	/// フィーバータイムの初期値から経過時間を引く
	/// フィーバースライダーを減らす
	/// </summary>
//	public void FeverTime() {
//		if (GameReference.batteryControllerGO != null) {
//			isFeverTIme = true;
//		}
//		surplusFiverTime -= Time.deltaTime;
//		feverFillImageSlider.value = surplusFiverTime / fiverTime;
//		// TODO: Fiver time add Bound Coin's score
//		if (fiverTImeCount < 1) {
//			StartCoroutine (GameReference.generator.Generate(20, GameReference.generator.boundScoreUpItem));
//		}
//		fiverTImeCount++;
//
//		if (surplusFiverTime <= 0) {
//			isFeverTIme = false;
//			GameReference.gameController.isFiverTime = false;
//			GameReference.gameController.FinishedFeverTime();
//			GameReference.gameController.timePanel.SetBool("isFiverTime", false);
//			StartCoroutine (GameReference.generator.Generate (ConstantData.FIRST_BONUS_ITEM_CREATE_NUM, GameReference.generator.bonusItem));
//			GameReference.ScoreManager.RessetBonusScoreFolder();
//			InitFeverTimer();
//		}
//	}

	private void WillTimeOverAnimation() {
		GameReference.gameController.timePanel.SetBool("isTimeOver", true);
		willTimeOver = true;
	}
	public void StopWillTimeOverAnimation() {
		GameReference.gameController.timePanel.SetBool("isTimeOver", false);
		willTimeOver = false;
	}

	private void TimeOverAnimation() {
		GameReference.gameController.timePanel.SetBool("isTimeOver", false);
		TimeOverEffect();
		GameReference.gameController.SetActivePlayerController(false);
		isAlreadyTimeOver = true;
	}
}