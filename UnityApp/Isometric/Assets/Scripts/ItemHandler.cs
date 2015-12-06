using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemHandler : MonoBehaviour {

    public List<BaseItem> Items = new List<BaseItem>();
    public List<BaseItem> InstantiatedItems = new List<BaseItem>();
    
    // Use this for initialization
	void Start () {
        Items.ForEach((i) => InstantiatedItems.Add(i.Setup(this)));
	}
	
	// Update is called once per frame
    void Update()
    {
        foreach (var i in InstantiatedItems)
            if (i.CurrentCooldown > 0)
                i.CurrentCooldown -= Time.deltaTime;
	}

    public void UseItem(int i)
    {
        if (InstantiatedItems.Count >= i && InstantiatedItems[i].CurrentCooldown <= 0)
        {
            InstantiatedItems[i].Use();
        }
    }

    public void SetNewItem(BaseItem i, int index)
    {
        if (InstantiatedItems.Count >= index)
        {
            Destroy(InstantiatedItems[index].gameObject);
            InstantiatedItems.RemoveAt(index);
        }

        InstantiatedItems.Insert(index, i.Setup(this));
    }
}
