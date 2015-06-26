using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 画面全体にコライダーを生成する
/// </summary>
public class GetScreenPosition : MonoBehaviour {
	
	/// サイズを設定.
	public float _width = 0.0f;
	public float _height = 0.0f;
	private float center = 0.5f;
	[SerializeField] private GameObject upCol;
	[SerializeField] private GameObject bottomCol;
	[SerializeField] private GameObject leftCol;
	[SerializeField] private GameObject rightCol;
	public float plusSize = 10f;

	void Start () {
		GetWorldLeftMin ();
		GetWorldRightMax ();
		FourPointPos ();
	}

	/// <summary>
	/// 画面の左下のワールド座標を取得
	/// </summary>
	/// <returns> Returns min </returns>
	public Vector3 GetWorldLeftMin () {
		Vector3 min = Camera.main.ViewportToWorldPoint (Vector3.zero);
		min = new Vector3 (min.x, 0, min.z);
		return min;
	}

	/// <summary>
	/// 画面右上のワールド座標を取得
	/// </summary>
	/// <returns> Returns max </returns>
	public Vector3 GetWorldRightMax () {
		Vector3 max = Camera.main.ViewportToWorldPoint (Vector3.one);
		max = new Vector3 (max.x, 0, max.z);
		return max;
	}

	/// <summary>
	/// 4つの場所にコライダー生成
	/// </summary>
	private void FourPointPos() {
		Vector3 leftMin = GetWorldLeftMin ();
		Vector3 rightMax = GetWorldRightMax ();
		Vector3 leftMax = new Vector3 (leftMin.x, 0, rightMax.z);
		Vector3 rightMin = new Vector3 (rightMax.x, 0, leftMin.z);
		
//		Debug.Log (string.Format("leftMin : {0}  leftMax : {1} rightMax : {2} rightMin : {3}", leftMin, leftMax, rightMax, rightMin));
		
		// collider pos
		leftCol.transform.position = Vector3.Lerp (leftMax, leftMin, center);
		upCol.transform.position = Vector3.Lerp (leftMax, rightMax, center);
		rightCol.transform.position = Vector3.Lerp (rightMax, rightMin, center);
		bottomCol.transform.position = Vector3.Lerp (leftMin, rightMin, center);
		
		Vector3 heightSize = new Vector3 ((rightMax.x - leftMax.x) + plusSize, 10f, upCol.transform.localScale.z);
		Vector3 widthSize = new Vector3 (leftCol.transform.localScale.x, 10f, (leftMax.z - leftMin.z) + plusSize);
		
		// collider scale
		leftCol.transform.localScale = widthSize;
		upCol.transform.localScale = heightSize;
		rightCol.transform.localScale = widthSize;
		bottomCol.transform.localScale = heightSize;
	}
}
