using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene(1);
    }

    public void menu()
    {
        SceneManager.LoadScene(0);
    }
}
