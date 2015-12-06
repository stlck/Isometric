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
        health = startHealth;
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
        get { return strength; }
        set { strength = value; }
    }

    public int Perception
    {
        get { return perception; }
        set { perception = value; }
    }

    public int Fortitude
    {
        get { return fortitude; }
        set { fortitude = value; }
    }

    public int Willpower
    {
        get { return willpower; }
        set { willpower = value; }
    }
}

[System.Serializable]
public class FloatEvent : UnityEvent<float> { }
