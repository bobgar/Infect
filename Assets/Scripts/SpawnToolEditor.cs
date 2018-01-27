using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpawnTool))]
class SpawnToolEditor : Editor
{
    private static bool m_editMode = false;
    void OnSceneGUI()
    {
        Event e = Event.current;
        if (m_editMode)
        {
            if (e.type == EventType.KeyUp && e.keyCode == KeyCode.Z)
            {
                GameObject circle = AssetDatabase.LoadAssetAtPath("Assets/Prefab/Circle.prefab", typeof(GameObject)) as GameObject;
                GameObject circleInstance = PrefabUtility.InstantiatePrefab(circle) as GameObject;
                Vector2 mousePos = Event.current.mousePosition;
                mousePos.y = Camera.current.pixelHeight - mousePos.y;
                // mousePos.x = Camera.current.pixelWidth - mousePos.x;
                Vector3 position = Camera.current.ScreenPointToRay(mousePos).origin;
                position = new Vector3(position.x, position.y, 0);
                circleInstance.transform.position = position;
                Undo.RegisterCreatedObjectUndo(circleInstance, "Undo create circle");
            }
            if (e.type == EventType.KeyUp && e.keyCode == KeyCode.X)
            {
                GameObject triangle = AssetDatabase.LoadAssetAtPath("Assets/Prefab/Triangle.prefab", typeof(GameObject)) as GameObject;
                GameObject triangleInstance = PrefabUtility.InstantiatePrefab(triangle) as GameObject;
                Vector2 mousePos = Event.current.mousePosition;
                mousePos.y = Camera.current.pixelHeight - mousePos.y;
                // mousePos.x = Camera.current.pixelWidth - mousePos.x;
                Vector3 position = Camera.current.ScreenPointToRay(mousePos).origin;
                position = new Vector3(position.x, position.y, 0);
                triangleInstance.transform.position = position;
                Undo.RegisterCreatedObjectUndo(triangleInstance, "Undo create triangle");
            }
            if (e.type == EventType.KeyUp && e.keyCode == KeyCode.C)
            {
                GameObject square = AssetDatabase.LoadAssetAtPath("Assets/Prefab/Square.prefab", typeof(GameObject)) as GameObject;
                GameObject squareInstance = PrefabUtility.InstantiatePrefab(square) as GameObject;
                Vector2 mousePos = Event.current.mousePosition;
                mousePos.y = Camera.current.pixelHeight - mousePos.y;
                // mousePos.x = Camera.current.pixelWidth - mousePos.x;
                Vector3 position = Camera.current.ScreenPointToRay(mousePos).origin;
                position = new Vector3(position.x, position.y, 0);
                squareInstance.transform.position = position;
                Undo.RegisterCreatedObjectUndo(squareInstance, "Undo create square");
            }
 
        }

    }
    public override void OnInspectorGUI()
    {
        GUILayout.Label ("Enable Editing below then");
        GUILayout.Label ("Press z to instantiate circle");
        GUILayout.Label ("Press x to instantiate triangle");
        GUILayout.Label ("Press c to instantiate square");

        if (m_editMode)
        {
            if (GUILayout.Button("Disable Editing"))
            {
                m_editMode = false;
            }
        }
        else
        {
            if (GUILayout.Button("Enable Editing"))
            {
                m_editMode = true;
            }
        }
    }

}