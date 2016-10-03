using UnityEngine;
using System.Collections;

public class Useable : MonoBehaviour {

    public BaseItem FoundItem;
    public GameObject EnableOnHover;

    void Awake()
    {
        EnableOnHover.SetActive(false);
    }

    void OnMouseEnter()
    {
        MyPlayer.MyAttack.HoveringUseAble = true;
        if (EnableOnHover != null)
            EnableOnHover.SetActive(true);
    }

    void OnMouseExit()
    {
        MyPlayer.MyAttack.HoveringUseAble = false;
        if (EnableOnHover != null)
            EnableOnHover.SetActive(false);
    }

    void OnMouseDown()
    {
        if(Vector3.Distance( MyPlayer.MyTransform.position, transform.position) < 3)
        {
            if(UseableCanvas.Instance != null)
                UseableCanvas.Instance.Show(this);
        }
    }

    public void Use(int index)
    {
        MyPlayer.MyItemHandler.Items[index] = FoundItem;
        MyPlayer.MyItemHandler.SetNewItem(MyPlayer.MyItemHandler.Items[index]);
    }
}
