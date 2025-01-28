using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Switches))]
public class SwitchesEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Switches switches = (Switches)target;

        // Draw the default enum dropdown
        switches.switchType = (Switches.SwitchType)EditorGUILayout.EnumPopup("Switch Type", switches.switchType);

        // Show fields based on the selected enum
        switch (switches.switchType)
        {
            case Switches.SwitchType.Door:
                switches.Gate = (Transform)EditorGUILayout.ObjectField("Gate", switches.Gate, typeof(Transform), true);
                switches.SwitchPower = (SpriteRenderer)EditorGUILayout.ObjectField("Switch Power", switches.SwitchPower, typeof(SpriteRenderer), true);
                switches.Power = EditorGUILayout.IntField("Power", switches.Power);
                break;

            case Switches.SwitchType.Lift:
                switches.Lift = (Transform)EditorGUILayout.ObjectField("Lift", switches.Lift, typeof(Transform), true);
                switches.SwitchPower = (SpriteRenderer)EditorGUILayout.ObjectField("Switch Power", switches.SwitchPower, typeof(SpriteRenderer), true);
                switches.Power = EditorGUILayout.IntField("Power", switches.Power);
                break;

            case Switches.SwitchType.PowerBank:
                switches.SwitchPower = (SpriteRenderer)EditorGUILayout.ObjectField("Switch Power", switches.SwitchPower, typeof(SpriteRenderer), true);
                switches.Power = EditorGUILayout.IntField("Power", switches.Power);
                break;
        }

        // Apply changes to the serialized object
        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }
}
