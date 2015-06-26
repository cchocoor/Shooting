using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// GameControllerの説明
/// 	GameOverAnimationの表示
/// 	PauseCanvasの表示/非表示
/// 	CountDownCanvasの表示/非表示
/// 	PlayerControllerの表示/非表示(ユーザのタッチ入力)
/// 	タッチしたポジションに画像&アニメーション表示
/// </summary>
public class GameController : MonoBehaviour {

	public Animator timeOverAnimator;
	public GameObject countDown;
	public GameObject pausePanel;
	public bool isActivePausePanelflag = false;
	public bool isCountDownAnimationFlag = false;

	// GetScale
	[SerializeField] public Transform up, bottom, left, right;

	public bool isFinishedCountDownAnimation = false;
	public bool canPushPauseBtn = false;

	public bool isBatterySetActive;
	public bool isAliveBattery = false;
//	pu[blic bool isFiverTime;
	public Animator boundItemGageAnimator;
	[SerializeField] private GameObject scoreAnimationTextGameObject;
	[SerializeField] private Transform scoreMoveCanvasTransform;
	[SerializeField] private GameObject touchPositionImage;
	[SerializeField] GameObject clearedConditionPanelprefab;
	public GameObject clearedConditionPanel;
 	public Animator timePanel;
	public Image timePanelImage;

	private Animator touchPositionImageAnimator;
	public GameObject scoreUpItemFolder;
	public GameObject clearedObjectList;
	public clearedObjectList _clearedObjectList;
	private GameObject UICanvas;

	//=================================================================================
	//初期化
	//=================================================================================
	void Awake (){
		UICanvas = GameObject.Find ("UIcanvas");
		pausePanel.SetActive (false);
		GameReference.soundManager.PlayBGM (GameReference.soundManager.BGMList[0]);
		_clearedObjectList = clearedObjectList.GetComponent<clearedObjectList> ();
	}

	void Start () {
		Init ();
	}
	
	//=================================================================================
	//更新
	//=================================================================================
	void Update () {
	
	}
	/// <summary>
	/// 初期化
	/// </summary>
	public void Init() {
		SetActivePlayerController (false);
		touchPositionImageAnimator = touchPositionImage.GetComponent<Animator> ();
		timePanel.SetBool("isFiverTime", false);
		clearedConditionPanel = (GameObject)Instantiate (clearedConditionPanelprefab, UICanvas.transform.position, Quaternion.identity);
		clearedConditionPanel.transform.SetParent (UICanvas.transform);
		clearedConditionPanel.transform.localScale = Vector3.one;
		clearedConditionPanel.transform.localPosition = Vector3.one;
		clearedConditionPanel.GetComponent<Image> ().rectTransform.anchoredPosition = Vector2.zero;
		clearedConditionPanel.GetComponent<Image> ().rectTransform.sizeDelta = Vector2.zero;
		clearedConditionPanel.GetComponent<Button> ().onClick.AddListener(() => GameReference.generator.CloseCleredConditionPanel ());

	}

	/// <summary>
	/// GameOverAnimation 
	/// ポーズボタンが押せない様にしている
	/// </summary>
	public void StartGameOverAnimation() {
		timeOverAnimator.SetTrigger ("isTimeOver");
		canPushPauseBtn = false;
	}

	/// <summary>
	/// ポーズパネルの表示
	/// </summary>
	public void ShowPausePanel() {
		if (!isActivePausePanelflag && canPushPauseBtn ) {
			pausePanel.SetActive (true);
			isActivePausePanelflag = true;
		}
	}

	/// <summary>
	/// ポーズパネルの非表示
	/// </summary>
	public void ClosePausePanel() {
		if (isActivePausePanelflag) {
			pausePanel.SetActive (false);
			isActivePausePanelflag = false;
		}
	}	

	/// <summary>
	/// カウントダウンキャンバスの表示
	/// </summary>
	public void ShowCountDwonCnavas() {
		GameReference.timerController.InitTimer ();
		GameReference.ScoreManager.InitScore ();
		GameReference.batteryController.InitBatteryPos ();
		GameReference.batteryController.InitBatteryRotation ();
		countDown.SetActive (true);
		Init ();
	}

	/// <summary>
	/// カウントダウンキャンバスの表非表示
	/// </summary>
	public void CloseCountDwonCnavas() {
		countDown.SetActive (false);
		SetActivePlayerController (true);
	}

	/// <summary>
	/// PlayerController(画面タッチ取得)をONにするかOFFにするか
	/// </summary>
	/// <param name="isActive"> true or false </param>
	public void SetActivePlayerController(bool isActive) {
		GameReference.playerControllerGO.SetActive (isActive);
	}

	/// <summary>
	/// 敵にあったった時のスコアアニメーションを再生
	/// </summary>
	/// <param name="isScoreItem">ヒットしたものが点になるものかどうかのbool</param>
	/// <param name="hitPos">scoreAnimationを再生させるワールド座標をもらうVector3</param>
	public void startScoreAnimation (bool isScoreItem, Vector3 hitPos, int addScore) {
		GameObject scoreAnimationTextObj = (GameObject)Instantiate (scoreAnimationTextGameObject,  Camera.main.WorldToScreenPoint (hitPos), Quaternion.identity);
		scoreAnimationTextObj.GetComponentInChildren<Text> ().text = "+" + addScore.ToString ();
		scoreAnimationTextObj.transform.SetParent (scoreMoveCanvasTransform);
		scoreAnimationTextObj.GetComponentInChildren<Animator>().SetTrigger("isHit");
	}
	
	/// <summary>
	/// タッチしたポジションにアニメーションを表示
	/// </summary>
	/// <param name="touchPosition">ユーザーがタッチしたポジション</param>
	public void showTouchPos(Vector3 touchPosition) {
		touchPositionImageAnimator.SetTrigger ("isTouched");
		touchPositionImage.transform.position = touchPosition;
	}

	/// <summary>
	/// フィーバータイムが終わったらコインを全て削除
	/// </summary>
//	public void FinishedFeverTime() {
//		foreach (Transform childElement in scoreUpItemFolder.transform) {
//			Destroy(childElement.gameObject);
//		}
//		GameReference.mainCamera.backgroundColor = new Color (123f/255, 179f/255f, 243f/255f);
//	}

}