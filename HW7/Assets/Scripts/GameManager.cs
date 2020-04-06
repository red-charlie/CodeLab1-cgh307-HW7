using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // create singleton status go!

    public bool power = false;
    public bool key = false;
    private void Awake()
    {
        //singleton stuff
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

       
    }
    public void powerOn()
    {
        power = true;
    }

    public void keyGet()
    {
        key = true;
    }
}
