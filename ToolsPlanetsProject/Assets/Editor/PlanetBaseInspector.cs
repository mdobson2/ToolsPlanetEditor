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
        GUIContent content = new GUIContent();
        serializedObject.Update();
        EditorGUILayout.LabelField("Body");
        EditorGUILayout.BeginVertical("box");
        {
            content.text = "Main Color: ";
            content.tooltip = "The primary color that the planet will be overall";
            planetBaseReference.mainColor = EditorGUILayout.ColorField(content, planetBaseReference.mainColor);
            content.text = "Planet Radius (in miles):";
            content.tooltip = "The radius of this planet in miles \nEarth has a radius of 3,959 miles";
            planetBaseReference.planetSize = EditorGUILayout.IntField(content, Mathf.Max(0, planetBaseReference.planetSize));
            content.text = "Day Length (in Earth hours):";
            content.tooltip = "The length of one day being measured in Earth hours";
            planetBaseReference.revolutionTime = EditorGUILayout.FloatField(content, Mathf.Max(0, planetBaseReference.revolutionTime));
            content.text = "Year Length (in Planet Days):";
            content.tooltip = "The number of days that make up one year of this planet \nEarth has a year of 365 days";
            planetBaseReference.orbitTime = EditorGUILayout.FloatField(content, Mathf.Max(0, planetBaseReference.orbitTime));
            content.text = "Amount of moons:";
            content.tooltip = "The number of moons that orbit this planet";
            planetBaseReference.moonAmount = EditorGUILayout.IntField(content, Mathf.Max(0, planetBaseReference.moonAmount));
        }
        EditorGUILayout.EndVertical();

        EditorGUILayout.LabelField("Geography");
        EditorGUILayout.BeginVertical("box");
        {
            content.text = "Has Water:";
            content.tooltip = "Does this planet have water";
            planetBaseReference.hasWater = EditorGUILayout.Toggle(content, planetBaseReference.hasWater);
            content.text = "Elevation Range (in miles):";
            content.tooltip = "The lowest and highest elevations on this planet measured in miles";
            EditorGUILayout.MinMaxSlider(content, ref planetBaseReference.lowElevation, ref planetBaseReference.highElevation, -100, 100);
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField("Low: " + planetBaseReference.lowElevation);
                EditorGUILayout.LabelField("High: " + planetBaseReference.highElevation);
            }
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndVertical();

        EditorGUILayout.LabelField("Features");
        EditorGUILayout.BeginVertical("box");
        {
            content.text = "Elevation Range (in celsius):";
            content.tooltip = "The highest and lowest temporature that this planet will reach \nMeasured in celsius \nEarth's average temperature is 16C";
            EditorGUILayout.MinMaxSlider(content, ref planetBaseReference.lowTemp, ref planetBaseReference.highTemp, -100, 100);
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField("Low: " + planetBaseReference.lowTemp);
                EditorGUILayout.LabelField("High: " + planetBaseReference.highTemp);
            }
            EditorGUILayout.EndHorizontal();
            content.text = "Radiation (in rads):";
            content.tooltip = "The amount of radiation that is found on this planet";
            planetBaseReference.radiationAmount = EditorGUILayout.FloatField(content, Mathf.Max(0,planetBaseReference.radiationAmount));
            content.text = "Main Elements";
            content.tooltip = "List of the main elements that are found on this planet";
            SerializedProperty elementArray = serializedObject.FindProperty("mainElements");
            EditorGUILayout.PropertyField(elementArray, content, true);
        }
        EditorGUILayout.EndVertical();

        EditorGUILayout.LabelField("Habitation");
        EditorGUILayout.BeginVertical("box");
        {
            content.text = "Planet is habitable";
            content.tooltip = "Is this planet naturally habitable";
            planetBaseReference.isHabitable = EditorGUILayout.BeginToggleGroup(content, planetBaseReference.isHabitable);
            {
                if(planetBaseReference.isHabitable == false)
                {
                    planetBaseReference.flora = false;
                    planetBaseReference.fauna = false;
                }
                content.text = "Planet has flora";
                content.tooltip = "Does the planet have plant life";
                if(planetBaseReference.isHabitable == false)
                {
                    content.tooltip = "Does the planet have plant life\nMust be habitable to have flora";
                }
                planetBaseReference.flora = EditorGUILayout.BeginToggleGroup(content, planetBaseReference.flora);
                {
                    if(planetBaseReference.flora == false)
                    {
                        planetBaseReference.fauna = false;
                    }
                    content.text = "Planet has fauna";
                    content.tooltip = "Does the planet have animal life";
                    if(planetBaseReference.flora == false)
                    {
                        content.tooltip = "Does the planet have animal life\nMust have flora to have fauna";
                    }
                    planetBaseReference.fauna = EditorGUILayout.ToggleLeft(content, planetBaseReference.fauna);
                }
                EditorGUILayout.EndToggleGroup();
            }
            EditorGUILayout.EndToggleGroup();
            content.text = "Planet has Intelligent Creatures";
            content.tooltip = "Does the planet have intelligent creatures on it, naturally or extra terrestrial";
            planetBaseReference.intelligentCreatures = EditorGUILayout.BeginToggleGroup(content, planetBaseReference.intelligentCreatures);
            {
                content.text = "Intelligent population:";
                content.tooltip = "How large is the intelligent population";
                if(planetBaseReference.intelligentCreatures == false)
                {
                    planetBaseReference.icPopulation = 0;
                    content.tooltip = "How large is the intelligent population\nMust have an intelligent population to define a population";
                }
                planetBaseReference.icPopulation = EditorGUILayout.IntField(content, Mathf.Max(0, planetBaseReference.icPopulation));
            }
            EditorGUILayout.EndToggleGroup();
        }
        EditorGUILayout.EndVertical();

        serializedObject.ApplyModifiedProperties();
    }
}
