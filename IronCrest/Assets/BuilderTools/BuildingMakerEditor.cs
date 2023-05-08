using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(BuildingMaker))]
[CanEditMultipleObjects]
    
public class BuildingMakerEditor : Editor   
{
    public override void OnInspectorGUI()
    {
        BuildingMaker maker = (BuildingMaker)target;
        EditorGUI.BeginChangeCheck();

        if(GUILayout.Button("CreateBuilding"))
        {
            maker.CreateBuilding();
        }

        EditorGUI.EndChangeCheck();
        EditorUtility.SetDirty(target);
        DrawDefaultInspector();
    }
}
