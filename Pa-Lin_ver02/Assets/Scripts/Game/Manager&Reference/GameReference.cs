using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// GameObjectReferenceの説明
/// </summary>
public class GameReference : SingletonMonoBehaviour<GameReference> {
	private Camera _mainCamera; 
	public static Camera mainCamera {
		get {
			if (Instance._mainCamera == null) {
				GameObject mainCameraObject = GameObject.Find("Main Camera");
				if (mainCameraObject == null) {
					return null;
				} else {
					Instance._mainCamera = mainCameraObject.GetComponent<Camera>();
				}
			}
			return Instance._mainCamera;
		}
	}
	
	private ScoreManager _scoreManager; 
	public static ScoreManager ScoreManager {
		get {
			if (Instance._scoreManager == null) {
				GameObject scoreManagerObject = GameObject.Find("GameController");
				if (scoreManagerObject == null) {
					return null;
				} else {
					Instance._scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
				}
			}
			return Instance._scoreManager;
		}
	}

	private GameController _gameController;
	public static GameController gameController {
		get {
			if(Instance._gameController == null) {
				GameObject gameCOntrollerObject = GameObject.Find ("GameController");
				if(gameCOntrollerObject == null) {
					return null;
				} else {
					Instance._gameController = gameCOntrollerObject.GetComponent<GameController>();
				}
			}
			return Instance._gameController;
		}
	}

	private GameObject _playerControllerGO;
	public static GameObject playerControllerGO {
		get {
			if(Instance._playerControllerGO == null) {
				GameObject playerCOntrollerGOObject = GameObject.Find("PlayerController");
				if(playerCOntrollerGOObject == null) {
					return null;
				} else {
					Instance._playerControllerGO = playerCOntrollerGOObject;
				}
			}
			return Instance._playerControllerGO;
		}
	}

	private PlayerController _playerController;
	public static PlayerController playerController {
		get {
			if(Instance._playerController == null) {
				GameObject playerControllerObject = GameObject.Find ("PlayerController");
				if(playerControllerObject == null) {
					return null;
				} else {
					Instance._playerController = playerControllerObject.GetComponent<PlayerController>();
				}
			}
			return Instance._playerController;
		}
	}

	private AnimationCallFunction _animationCallFunction;
	public static AnimationCallFunction animationCallFunction {
		get {
			if(Instance._animationCallFunction == null) {
				GameObject animationCallFunctionObject = GameObject.Find ("CountDownCanvas");
				if(animationCallFunctionObject == null) {
					return null;
				} else {
					Instance._animationCallFunction = animationCallFunctionObject.GetComponent <AnimationCallFunction>();
				}
			}
			return Instance._animationCallFunction;
		}
	}

	private TimerController _timerController;
	public static TimerController timerController {
		get {
			if(Instance._timerController == null) {
				Instance._timerController = GameReference.gameController.GetComponent<TimerController>();
			}
			return Instance._timerController;
		}
	}

	private GameObject _batteryControllerGO;
	public static GameObject batteryControllerGO {
		get {
			if(Instance._batteryControllerGO == null) {
				GameObject batteryControllerGOObject = GameObject.Find("Battery");
				if(batteryControllerGOObject == null) {
					return null;
				} else {
					Instance._batteryControllerGO = batteryControllerGOObject;
				}
			}
			return Instance._batteryControllerGO;
		}
	}

	private BatteryController _batteryController;
	public static BatteryController batteryController {
		get {
			if(Instance._batteryController == null) {
				GameObject batteryControllerObject = GameObject.Find ("Battery");
				if(batteryControllerObject == null) {
					return null;
				} else {
					Instance._batteryController = batteryControllerObject.GetComponent<BatteryController>();
				}
			}
			return Instance._batteryController;
		}
	}
	private SoundManager _soundManager;
	public static SoundManager soundManager {
		get {
			if(Instance._scoreManager == null) {
				GameObject soundManagerObject = GameObject.Find("SoundManager");
				if(soundManagerObject == null) {
					return null;
				} else {
					Instance._soundManager = soundManagerObject.GetComponent<SoundManager> ();
				}
			}
			return Instance._soundManager;
		}
	}

	private TransitionManager _transitionManager;
	public static TransitionManager transitionManager {
		get {
			if(Instance._transitionManager == null) {
				GameObject mainCamera = GameObject.Find("TransitionPanel");
				if(mainCamera == null) {
					return null;
				} else {
					Instance._transitionManager = mainCamera.GetComponent<TransitionManager> ();
				}
			}
			return Instance._transitionManager;
		}
	}
	private GameObject _generatorGO;
	public static GameObject generatorGO {
		get {
			if(Instance._generatorGO == null) {
				GameObject generatorObject = GameObject.Find("Generator");
				if(generatorObject == null) {
					return null;
				} else {
					Instance._generatorGO = generatorObject;
				}
			}
			return Instance._generatorGO;
		}
	}
	private Generator _generator;
	public static Generator generator {
		get {
			if(Instance._generatorGO == null) {
				GameObject generatorObject = GameReference.generatorGO;
				if(generatorObject == null) {
					return null;
				} else {
					Instance._generator = generatorObject.GetComponent<Generator>();
				}
			}
			return Instance._generator;
		}
	}
//	private GameObject _kirakiraFx;
//	public static GameObject kirakiraFx {
//		get {
//			if(Instance._kirakiraFx == null) {
//				GameObject kirakiraFxObject = GameObject.Find("kirakira");
//				if(kirakiraFxObject == null) {
//					return null;
//				} else {
//					Instance._kirakiraFx = kirakiraFxObject;
//				}
//			}
//			return Instance._kirakiraFx;
//		}
//	}
}