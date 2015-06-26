using UnityEngine;
using System.Collections;

/// <summary>
/// Bullet
/// 弾のあたり判定
/// </summary>
public class Bullet : MonoBehaviour {

	int collisionCount;
	int colliderCount;

	// あたった時の処理
	void OnCollisionEnter(Collision col) {
//		if (col.gameObject.tag == "BonusItem" || col.gameObject.tag == "Enemy") {
//			GameReference.soundManager.PlaySE (GameReference.soundManager.SEList [0]);
//		}
		
		// 砲弾同士はぶつからない
		if (col.gameObject.tag != "Bullet") {
			collisionCount++;
		}
		 
//		if (col.gameObject.tag == "Wall") {
//			GameReference.soundManager.PlaySE (GameReference.soundManager.SEList [3]);
////			comboCount++;
//		}
		// bonus
//		if (col.gameObject.tag == "BonusItem") {
//
//		}
		// scoreItem
//		if (col.gameObject.tag == "ScoreUpItem") {
//			scoreItemCollisionCount++;
//			GameReference.soundManager.PlaySE (GameReference.soundManager.SEList[1]);
//		}
		// 3回どっかにあたったら死ぬ
		if (collisionCount == ConstantData.DESTROY_COUNT) {
			Destroy(gameObject,0.2f);
			collisionCount = 0;
		}
	}

//	void OnTriggerEnter(Collider collider) {
//		if (colliderCount > 1 && collider.tag == "Battery") {
//			GameReference.gameController.SetActivePlayerController(false);
//			GameReference.timerController.TimeOverEffect();
//			GameReference.soundManager.PlaySE (GameReference.soundManager.SEList[2]);
//			Destroy(collider.gameObject);
//			GameReference.gameController.isAliveBattery = false;
//			colliderCount = 0;
//		}
//		colliderCount++;
//	}
}
