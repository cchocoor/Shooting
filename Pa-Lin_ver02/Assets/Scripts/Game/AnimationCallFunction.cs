using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// AnimationCallFunctionの説明
/// Animationの終了を知らせるクラス
/// </summary>
public class AnimationCallFunction : MonoBehaviour {

	/// <summary>
	/// カウントダウンのアニメーションが終わった
	/// <item>カウントダウンが終わったフラグをtrueにする</item>
	/// <item>ポーズボタンが押せる様にする</item>
	/// <item>カウントダウンキャンバスを閉じる</item>
	/// </summary>
	public void CountDownAnimationComplete() {
		GameReference.gameController.isFinishedCountDownAnimation = true;
		GameReference.gameController.canPushPauseBtn = true;
		GameReference.gameController.CloseCountDwonCnavas ();
	}
}