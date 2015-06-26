using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
#pragma warning disable 0414
/// <summary>
/// CreateOwnCopyAsUIImageの説明
/// BoundItemに弾があたった時、そのキャライメージがUIの箱に吸い込まれていく
/// </summary>
public class CreateOwnCopyAsUIImage : MonoBehaviour {
	public bool isDestroy;
	private GameObject ownCopyUIImage;
	private Image image;
	private bool isMoving;
	private Transform originPositin;
	private Vector3 screenPoint;
	
	/// <summary>
	/// 自身の配置されたワールド座標をスクリーン座標に変換
	/// </summary>
	void Start () {
		ownCopyUIImage = GameObject.Find ("BoundsItemUIImage");
		originPositin = GameObject.Find ("origin").GetComponent<Transform> ();
		image = ownCopyUIImage.GetComponent<Image> ();
		screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);
	}

	/// <summary>
	/// 自身の配置されたワールド座標をスクリーン座標に変換
	/// originPositionに向かって飛んで行く
	/// </summary>
	/// <param name="isDestroy">
	public void StartScoreUIAnimation(bool isDestroy) {
		if (isDestroy) {
			ownCopyUIImage.transform.position = new Vector3(screenPoint.x, screenPoint.y, 0);
			image.color = new Color (image.color.r, image.color.g, image.color.b, 1);
			iTween.MoveTo(ownCopyUIImage,
			              iTween.Hash("position", originPositin.position,
			            "oncomplete", "ChangeFlag",
			            "oncompletetarget", gameObject,
			            "easetype", iTween.EaseType.easeInQuart,
			            "time", 1.0f));
			this.isMoving = true;
//			GameReference.kirakiraFx.SetActive (false);
			GameReference.gameController.boundItemGageAnimator.SetTrigger("GetItem");
		}

	}

	/// <summary>
	/// start particleFX
	/// color.a = 0
	/// </summary>
	private void ChangeFlag() {
		image.color = new Color (image.color.r, image.color.g, image.color.b, 0);
//		GameReference.kirakiraFx.SetActive (true);
		this.isMoving = false;
	}

}