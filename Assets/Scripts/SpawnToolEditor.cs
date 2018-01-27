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
            if (e.type == EventType.KeyUp && e.keyCode == KeyCode.Space)
            {
                // if()
                // Ray worldRay = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
                // RaycastHit hitInfo;
 
               
                // if (Physics.Raycast(worldRay, out hitInfo))
                // {
                    GameObject circle = AssetDatabase.LoadAssetAtPath("Assets/Prefab/Circle.prefab", typeof(GameObject)) as GameObject;
                    GameObject circleInstance = Instantiate(circle) as GameObject;
                    Vector2 mousePos = Event.current.mousePosition;
                    mousePos.y = Camera.current.pixelHeight - mousePos.y;
                    // mousePos.x = Camera.current.pixelWidth - mousePos.x;
                    Vector3 position = Camera.current.ScreenPointToRay(mousePos).origin;
                    position = new Vector3(position.x, position.y, 0);
                    circleInstance.transform.position = position;
                    // Undo.RecordObject(circleInstance);
                // }
            }
 
        }

    }
    public override void OnInspectorGUI()
    {
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