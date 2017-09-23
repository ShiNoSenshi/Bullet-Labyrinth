﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneKeysController : MonoBehaviour
{

    private void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}