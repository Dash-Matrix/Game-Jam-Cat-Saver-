using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switches : MonoBehaviour
{
    public enum SwitchType
    {
        Door,
        Lift,
        PowerBank
    }

    public SwitchType switchType;

    public Transform Gate;
    public Transform Lift;
    public int Power;

    public void Interacted(ref int battery)
    {
        switch (switchType)
        {
            case SwitchType.Door:
                if(battery >= Power)
                {
                    battery -= Power;
                    HandleDoor();
                    Debug.Log("Powered Up The Gate");
                }
                else
                {
                    Debug.Log("Not Enough Battery to Power Up Gate");
                }
                break;
            case SwitchType.Lift:
                if (battery >= Power)
                {
                    battery -= Power;
                    HandleLift();
                    Debug.Log("Powered Up The Lift");
                }
                else
                {
                    Debug.Log("Not Enough Battery to Power Up Lift");
                }
                break;
            case SwitchType.PowerBank:
                if(Power > 0)
                {
                    battery += Power;
                    HandlePowerBank();
                    Debug.Log("Power Bank to Charged Up the Battery to : " + battery);
                }
                else
                {
                    Debug.Log("Not Enough Power Bank Battery to Charge up the Battery");
                }
                break;
            default:
                Debug.LogWarning("Unknown switch type!");
                break;
        }
    }

    private void HandleDoor()
    {
        Debug.Log("Door interaction handled.");
        Gate.DOLocalMoveY(3.5f, 0.5f);
    }

    private void HandleLift()
    {
        Debug.Log("Lift interaction handled.");
        Lift.DOLocalMoveY(5.5f, 2f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

    private void HandlePowerBank()
    {
        Debug.Log("PowerBank interaction handled.");
        Power = 0;
    }
}
