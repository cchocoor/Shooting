using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// TransitionManagerの説明
/// 画面遷移
/// </summary>
public class TransitionManager : MonoBehaviour,IPointerDownHandler {
	
	[SerializeField] private Animator animator;

	/// <summary>
	/// 画面をタッチされたら、遷移する
	/// </summary>
	/// <param name="eventData">タッチされた場所</param>
	public void OnPointerDown(PointerEventData eventData) {
		// もしタイトルシーンだったら、タップされたら、画面を遷移する
		if (Application.loadedLevel == ConstantData.TITLE_SCENE) {
			StartCoroutine("UserSelectNextScene", ConstantData.GAME_SCENE);
		}
	}
	
	/// <summary>
	/// 遷移する
	/// </summary>
	/// <param name="nextScene">Scene number</param>
	public void SelectNextScene(int nextScene) {
		StartCoroutine("UserSelectNextScene", nextScene);
	}

	private IEnumerator UserSelectNextScene(int nextScene) {
		AnimateTransitionPanelColor ();
		yield return new WaitForSeconds (ConstantData.WAIT_TIME);
		Debug.Log (nextScene);
		Application.LoadLevel (nextScene);
	}

	/// <summary>
	/// Transition Animation Trigger
	/// </summary>
	private void AnimateTransitionPanelColor() {
		animator.SetTrigger ("isTransition");
	}
}