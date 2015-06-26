using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// BarretyController
/// 砲台をタップされた方向へ向かせる
/// 砲弾を生成して、飛ばす 
/// </summary>
public class BatteryController : MonoBehaviour {
	
	public float power = 10;
	public bool isMoveing = false;
	[SerializeField] GameObject bulletPrefab;
	private GameObject bulletObject;
	private Rigidbody bulletRigid3D;
	private Transform balletryTransform;
	public Transform bullets;
	private Dictionary<int, bool> dicts = new Dictionary<int, bool>();
	[SerializeField] private Text bulletNumText;
	int bulletNum = 5;

	// Use this for initialization
	void Start () {
		InitBatteryPos ();
	}

	/// <summary>
	/// 砲台の場所の初期化
	/// 砲台が存在しているかどうか
	/// </summary>
	public void InitBatteryPos() {
		balletryTransform = gameObject.GetComponent<Transform> ();
		balletryTransform.transform.position = Vector3.zero;
		GameReference.gameController.isAliveBattery = true;
	}

	/// <summary>
	/// 砲台の向き初期化
	/// </summary>
	public void InitBatteryRotation() {
		balletryTransform.rotation = Quaternion.identity;
	}

	/// <summary>
	/// 砲丸のアングルを変える
	/// </summary>
	/// <param name="andle">PlayerControllerからわたってきた、タッチされた場所を3D空間上に変換した座標</para>
	public void ChangeBatteryAngle(Vector3 angle) {
		Vector3 lookTouchPos = new Vector3(angle.x, 0,angle.z);
		iTween.LookTo (balletryTransform.gameObject,
		               iTween.Hash("looktarget",lookTouchPos,
		            "islocal",true,
		            "axis", "y",
		            "time", 0.2f,
		            "easetype", iTween.EaseType.easeInOutQuad,
		            "oncomplete", "AddPowerToBullet",
		            "oncompleteparams", lookTouchPos,
		            "oncompletetarget", this.gameObject
		            )
		              );
	}

	public void InitbulletNUm() {
		bulletNum = 5;
		bulletNumText.text = bulletNum.ToString () + "/5";
	}

	/// <summary>
	/// 弾生成
	/// Rigidbody取得
	/// 動いてるフラグfalseに
	/// </summary>
	private void InstantiateBullet() {
		if (bulletNum > 0) {
			bulletObject = (GameObject)Instantiate (bulletPrefab, Vector3.zero, Quaternion.identity);
			bulletRigid3D = bulletObject.GetComponent<Rigidbody> ();
			bulletObject.transform.parent = bullets;
			isMoveing = false;
			bulletNum--;
			bulletNumText.text = bulletNum.ToString () + "/5";
		} else {
			isMoveing = false;
		}
	}

	/// <summary>
	/// 砲弾に力を加える
	/// </summary>
	/// <param name="direction">ChangeBatteryAngle()ないで定義されたlookTouchPos</para>
	void AddPowerToBullet(Vector3 direction) {
		InstantiateBullet ();
		isMoveing = true;
		if (bulletNum > 0) {
			bulletRigid3D.isKinematic = false;
			if (GameReference.playerController.isLookToUserSelectPos && isMoveing) {
				bulletRigid3D.AddForce (balletryTransform.forward * power, ForceMode.Impulse);
			}
			GameReference.playerController.isLookToUserSelectPos = false;
		}
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == "Bullet" && !GameReference.timerController.isFeverTIme) {
			// collider.GetInstanceID()がすでにキーとして登録されていなかったら
			if(!dicts.ContainsKey(collider.GetInstanceID())) {
				// collider.GetInstanceID()をkeyとし、trueをvalueとして登録
				dicts.Add(collider.GetInstanceID(),true);
			}
			// dictsのkeyをlistに保存！
			List<int> keyList = new List<int>(dicts.Keys);
			// keyを見て行くka
			foreach(int key in keyList) {
				//　もしkeyがあたってきたヤツ(collider.GetInstanceID())と一緒だったら
				if(key == collider.GetInstanceID()) {
					// dicts[key]がtrueなら1回目の衝突（instantiate時）で、falseだったら2回目の衝突と見なす
					if(!dicts[key]) {
						GameReference.soundManager.PlaySE (GameReference.soundManager.SEList[2]);
//						Destroy(gameObject);
						GameReference.ScoreManager.AddScore(-500);
//						GameReference.gameController.isAliveBattery = false;
//						GameReference.gameController.SetActivePlayerController(false);
//						GameReference.timerController.TimeOverEffect();
					}
					dicts[key] = false;
				}
			}
		}
	}
	// TODO:if collider.GetInstanceID().gameobject null Destroy!

}