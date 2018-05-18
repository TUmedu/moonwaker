using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class change : MonoBehaviour
{

   
    public float changetime =60;

    void changeNext()
    {
        if (Time.timeSinceLevelLoad > changetime)
        {
            SceneManager.LoadScene("loading");
            Resources.UnloadUnusedAssets();
            System.GC.Collect();

           
           // SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
            // FadeManager.Instance.LoadScene("Scene1", 2.0f);
            //FadeManager.Instance.LoadScene(nextSceneName, changetime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        changeNext();
        
    }

}
