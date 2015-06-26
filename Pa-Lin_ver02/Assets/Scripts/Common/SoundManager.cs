using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// SoundManagerの説明
/// </summary>
public class SoundManager : MonoBehaviour {

	[SerializeField] AudioSource SeSource;
	static public SoundManager instance;
	public List<AudioClip> BGMList; // gingle & BGM
	public List<AudioClip> SEList; // SE

	//=================================================================================
	//初期化
	//=================================================================================

	void Awake (){
//		// 自分自身が複数生成されるのを防ぐ
		if (instance == null) {	
			instance = this;
			// 画面遷移のタイミングで、自分自身がDestroyされるのを防ぐ
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy(gameObject);
		}
	}

	void Start () {
	
	}
	
	//=================================================================================
	//更新
	//=================================================================================
	void Update () {
	
	}
	
	public void PlaySE(AudioClip clipSE) {
		AudioSource audioSource = GetComponent<AudioSource>();
		audioSource.PlayOneShot(clipSE);
	}
	
	public void StopSe(AudioClip clipSE) {
		
	}
	
	public void PlayBGM(AudioClip clipBGM) {
		
	}
	
	public void StopBGM(AudioClip clipBGM) {
		
	}
	

}