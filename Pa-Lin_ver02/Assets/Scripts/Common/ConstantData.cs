using UnityEngine;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;

/// <summary>
/// ConstantData
/// 定数を定義するクラス
/// </summary>
public class ConstantData {
		
	// Timer
	public const int INIT_TIMW_LIMIT = 10;

	// Scenes
	public const int TITLE_SCENE = 0;
	public const int GAME_SCENE = 1;
	public const int RESULT_SCENE = 2;

	public const float WAIT_TIME = 1.3f;

	public const string HIGH_SCORE_KEY = "highScore";

	// [SE Name]
	public const string ENEMY_HIT_SE = "scratchy_jump_rnd_01";
	public const string SCOREITEM_HIT_SE = "cute_rising_sequence_01";
	public const string TIMECOUNTUPITEM_HIT_SE = "clean_short_jump_01";

	// [Generator]
	public const int FIRST_ENEMY_CREATE_NUM = 10;
	public const int FIRST_BONUS_ITEM_CREATE_NUM = 3;
	public const int INVOKE_ENEMY_CREATE_NUM = 3;
	public const float WAIT_CREATE_TIME = 5.0f;

	public const int DESTROY_COUNT = 3;

	public const string BASE_SPRITE = "Sprites/Shape";
}