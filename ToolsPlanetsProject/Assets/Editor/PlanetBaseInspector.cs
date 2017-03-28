using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlanetBase))]
public class PlanetBaseInspector : Editor {

    PlanetBase planetBaseReference;

    void OnEnable()
    {
        planetBaseReference = (PlanetBase)target;
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        //serializedObject.Update(); //used to update the current gui to values in the inspector
        EditorGUILayout.ColorField("Main Color: ", planetBaseReference.mainColor);
        //serializedObject.ApplyModifiedProperties(); //used to update the information stored in the system
    }
}
