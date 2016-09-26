using UnityEngine;
using System.Collections;

public class Grenade : Weapon {

    public AreaOfEffect Prefab;

    public override BaseItem Setup(ItemHandler owner)
    {
        return base.Setup(owner);
    }

    public override void Use(Vector3 target)
    {
        base.Use(target);

        var p = Instantiate(Prefab, transform.position, transform.rotation) as AreaOfEffect;
        p.Owner = this;
        p.forwardForce = Vector3.Distance(transform.position, target);
    }
}
