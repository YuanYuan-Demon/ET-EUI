using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CustomEditor(typeof (LoopList), true)]
public class LoopScrollRectInspector: Editor
{
    private int index;
    private float speed = 1000, time = 1;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.Space();

        var scroll = (LoopList)this.target;
        GUI.enabled = Application.isPlaying;

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Clear"))
        {
            scroll.ClearCells();
        }

        if (GUILayout.Button("Refresh"))
        {
            scroll.RefreshCells();
        }

        if (GUILayout.Button("Refill"))
        {
            scroll.RefillCells();
        }

        if (GUILayout.Button("RefillFromEnd"))
        {
            scroll.RefillCellsFromEnd();
        }

        EditorGUILayout.EndHorizontal();

        EditorGUIUtility.labelWidth = 45;
        var w = (EditorGUIUtility.currentViewWidth - 100) / 2;
        this.index = EditorGUILayout.IntField("Index", this.index, GUILayout.Width(w));
        EditorGUILayout.BeginHorizontal();
        EditorGUIUtility.labelWidth = 60;
        this.speed = EditorGUILayout.FloatField("    Speed", this.speed, GUILayout.Width(w + 15));
        if (GUILayout.Button("Scroll With Speed", GUILayout.Width(130)))
        {
            scroll.SrollToCell(this.index, this.speed);
        }

        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUIUtility.labelWidth = 60;
        this.time = EditorGUILayout.FloatField("    Time", this.time, GUILayout.Width(w + 15));
        if (GUILayout.Button("Scroll Within Time", GUILayout.Width(130)))
        {
            scroll.SrollToCellWithinTime(this.index, this.time);
        }

        EditorGUILayout.EndHorizontal();
    }
}