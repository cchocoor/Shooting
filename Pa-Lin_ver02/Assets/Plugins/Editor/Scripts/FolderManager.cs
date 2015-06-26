using UnityEngine;
using System.Collections;
using System.IO;                                                                        
using UnityEditor;

public class FolderManager {
	// フォルダを定義
	static string[] paths = new string[]{"Prefabs","Materials","Scripts","Scenes","Textures","Sounds","Plugins","Animations"};
	// 拡張子を定義
	static string[] extensions = new string[]{".png",".mat",".unity",".cs",".prefab",".wav"};

	[MenuItem("Custom/Tools/Folder")] 
	static void CreateFolder(){
		Debug.Log ("Start");
		// アセット直下のファイルを見つける
		foreach(string path in FolderManager.paths){
			if(!Directory.Exists("Assets/" + path)){
				Directory.CreateDirectory("Assets/" + path);

			}
		}
		AssetDatabase.Refresh ();
	}
	
	[MenuItem("Custom/Tools/FileMove")] 
	static void FileMove() {
		// FaceTextかどうかcheck
		if(EditorSettings.serializationMode != SerializationMode.ForceText) {
			// キャンセルなら抜ける
			if(!EditorUtility.DisplayDialog(
									"Change your local EditorSettings",
									"Your Editor Settings is "+ EditorSettings.serializationMode +", So change FoceText .ß",
									"OK",
									"Cancel")) {
				Debug.Log("処理停止");
				return;
			} else {
				// OKならやっとChangeMode（）呼ぶ 
				ChangeMode();
			}
		}
		// ファイルの移動
		string[] fileNames;
		fileNames = Directory.GetFiles ("Assets");
		foreach(string fileName in fileNames) {

			// Mat なのか Png なのかを判断
			foreach(string extension in FolderManager.extensions ) {
				bool fileIsExist = fileName.Contains(extension);
				if(fileIsExist) {
					string[] splitFileName = fileName.Split('/');
					switch(extension){
						case ".png":
							File.Move(fileName, "Assets/Textures/" + splitFileName[splitFileName.Length-1]);
						break;
						case ".mat":
							File.Move(fileName, "Assets/Materials/" + splitFileName[splitFileName.Length-1]);
						break;
						case ".unity":
							File.Move(fileName, "Assets/Scenes/" + splitFileName[splitFileName.Length-1]);
						break;
						case ".cs":
						File.Move(fileName, "Assets/Scripts/" + splitFileName[splitFileName.Length-1]);
						break;
						case ".prefab":
						File.Move(fileName, "Assets/Prefabs/" + splitFileName[splitFileName.Length-1]);
						break;
						case ".wav":
						File.Move(fileName, "Assets/Sounds/" + splitFileName[splitFileName.Length-1]);
						break;
					}
				}
			}
		}
		AssetDatabase.Refresh ();
	}
	
	static void ChangeMode() {
		if(EditorSettings.serializationMode == SerializationMode.ForceText) {
			return;
		}
		EditorSettings.serializationMode = SerializationMode.ForceText;
	}
}
