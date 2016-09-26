using UnityEngine;
using System.Collections;

public class LaserWeapon : Weapon {

    public Laser FixedP;

    public Laser instantiatedLaser;

    public override BaseItem Setup(ItemHandler owner)
    {
        LaserWeapon b = base.Setup(owner) as LaserWeapon;
        b.instantiatedLaser = Instantiate(FixedP, b.transform, false) as Laser;
        b.instantiatedLaser.transform.position = b.instantiatedLaser.transform.position + owner.transform.forward + Vector3.up * .5f;
        b.instantiatedLaser.Owner = this;
        //b.instantiatedFixedP.gameObject.SetActive(false);

        return b;
    }

    public override void Use(Vector3 target)
    {
        base.Use(target);
        instantiatedLaser.ShootMe();
    }

    void Update()
    {
        //if (CurrentCooldown <= 0)
        //    instantiatedFixedP.gameObject.SetActive(false);
    }
}
