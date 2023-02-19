// using Features.Core.Scripts.Player;
// using UnityEditor;
// using UnityEngine;
//
// namespace Features.Core.Scripts.Editor
// {
//     // [CustomEditor(typeof(GameManager))]
//     public class GameManagerEditor : UnityEditor.Editor
//     {
//         // float thumbnailWidth = 70;
//         // float thumbnailHeight = 70;
//         readonly float _labelWidth = 150f;
//
//         string _playerName = "Player 1";
//         string _playerLevel = "1";
//         string _playerScore = "0";
//
//          // OnInspector GUI
//          public override void OnInspectorGUI()
//          {
              //// base.OnInspectorGUI();
              // _playerScore = PlayerPrefs.GetInt("HighScore", 0).ToString();
//              
//              // Call base class method
//              // base.DrawDefaultInspector();
//          
//              // Custom form for Player Preferences
//              // GameManager gameManager = (GameManager) target; //1
//
//              GUILayout.Space(20f); //2
//              GUILayout.Label("Custom Editor Elements", EditorStyles.boldLabel); //3
//
//              GUILayout.Space(10f);
//              GUILayout.Label("Player Preferences");
//
//              GUILayout.BeginVertical(); //4
//              // GUILayout.BeginHorizontal();
//              GUILayout.Label("Player Name", GUILayout.Width(_labelWidth)); //5
//              _playerName = GUILayout.TextField(_playerName); //6
//              GUILayout.EndHorizontal(); //7
//
//              GUILayout.BeginHorizontal();
//              GUILayout.Label("Player Level", GUILayout.Width(_labelWidth));
//              _playerLevel = GUILayout.TextField(_playerLevel);
//              GUILayout.EndHorizontal();
//
//              GUILayout.BeginHorizontal();
//              GUILayout.Label("Player Score", GUILayout.Width(_labelWidth)); 
//              _playerScore = GUILayout.TextField(_playerScore);
//              GUILayout.EndHorizontal();
//
//              GUILayout.BeginHorizontal();
//
//              if (GUILayout.Button("Save")) //8
//              {
//                  PlayerPrefs.SetString("PlayerName", _playerName); //9
//                  PlayerPrefs.SetString("PlayerLevel", _playerLevel);
//                  PlayerPrefs.SetString("HighScore", _playerScore);
//
//                  Debug.Log("PlayerPrefs Saved");
//              }
//
//              if (GUILayout.Button("Reset")) //10
//              {
//                  PlayerPrefs.DeleteAll();
//                  Debug.Log("PlayerPrefs Reset");
//              }
//
//              GUILayout.EndHorizontal();
//          
//              // Custom Button with Image as Thumbnail
//          }
//     }
// }
