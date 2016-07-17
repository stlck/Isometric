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
    public static Rotate MyRotate;
    public static Transform MyTransform;
    public static ItemHandler MyItemHandler;

    void Awake()
    {
        instance = this;

        MyMove = GetComponent<Move>();
        MyStats = GetComponent<Stats>();
        MyAttack = GetComponent<Attack>();
        MyItemHandler = GetComponent<ItemHandler>();
        MyRotate = GetComponent<Rotate>();
        MyTransform = transform;

        PlayerPrefs.SetInt("Strength", 10);
        PlayerPrefs.SetInt("Perception", 10);
        PlayerPrefs.SetInt("Fortitude", 10);
        PlayerPrefs.SetInt("Willpower", 10);
        
        if (!PlayerPrefs.HasKey("Strength") || PlayerPrefs.GetInt("Strength") == 0)
        {
            PlayerPrefs.SetInt("Strength", 10);
            PlayerPrefs.SetInt("Perception", 10);
            PlayerPrefs.SetInt("Fortitude", 10);
            PlayerPrefs.SetInt("Willpower", 10);
        }

        MyStats.Strength = PlayerPrefs.GetInt("Strength");
        MyStats.Perception = PlayerPrefs.GetInt("Perception");
        MyStats.Fortitude = PlayerPrefs.GetInt("Fortitude");
        MyStats.Willpower = PlayerPrefs.GetInt("Willpower");

        MyStats.startHealth *= MyPlayer.MyStats.Fortitude;

        if (OnScreenGUI.ToDo != null)
            OnScreenGUI.ToDo.Add(sendOnGUI);
    }


    public void sendOnGUI()
    {
        GUILayout.Label("Strength: " + PlayerPrefs.GetInt("Strength"));
        GUILayout.Label("Perception: " + PlayerPrefs.GetInt("Perception"));
        GUILayout.Label("Fortitude: " + PlayerPrefs.GetInt("Fortitude"));
        GUILayout.Label("Willpower: " + PlayerPrefs.GetInt("Willpower"));
    }
}
