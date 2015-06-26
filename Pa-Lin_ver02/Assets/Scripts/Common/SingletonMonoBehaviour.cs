using UnityEngine;

/// <summary>
/// シングルトンMonoBehavioir
/// 継承するとシングルトンになります
/// Tは、このクラスでは決めきれない型の仮定義
/// </summary>
public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour{
	
	private static T instance;
	
	public static T Instance {
		get {
			// instanceがnullだったら
			if (instance == null) {
				// T typeのゲームオブジェクトをみつける
				instance = (T)FindObjectOfType(typeof(T));
				// instanceがなかったら
				if(instance == null) {
					// 新しくinstanceを作る
					instance = new GameObject(typeof(T).ToString()).AddComponent<T>();
				}
			}
			return instance;
		}
	}
	

	//=================================================================================
	// 初期化
	//=================================================================================
	protected virtual void Awake (){
		if(CheckInstance()) {
			Init();
		}
	}
	
	//=================================================================================
	// 初期化したい時にoverrideして使う
	// AudioManagerなどのシーンをまたいでもBGMを流しておきたい場合など
	// DontDestroy()とかを中に書いとく
	//=================================================================================
	protected virtual void Init(){}
	
	protected bool CheckInstance() {
		// Instanceが2こ以上生成されない保証
		if( this == Instance ) {return true;}
		Destroy(gameObject);
		return false;
	}	

}