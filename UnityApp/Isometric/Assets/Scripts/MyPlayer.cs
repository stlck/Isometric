using UnityEngine;
using System.Collections;

public class MyPlayer : MonoBehaviour {

    static MyPlayer instance;
    public static MyPlayer Instance
    {
        get
        {
            return instance;
        }
    }

    public static Move MyMove;
    public static Stats MyStats;
    public static Attack MyAttack;
    public static Transform MyTransform;
    public static ItemHandler MyItemHandler;

    void Awake()
    {
        instance = this;

        MyMove = GetComponent<Move>();
        MyStats = GetComponent<Stats>();
        MyAttack = GetComponent<Attack>();
        MyItemHandler = GetComponent<ItemHandler>();
        MyTransform = transform;

        if (!PlayerPrefs.HasKey("Strength"))
        {
            PlayerPrefs.SetInt("Strength", 1);
            PlayerPrefs.SetInt("Perception", 1);
            PlayerPrefs.SetInt("Fortitude", 1);
            PlayerPrefs.SetInt("Willpower", 1);
        }

        MyStats.Strength = PlayerPrefs.GetInt("Strength");
        MyStats.Perception = PlayerPrefs.GetInt("Perception");
        MyStats.Fortitude = PlayerPrefs.GetInt("Fortitude");
        MyStats.Willpower = PlayerPrefs.GetInt("Willpower");
    }

}
