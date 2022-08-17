using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SoundsData_SO)), CanEditMultipleObjects]
public class SoundsData_SO_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorUtility.SetDirty(this);

        SoundsData_SO myScript = (SoundsData_SO)target;
        
        if (GUILayout.Button("Set Names"))
        {
            myScript.Rename();
        }
    }
}
