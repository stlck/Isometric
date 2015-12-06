using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public ItemHandler ItemHandler;
    public bool HoveringUseAble = false;
    void Awake()
    {
        ItemHandler = GetComponent<ItemHandler>();
    }

    void Update()
    {
        if (!HoveringUseAble)
        for (int i = 0; i < 3; i++)
            if ((Input.GetKey((i + 1).ToString()) || Input.GetButton("Fire" + (i + 1))))
            {
                ItemHandler.UseItem(i);
            }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * 5);
    }

    void OnGUI()
    {
        int index = 1;
        foreach (var i in ItemHandler.InstantiatedItems)
        {
            GUILayout.Label(index++ + ") " + i.Name + " " + i.CurrentCooldown + "/" + i.CoolDown);
        }
    }
}
