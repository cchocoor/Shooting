using UnityEngine;
using System.Collections;

/// <summary>
/// BoundItemMove
/// (BoundItemのみ)弾をよけようとする動き
/// </summary>
public class BoundItemMove : MonoBehaviour {

	private GameObject[] bullets;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Bullet") {
			Debug.Log ("Enter bullet 02 position : "+ other.transform.position );
			Debug.Log ("Oen Position : "+ gameObject.transform.position);
			RunAwayFromBullets (true, other.transform.position);
		}
	}
	
	void OnTriggerStay(Collider other) {}

	/// <summary>
	/// RunAwayFromBullets
	/// </summary>
	/// <param name="isEnterOwnField">テリトリーに弾が入ってきたフラグ</param>
	/// <param name="course">弾のある方向</param>
	public void RunAwayFromBullets (bool isEnterOwnField, Vector3 course) {
		// 自分の守備範囲に弾がはいったら
		Vector3 centerPosition = Vector3.Lerp (gameObject.transform.position, course, 0.5f);
		Debug.Log ("centerPosition : "+ centerPosition);
		float tilt = (gameObject.transform.position.y - course.y) / (gameObject.transform.position.x - course.x);
		float a = -1f / tilt;
		float b = centerPosition.y - a * centerPosition.x;
		float x = gameObject.transform.position.x + 2f;
		float y = a * (x - b);
		if (float.IsInfinity(y)){
			y = 0;
			gameObject.transform.position = new Vector3 (2f, 0, y);
			Debug.Log(gameObject.transform.position);
		}
	}
}
