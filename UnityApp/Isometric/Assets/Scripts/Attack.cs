using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public ItemHandler ItemHandler;
    public bool HoveringUseAble = false;

    LineRenderer line;
    public Color StartColor;
    public Color EndColor;

    void Awake()
    {
        ItemHandler = GetComponent<ItemHandler>();
       // if (line == null)
      //      line = GetComponentInChildren<LineRenderer>();

        OnScreenGUI.ToDo.Add(sendOnGUI);
    }

    void Update()
    {
        if (!HoveringUseAble)
        {
            for (int i = 0; i < 2; i++)
            {
                if (Input.GetKey((i + 1).ToString())) //|| SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost)).GetPress(SteamVR_Controller.ButtonMask.Trigger))
                {
                    //swap item
                    //if (ItemHandler.UseItem(i, MyPlayer.MyRotate.LastTarget))
                    //    StartColor.a += .5f;
                }
            }
            if (Input.GetButton("Fire" + (1)))
                ItemHandler.UseItem(MyPlayer.MyRotate.LastTarget);

            if (SteamVR.active)
            {
                /*if (SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost)).GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
                    if (ItemHandler.UseItem(0, MyPlayer.MyRotate.LastTarget))
                        StartColor.a += .5f;*/
                if (SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost)).GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
                    if (ItemHandler.UseItem( MyPlayer.MyRotate.LastTarget))
                        StartColor.a += .5f;
            }
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
