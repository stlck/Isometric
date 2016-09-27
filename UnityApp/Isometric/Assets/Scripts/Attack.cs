using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Valve.VR;

public class Attack : MonoBehaviour
{
    public ItemHandler ItemHandler;
    public bool HoveringUseAble = false;

    LineRenderer line;
    public Color StartColor;
    public Color EndColor;

    public int attackDeviceId;

    void Awake()
    {
        ItemHandler = GetComponent<ItemHandler>();
        // if (line == null)
        //      line = GetComponentInChildren<LineRenderer>();

        if (OpenVR.IsHmdPresent())
        {
            attackDeviceId = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost);
                //if (ItemHandler.UseItem(MyPlayer.MyRotate.LastTarget))
                //    StartColor.a += .5f;
        }

        OnScreenGUI.ToDo.Add(sendOnGUI);
    }

    void Update()
    {
        if (!HoveringUseAble)
        {
            if (Input.GetButton("Fire" + (1)))
                ItemHandler.UseItem(MyPlayer.MyRotate.LastTarget);

            if (OpenVR.IsHmdPresent())
            {
                if (SteamVR_Controller.Input(attackDeviceId).GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
                    if (ItemHandler.UseItem( MyPlayer.MyRotate.LastTarget))
                        StartColor.a += .5f;
            }
            /*if (SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost)).GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
                if (ItemHandler.UseItem(0, MyPlayer.MyRotate.LastTarget))
                    StartColor.a += .5f;*/
        }
        //  StartColor.a = Mathf.SmoothStep(StartColor.a, 0, Time.deltaTime *5f);

        // if (line != null)
        //     line.SetColors(StartColor, EndColor);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * 5);
    }

    public void sendOnGUI()
    {
        int index = 1;
        //foreach (var i in ItemHandler.InstantiatedItem)
        {
            GUILayout.Label(index++ + ") " + ItemHandler.InstantiatedItem.Name + " " + ItemHandler.InstantiatedItem.CurrentCooldown + "/" + ItemHandler.InstantiatedItem.CoolDown);
        }
    }
}
