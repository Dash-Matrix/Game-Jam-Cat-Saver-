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
    public SpriteRenderer SwitchPower;
    public int Power;

    public bool Interactable()
    {
        if (Power <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Interacted(ref int battery, ref SpriteRenderer batteryColor)
    {
        switch (switchType)
        {
            case SwitchType.Door:
                if(battery >= Power && Power > 0)
                {
                    battery -= Power;
                    Power = 0;
                    SwitchPower.DOColor(new Color(130, 255, 130), 0.5f);
                    HandleDoor();
                    Debug.Log("Powered Up The Gate");

                    if(battery <= 0)
                    {
                        batteryColor.DOColor(new Color(100, 0, 0), 1);
                    }
                }
                else
                {
                    Debug.Log("Not Enough Battery to Power Up Gate");
                }
                break;
            case SwitchType.Lift:
                if (battery >= Power && Power > 0)
                {
                    battery -= Power;
                    Power = 0;
                    SwitchPower.DOColor(new Color(130, 255, 130), 0.5f);
                    HandleLift();
                    Debug.Log("Powered Up The Lift");

                    if (battery <= 0)
                    {
                        batteryColor.DOColor(new Color(100, 0, 0), 1);
                    }
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
                    Power = 0;
                    SwitchPower.DOColor(new Color(100, 0, 0), 1);
                    batteryColor.DOColor(Color.yellow, 1);
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
    }
}
