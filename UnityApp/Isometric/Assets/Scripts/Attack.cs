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
        if (line == null)
            line = GetComponentInChildren<LineRenderer>();

        OnScreenGUI.ToDo.Add(sendOnGUI);
    }

    void Update()
    {
        if (!HoveringUseAble)
        for (int i = 0; i < 3; i++)
            if ((Input.GetKey((i + 1).ToString()) || Input.GetButton("Fire" + (i + 1))))
            {
                if(ItemHandler.UseItem(i, MyPlayer.MyRotate.LastTarget))
                    StartColor.a += .5f;
            }

        StartColor.a = Mathf.SmoothStep(StartColor.a, 0, Time.deltaTime *5f);

        if (line != null)
            line.SetColors(StartColor, EndColor);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * 5);
    }

    public void sendOnGUI()
    {
        int index = 1;
        foreach (var i in ItemHandler.InstantiatedItems)
        {
            GUILayout.Label(index++ + ") " + i.Name + " " + i.CurrentCooldown + "/" + i.CoolDown);
        }
    }
}
