using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Generatorの説明
/// キャラ（敵・アイテム）を生成するクラス
/// </summary>
public class Generator : MonoBehaviour {

	[SerializeField] private GameObject enemy;
	public GameObject bonusItem;
	public GameObject boundScoreUpItem;
	[SerializeField] private GameObject timeCountUpItem;
	[SerializeField] private Transform objectParents;
	[SerializeField] private GameObject clearedConditionObjectPrefab;
	float padding7 = 7f;
	public Sprite[] sprites;
	[SerializeField] GameObject clearedConditionElement;
	[SerializeField] GameObject clearedCondition;
	[SerializeField] GameObject clearedConditionPanel;
	[SerializeField] GameObject cleredElement;
	[SerializeField] Transform clearedElementParent;
	private int instantiateCount = 1;
	int maxSize;


	/// <summary>
	/// キャラ作るやつをStartCorutineで呼ぶ
	/// 5秒置きに、敵を作る
	/// </summary>
	void Awake (){
		StartCoroutine (Generate (ConstantData.FIRST_ENEMY_CREATE_NUM, enemy));
		StartCoroutine (Generate (ConstantData.FIRST_BONUS_ITEM_CREATE_NUM, bonusItem));
		InvokeRepeating ("CreateEnemy", ConstantData.WAIT_CREATE_TIME, ConstantData.WAIT_CREATE_TIME);
		sprites = Resources.LoadAll<Sprite> (ConstantData.BASE_SPRITE);
	}

	void Start() {
		maxSize = sprites.Length - 1;
		InstantiateClearedCOnditionElement (instantiateCount);
	}

	public void NextLevel(int instantiateCount) {
		InstantiateClearedCOnditionElement (instantiateCount);
	}

	/// <summary>
	/// 指定の数だけ指定した物を作成
	/// </summary>
	/// <param name="num">個数</param>
	/// <param name="prefab">指定したプレハブ</param>
	public IEnumerator Generate (int num, GameObject prefab) {
		Vector3 origin = transform.position;
		for (int i = 0; i < num; i++) {
			Vector3 randomOffset = new Vector3 (
				Random.Range(-GameReference.gameController.up.localScale.x/2 + padding7, GameReference.gameController.up.localScale.x/2 - padding7),
				0f,
				Random.Range(-GameReference.gameController.left.localScale.z/2 + padding7 ,GameReference.gameController.left.localScale.z/2 - padding7)
				);
			GameObject instancePrefabs = (GameObject)Instantiate(prefab, origin + randomOffset, prefab.transform.rotation);
			if(instancePrefabs.tag != "ScoreUpItem") {
			instancePrefabs.transform.SetParent(objectParents);
			} else {
				instancePrefabs.transform.SetParent(GameReference.gameController.scoreUpItemFolder.transform);
			}
			yield return new WaitForSeconds(0.1f);
		}
		yield break;
	}

	/// <summary>
	/// 敵を作る
	/// </summary>
	void CreateEnemy() {
		Vector3 origin = transform.position;
		for (int i = 0; i < ConstantData.INVOKE_ENEMY_CREATE_NUM; i++) {
			Vector3 randomOffset = new Vector3 (
				Random.Range(-GameReference.gameController.up.localScale.x/2 + padding7, GameReference.gameController.up.localScale.x/2 - padding7),
				0f,
				Random.Range(-GameReference.gameController.left.localScale.z/2 + padding7, GameReference.gameController.left.localScale.z/2 - padding7)
				);
			GameObject instancePrefabs = (GameObject)Instantiate(this.enemy, origin + randomOffset, enemy.transform.rotation);
			instancePrefabs.transform.SetParent(objectParents);
		}
	}

//	private void InstantiateClearedConditionElement(int nom) {
//		Vector3 randomOffset = new Vector3 (
//			Random.Range(-GameReference.gameController.up.localScale.x/2 + padding7, GameReference.gameController.up.localScale.x/2 - padding7),
//			0f,
//			Random.Range(-GameReference.gameController.left.localScale.z/2 + padding7, GameReference.gameController.left.localScale.z/2 - padding7)
//			);
//		GameObject go = (GameObject)Instantiate (clearedConditionObjectPrefab, randomOffset, clearedConditionObjectPrefab.transform.rotation);
//		go.GetComponent<SpriteRenderer>().sprite = sprites [nom];
//		go.transform.SetParent(objectParents);
//	}

	private void InstantiateClearedCOnditionElement(int c) {

		for(int i = 0; i < c; i++) {
			int rnd = Random.Range(0, maxSize);
			GameObject clearedConditionElementObject = (GameObject)Instantiate (clearedConditionElement, clearedCondition.transform.position,Quaternion.identity);
			clearedConditionElementObject.GetComponent<Image>().sprite = sprites[rnd];
//			InstantiateClearedConditionElement(rnd);
			Vector3 randomOffset = new Vector3 (
							Random.Range(-GameReference.gameController.up.localScale.x/2 + padding7, GameReference.gameController.up.localScale.x/2 - padding7),
							0f,
							Random.Range(-GameReference.gameController.left.localScale.z/2 + padding7, GameReference.gameController.left.localScale.z/2 - padding7)
							);
			GameObject go = (GameObject)Instantiate (clearedConditionObjectPrefab, randomOffset, clearedConditionObjectPrefab.transform.rotation);
			go.GetComponent<SpriteRenderer>().sprite = sprites [rnd];
			go.transform.SetParent(GameReference.gameController.clearedObjectList.transform);

			clearedConditionElementObject.transform.SetParent(clearedCondition.transform);
			clearedConditionElementObject.transform.localScale = Vector3.one;
			ShowCleredConditionPanel(rnd);
			
		}
	}
	public void ShowCleredConditionPanel(int rnd) {
		GameReference.gameController.clearedConditionPanel.SetActive (true);
		clearedElementParent = GameObject.Find ("ClearedConditionPanel(Clone)").transform.FindChild ("clearedElementParent").transform;
		GameObject clearedElementObject = (GameObject)Instantiate (cleredElement);
		clearedElementObject.transform.SetParent(clearedElementParent);
		clearedElementObject.transform.localScale = Vector3.one;
		clearedElementObject.transform.localPosition = Vector3.one;
		clearedElementObject.GetComponent<Image> ().sprite = sprites [rnd];

		GameReference.batteryController.InitBatteryPos ();
		GameReference.batteryController.InitBatteryRotation ();
	}
	public void CloseCleredConditionPanel() {
		for(int i = 0; i < clearedElementParent.childCount; i++) {
			Destroy(clearedElementParent.transform.parent.gameObject);
		}
		GameReference.gameController.ShowCountDwonCnavas ();
		GameReference.gameController.clearedConditionPanel.SetActive (false);
	}
}