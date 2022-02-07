using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AXD_SceneManager : MonoBehaviour
{
    public void ReloadCurrentScene()
    {
        Debug.Log(("Nul"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
