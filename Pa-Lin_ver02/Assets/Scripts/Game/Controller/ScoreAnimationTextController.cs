using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreAnimationTextController : MonoBehaviour {
	public Text text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void FinishedScoreTextAnimation() {
		Destroy (gameObject.transform.parent.gameObject,1.0f);
	}

	public void NextAction(int score) {

	}
}
