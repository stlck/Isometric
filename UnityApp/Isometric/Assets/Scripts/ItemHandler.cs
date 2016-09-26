using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemHandler : MonoBehaviour {

    public List<BaseItem> Items = new List<BaseItem>();
    public BaseItem InstantiatedItem;
    public Transform ShootPoint;
    
    // Use this for initialization
	void Start () {
        //Items.ForEach((i) => InstantiatedItems.Add(i.Setup(this)));
        SetNewItem(Items[0]);
        //InstantiatedItem = Instantiate(Items[0].Setup(this));

    }
	
	// Update is called once per frame
    void Update()
    {
        //foreach (var i in InstantiatedItems)
            if (InstantiatedItem.CurrentCooldown > 0)
                InstantiatedItem.CurrentCooldown -= Time.deltaTime;
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
        Debug.LogError("SWAP NOT MADE YET");
        if (InstantiatedItem != null)
            Destroy(InstantiatedItem);

        InstantiatedItem = Instantiate(i.Setup(this));
        InstantiatedItem.transform.SetParent(ShootPoint);
        /*  if (InstantiatedItems.Count >= index)
          {
              Destroy(InstantiatedItems[index].gameObject);
              InstantiatedItems.RemoveAt(index);
          }

          InstantiatedItems = i.Setup(this);*/
    }
}
