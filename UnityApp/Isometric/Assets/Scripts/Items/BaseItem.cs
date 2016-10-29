using UnityEngine;
using System.Collections;


public class BaseItem : MonoBehaviour {
    /*
    [UnityEditor.MenuItem("ITEMS/CREATE")]
    public static void CreateItem()
    {
        var i = BaseItem.CreateInstance<BaseItem>();
        //var path = UnityEditor.EditorUtility.SaveFilePanel("item", Application.dataPath, "item", "prefab");
        UnityEditor.AssetDatabase.CreateAsset(i, "ASSETS/Prefabs/Items/item.prefab");
        UnityEditor.EditorUtility.SetDirty(i);
    }*/

    public AudioSource Audio;
    public float StartAudioAt = 0f;
    public float EndAudioAt = 0f;
    public string Name;
    public Texture2D Icon;
    public string Description;

    public float CoolDown = 1;
    [System.NonSerialized]
    public float CurrentCooldown = 0;
    public float Range;

    public ItemHandler Owner;
    public float UseCost = 1;

    public virtual void Use(Vector3 target)
    {
        CurrentCooldown = CoolDown;
        if (Audio != null)
        {
            if(EndAudioAt > 0)
            { 
            //Audio.time = StartAudioAt;
            Audio.SetScheduledEndTime(EndAudioAt);
            //Audio.SetScheduledStartTime(StartAudioAt);
            Audio.PlayScheduled(StartAudioAt);
            }
            else
            {
                Audio.time = StartAudioAt;
                Audio.Play();
            }
        }
    }
	
    public virtual BaseItem Setup(ItemHandler owner)
    {
        var weapon = Instantiate(this);
        weapon.transform.SetParent(owner.transform);
        weapon.transform.localEulerAngles = Vector3.zero;
        weapon.transform.localPosition = Vector3.zero;
        weapon.Owner = owner;
        return weapon;
    }

    public void Destroy()
    {

    }
}
