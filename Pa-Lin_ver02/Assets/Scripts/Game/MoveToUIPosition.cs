using UnityEngine;
using System.Collections;

/// <summary>
/// MoveToUIPositionの説明
/// UIの指定されたポジションをワールド座標に変換する
/// </summary>

public class MoveToUIPosition : MonoBehaviour {

	public Transform uiCanvasPosition;
	private Vector3 startPosition;
	public float plusPos;

	// Use this for initialization
	void Start () {
		startPosition = Camera.main.ScreenToWorldPoint (uiCanvasPosition.position);
		gameObject.transform.position = new Vector3 (startPosition.x + plusPos/4, startPosition.y +plusPos, -2f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
