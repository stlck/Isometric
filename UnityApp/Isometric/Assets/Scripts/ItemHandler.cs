using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemHandler : MonoBehaviour {

    public List<BaseItem> Items = new List<BaseItem>();
    public BaseItem InstantiatedItem;
    public Transform ShootPoint;
    int currentItem = 0;
    // Use this for initialization
	void Start () {
        SetNewItem(Items[currentItem]);
    }
	
	// Update is called once per frame
    void Update()
    {
        if (InstantiatedItem.CurrentCooldown > 0)
            InstantiatedItem.CurrentCooldown -= Time.deltaTime;

        for (int i = 0; i < Items.Count; i++)
        {
            if (Input.GetKey((i + 1).ToString())) //|| SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost)).GetPress(SteamVR_Controller.ButtonMask.Trigger))
            {
                currentItem = i;
                SetNewItem(Items[currentItem]);
                //swap item
                //if (ItemHandler.UseItem(i, MyPlayer.MyRotate.LastTarget))
                //    StartColor.a += .5f;
            }
        }
        if(SteamVR_Controller.Input(MyPlayer.MyAttack.attackDeviceId).GetTouchUp( Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad))
        {
            currentItem++;
            if (currentItem >= Items.Count)
                currentItem = 0;
            SetNewItem(Items[currentItem]);
        }
    }

    public bool UseItem(Vector3 target)
    {
        if (InstantiatedItem.CurrentCooldown <= 0)
        {
            InstantiatedItem.Use(target);
            return true;
        }
        return false;
    }

   /* public bool UseItem(int i, Vector3 target)
    {
        if (InstantiatedItems.Count >= i && InstantiatedItems[i].CurrentCooldown <= 0)
        {
            InstantiatedItems[i].Use(target);
            return true;
        }
        return false;
    }*/

    public void SetNewItem(BaseItem i)
    {
        //Debug.LogError("SWAP NOT MADE YET");
        if (InstantiatedItem != null)
            Destroy(InstantiatedItem);

        InstantiatedItem = i.Setup(this);
        InstantiatedItem.transform.SetParent(ShootPoint);
        /*  if (InstantiatedItems.Count >= index)
          {
              Destroy(InstantiatedItems[index].gameObject);
              InstantiatedItems.RemoveAt(index);
          }

          InstantiatedItems = i.Setup(this);*/
    }
}
