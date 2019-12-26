using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LSystemsMain)), CanEditMultipleObjects]
public class LSystemsMainEditor : Editor
{
    private LSystemsMain targetScript;
    private SerializedObject soTarget;

    private SerializedProperty lStringDataContainer;
    private SerializedProperty prefabToSpawn;
    private SerializedProperty mutationRules;
    private SerializedProperty charActionPairs;
    private SerializedProperty lSystemSettings;

    private void OnEnable() 
    {
        targetScript = (LSystemsMain)target;
        soTarget = new SerializedObject(target);

        lStringDataContainer = soTarget.FindProperty("lStringDataContainer");
        prefabToSpawn = soTarget.FindProperty("prefabToSpawn");
        mutationRules = soTarget.FindProperty("mutationRules");
        charActionPairs = soTarget.FindProperty("charActionPairs");
        lSystemSettings = soTarget.FindProperty("lSystemSettings");
    }

    public override void OnInspectorGUI()
    {
        soTarget.Update();

        EditorGUI.BeginChangeCheck();

        EditorGUILayout.PropertyField(lStringDataContainer);
        EditorGUILayout.PropertyField(prefabToSpawn);

        if ( EditorGUI.EndChangeCheck() )
        {
            soTarget.ApplyModifiedProperties();
        }

        // Check if tabs have been changed
        // If so apply those changes to LSystemsMain variables
        EditorGUI.BeginChangeCheck();

        targetScript.openTab = GUILayout.Toolbar( targetScript.openTab, 
            new string [] { "Mutation Rules", "Action Map", "LSystem Parameters" } );

        switch ( targetScript.openTab )
        {
            case 0:
                targetScript.currentTabName = "Mutation Rules";
                break;
            case 1:
                targetScript.currentTabName = "Action Map";
                break;
            case 2:
                targetScript.currentTabName = "LSystem Parameters";
                break;
        }

        if ( EditorGUI.EndChangeCheck() )
        {
            soTarget.ApplyModifiedProperties();
            GUI.FocusControl(null);
        }

        // Check if changes to variables within tab have been modified
        // If so apply those changes to LSystemsMain variables
        EditorGUI.BeginChangeCheck();

        switch ( targetScript.currentTabName )
        {
            case "Mutation Rules":
                EditorGUILayout.PropertyField(mutationRules);
                break;
            case "Action Map":
                EditorGUILayout.PropertyField(charActionPairs);
                break;
            case "LSystem Parameters":
                EditorGUILayout.PropertyField(lSystemSettings);
                break;
        }

        if ( EditorGUI.EndChangeCheck() )
        {
            soTarget.ApplyModifiedProperties();
            targetScript.OnEditorDataUpdate();
        }

        if ( GUILayout.Button( "Print Stored LString Character Types" ) )
        {
            targetScript.GetLStringData().PrintAllLStringCharacters();
        }

        if ( GUILayout.Button("Display Final LString") )
        {
            targetScript.GetLStringData().PrintFinalLString();
        }
    }
}
