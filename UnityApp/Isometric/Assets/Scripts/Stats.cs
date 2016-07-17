using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

public class Stats : MonoBehaviour
{
    StatCanvas statCanvas;

    void Awake()
    {
        statCanvas = StatCanvas.GetInstance;
        statCanvas.transform.SetParent(transform, false);
    }

    void Start()
    {
        health = startHealth;
        OnScreenGUI.ToDo.Add(sendOnGUI);
    }

    public float startHealth;
    private float health;
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            statCanvas.HealthUpdate.Invoke(Health / startHealth);
        }
    }

    private int strength = 1;
    private int perception = 1;
    private int fortitude = 1;
    private int willpower = 1;

    public int Strength
    {
        get {
            if (strength > 0)
                return strength;
            return 1;
        }
        set { strength = value; }
    }

    public int Perception
    {
        get { 
            if(perception > 0)
                return perception;
            return 1;
        }
        set { perception = value; }
    }

    public int Fortitude
    {
        get {
            if (fortitude > 0)
                return fortitude;
            return 1;
        }
        set { fortitude = value; }
    }

    public int Willpower
    {
        get {
            if (willpower > 0)
                return willpower;
            return 1;
        }
        set { willpower = value; }
    }

    public void sendOnGUI()
    {
        GUILayout.Label("HEALTH: " + health + "/" + startHealth);
    }
}

[System.Serializable]
public class FloatEvent : UnityEvent<float> { }
