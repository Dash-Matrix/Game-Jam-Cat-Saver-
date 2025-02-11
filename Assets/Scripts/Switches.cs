using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switches : MonoBehaviour
{
    public enum SwitchType
    {
        Lamp,
        Door,
        Lift,
        PowerBank,
        FireFlies
    }

    public SwitchType switchType;

    public GameObject LampOn;
    public GameObject LampOff;
    public Transform Gate;
    public Vector2 GateOpen;
    public Transform Lift;
    public float LiftUp;
    public GameObject SwitchPowerOn;
    public GameObject SwitchPowerOff;
    public GameObject BatteryOn;
    public GameObject BatteryOff;
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

    public void Interacted(ref int battery, PlayerController pr)
    {
        switch (switchType)
        {
            case SwitchType.Lamp:
                if (battery >= Power && Power > 0)
                {
                    battery -= Power;
                    Power = 0;
                    LampLight();
                    Debug.Log("Powered Up The Lamp");

                    pr.UpdateBatteryStatus();
                }
                else
                {
                    Debug.Log("Not Enough Battery to Power Up Lamp");
                }
                break;
            case SwitchType.Door:
                if(battery >= Power && Power > 0)
                {
                    battery -= Power;
                    Power = 0;
                    SwitchPowerOn.SetActive(true);
                    SwitchPowerOff.SetActive(false);
                    HandleDoor();
                    Debug.Log("Powered Up The Gate");

                    pr.UpdateBatteryStatus();
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
                    SwitchPowerOn.SetActive(true);
                    SwitchPowerOff.SetActive(false);
                    HandleLift();
                    Debug.Log("Powered Up The Lift");

                    pr.UpdateBatteryStatus();
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

                    if (battery > 5)
                    {
                        battery = 5;
                    }

                    Power = 0;
                    BatteryOff.GetComponent<SpriteRenderer>().DOFade(1, 1);
                    BatteryOn.GetComponent<SpriteRenderer>().DOFade(0, 1).OnComplete(() =>
                    {
                        BatteryOn.SetActive(false);
                    });
                    HandlePowerBank();
                    Debug.Log("Power Bank to Charged Up the Battery to : " + battery);

                    pr.UpdateBatteryStatus();
                }
                else
                {
                    Debug.Log("Not Enough Power Bank Battery to Charge up the Battery");
                }
                break;
            case SwitchType.FireFlies:
                if (Power > 0)
                {
                    battery += Power;

                    if(battery > 5)
                    {
                        battery = 5;
                    }

                    Power = 0;

                    int childCount = transform.childCount;
                    for (int i = 0; i < childCount; i++)
                    {
                        Transform firstLevelChild = transform.GetChild(i);
                        int secondLevelCount = firstLevelChild.childCount;
                        for (int j = 0; j < secondLevelCount; j++)
                        {
                            firstLevelChild.GetChild(j).gameObject.SetActive(false);
                        }
                    }

                    pr.UpdateBatteryStatus();

                    Debug.Log("Fireflies Charged Up the Battery to : " + battery);
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

    private void LampLight()
    {
        Debug.Log("Lamp interaction handled.");
        LampOn.SetActive(true);
    }
    private void HandleDoor()
    {
        Debug.Log("Door interaction handled.");
        Gate.DOLocalMove(GateOpen, 0.5f);
    }

    private void HandleLift()
    {
        Debug.Log("Lift interaction handled.");
        Lift.DOLocalMoveY(LiftUp, 2f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

    private void HandlePowerBank()
    {
        Debug.Log("PowerBank interaction handled.");
    }
}
