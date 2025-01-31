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
            case Switches.SwitchType.Lamp:
                switches.LampOn = (GameObject)EditorGUILayout.ObjectField("Lamp On", switches.LampOn, typeof(GameObject), true);
                switches.LampOff = (GameObject)EditorGUILayout.ObjectField("Lamp Off", switches.LampOff, typeof(GameObject), true);
                switches.Power = EditorGUILayout.IntField("Power", switches.Power);
                break;

            case Switches.SwitchType.Door:
                switches.Gate = (Transform)EditorGUILayout.ObjectField("Gate", switches.Gate, typeof(Transform), true);
                switches.GateOpen = EditorGUILayout.Vector2Field("Gate Open", switches.GateOpen);
                switches.SwitchPowerOn = (GameObject)EditorGUILayout.ObjectField("Switch On", switches.SwitchPowerOn, typeof(GameObject), true);
                switches.SwitchPowerOff = (GameObject)EditorGUILayout.ObjectField("Switch Off", switches.SwitchPowerOff, typeof(GameObject), true);
                switches.Power = EditorGUILayout.IntField("Power", switches.Power);
                break;

            case Switches.SwitchType.Lift:
                switches.Lift = (Transform)EditorGUILayout.ObjectField("Lift", switches.Lift, typeof(Transform), true);
                switches.LiftUp = EditorGUILayout.FloatField("Lift Up", switches.LiftUp);
                switches.SwitchPowerOn = (GameObject)EditorGUILayout.ObjectField("Switch On", switches.SwitchPowerOn, typeof(GameObject), true);
                switches.SwitchPowerOff = (GameObject)EditorGUILayout.ObjectField("Switch Off", switches.SwitchPowerOff, typeof(GameObject), true);
                switches.Power = EditorGUILayout.IntField("Power", switches.Power);
                break;

            case Switches.SwitchType.PowerBank:
                switches.BatteryOn = (GameObject)EditorGUILayout.ObjectField("Battery On", switches.BatteryOn, typeof(GameObject), true);
                switches.BatteryOff = (GameObject)EditorGUILayout.ObjectField("Battery Off", switches.BatteryOff, typeof(GameObject), true);
                switches.Power = EditorGUILayout.IntField("Power", switches.Power);
                break;

            case Switches.SwitchType.FireFlies:
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
