using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;


/// <summary>
/// PlayerController
/// Playerのアクションを検出する
/// IPointerDownHandlerとEventSystemでタッチを検出
/// </summary>
public class PlayerController : MonoBehaviour,IPointerDownHandler {

	public bool isLookToUserSelectPos = false;
	
	/// <summary>
	/// タッチしたスクリーン座標をIPointerDownHandlerで取得
	/// </summary>
	/// <param name="eventData">タッチされた場所</param>
	public void OnPointerDown (PointerEventData eventData) {
		isLookToUserSelectPos = true;
		GameReference.gameController.showTouchPos ((Vector3)eventData.pressPosition);
		GameReference.batteryController.ChangeBatteryAngle (((Vector3)eventData.pointerPressRaycast.worldPosition));
	}
	
}
