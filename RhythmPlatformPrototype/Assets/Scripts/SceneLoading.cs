using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    [SerializeField] GameObject buttons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (buttons.activeSelf)
            {
                buttons.SetActive(false);
            }
            else
            {
                buttons.SetActive(true);
            }
        }
    }

    public void LoadEndlessRunner()
    {
        buttons.SetActive(false);
        try
        {
            SceneManager.UnloadSceneAsync(2);
        }
        catch
        {
            Debug.Log("Cannot");
        }
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
    }

    public void LoadSongMapping()
    {
        buttons.SetActive(false);
        try
        {
            SceneManager.UnloadSceneAsync(1);
        }
        catch
        {
            Debug.Log("Cannot");
        }
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
        //try
        //{
        //}
        //catch()
        //{

        //}
    }
}
