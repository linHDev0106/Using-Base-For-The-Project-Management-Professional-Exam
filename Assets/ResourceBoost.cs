using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBoost : MonoBehaviour
{
    // Singleton instance
    public static ResourceBoost Instance { get; private set; }

    // Variable to store the resource boost value
    public int people = 0;
    public int process = 0;
    public int business = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResetBoostValue()
    {
        people = 0;
        process = 0;
        business = 0;
    }
}