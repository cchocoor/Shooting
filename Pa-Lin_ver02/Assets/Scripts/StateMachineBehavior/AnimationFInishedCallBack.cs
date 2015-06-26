using UnityEngine;
using System.Collections;

public class AnimationFInishedCallBack : StateMachineBehaviour {

	private MonoBehaviour monobehaviour;

	void Start() {
	
	}

	//スクリプトが貼り付けられたステートマシンから出て行く時に実行
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		GameReference.transitionManager.SelectNextScene (ConstantData.RESULT_SCENE);
		Debug.Log ("Next scene is ResultScene");
	}
}
