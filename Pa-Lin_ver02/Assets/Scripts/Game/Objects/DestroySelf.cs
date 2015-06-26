using UnityEngine;
using System.Collections;

/// <summary>
/// あたり判定を元に自分自身がアクションを起こすclass
/// </summary>

public class DestroySelf : MonoBehaviour {
	private ParticleSystem[] _particleSystem;
	public SpriteRenderer _renderer;
	SphereCollider circleCol;
	[SerializeField] CreateOwnCopyAsUIImage createOPAsImage;
	private bool isScoreItem;
	int count;

	// Use this for initialization
	void Start () {
		_particleSystem = gameObject.GetComponentsInChildren<ParticleSystem> ();

		circleCol = gameObject.GetComponent<SphereCollider> ();
		if (gameObject.tag == "ScoreUpItem")
			isScoreItem = true;
	}


	void OnCollisionEnter(Collision col) {
	
		if (col.gameObject.tag == "Bullet") {
			// isTrigger true
			circleCol.isTrigger = true;
			_renderer.enabled = false;


			foreach(ParticleSystem ps in _particleSystem) {
				ps.Emit(5);
			}
			// particleSystem表示後死亡
			Destroy(gameObject, 2f);
		}
	}
}
