#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using System.Linq;
using System;

[CustomEditor(typeof(StageData))]
public class StageDataEditor : Editor
{
    private enum TileType { None, iron, brick, heart }

    private StageData sd;
    
    private Texture2D ironTexture;
    private Texture2D brickTexture;
    private Texture2D heartTexture;

    private Dictionary<TileType, Rect> brushButtonRectDict;
    private Dictionary<TileType, Texture2D> textureDict;
    private TileType currentSelectedBrushType;

    public override VisualElement CreateInspectorGUI()
    {
        sd = target as StageData;
        InitPalette();
        return base.CreateInspectorGUI();
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUIPalette();
        GUILevel();
    }

    private void InitPalette()
    {
        ironTexture = (Texture2D)Resources.Load("iron");
        brickTexture = (Texture2D)Resources.Load("brick");        
        heartTexture = (Texture2D)Resources.Load("heart");

        textureDict = new Dictionary<TileType, Texture2D>();
        textureDict.Add(TileType.None, null);
        textureDict.Add(TileType.iron, ironTexture);
        textureDict.Add(TileType.brick, brickTexture);
        textureDict.Add(TileType.heart, heartTexture);
    }

    private void GUIPalette()
    {        
        GUILayout.Space(10);
        GUILayout.BeginHorizontal();

        if (GUILayout.Button(new GUIContent("", "brick"), GUILayout.Width(30), GUILayout.Height(30)))
        {
            SetBrush(TileType.brick);
        }
        var lastRect = GUILayoutUtility.GetLastRect();
        GUI.DrawTexture(lastRect, brickTexture, ScaleMode.ScaleAndCrop, true, 1f, currentSelectedBrushType == TileType.brick ? Color.gray : Color.white, 0f, 10f);

        if (GUILayout.Button(new GUIContent("", "iron"), GUILayout.Width(30), GUILayout.Height(30)))
        {
            SetBrush(TileType.iron);
        }
        lastRect = GUILayoutUtility.GetLastRect();
        GUI.DrawTexture(lastRect, ironTexture, ScaleMode.ScaleAndCrop, true, 1f, currentSelectedBrushType == TileType.iron ? Color.gray : Color.white, 0f, 10f);

        if (GUILayout.Button(new GUIContent("", "heart"), GUILayout.Width(30), GUILayout.Height(30)))
        {
            SetBrush(TileType.heart);
        }
        lastRect = GUILayoutUtility.GetLastRect();
        GUI.DrawTexture(lastRect, heartTexture, ScaleMode.ScaleAndCrop, true, 1f, currentSelectedBrushType == TileType.heart ? Color.gray : Color.white, 0f, 10f);

        GUILayout.EndHorizontal();
        GUILayout.Space(10);
    }

    private void GUILevel()
    {
        for (int i = 0; i < 15; i++)
        {
            GUILayout.BeginHorizontal();
            for (int j = 0; j < 15; j++)
            {
                //int oldTile = levelData[i, j];
                //string label = oldTile.ToString();

                if (GUILayout.Button("", GUILayout.Width(30), GUILayout.Height(30)))
                {
                    if (Event.current.button == 1)
                        sd.mapArray[i, j] = 0;
                    else
                        sd.mapArray[i, j] = (int)currentSelectedBrushType; // 클릭 시 선택된 타일로 변경
                }
                if (currentSelectedBrushType != TileType.None)
                {
                    var lastRect = GUILayoutUtility.GetLastRect();
                    GUI.DrawTexture(lastRect, textureDict[(TileType)sd.mapArray[i, j]], ScaleMode.ScaleAndCrop, true, 1f, Color.white, 0f, 10f);
                }
            }
            GUILayout.EndHorizontal();
        }
    }

    private void SetBrush(TileType type)
    {
        currentSelectedBrushType = type;
    }
}
#endif