﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public void Repeat()
    {
        SceneManager.LoadScene(0);
    }
}
