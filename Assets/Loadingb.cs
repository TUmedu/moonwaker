using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadingb : MonoBehaviour {
    // Inspector上で次のシーン名を設定
    public string nextSceneName;
    int index;
   // Use this for initialization
   void Start () {
        index = Random.Range(0, SceneManager.sceneCountInBuildSettings);
    }
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "loading")
        {
            
            SceneManager.LoadScene(index);
            Debug.Log(index);
           // SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
            Resources.UnloadUnusedAssets();
            System.GC.Collect();
        }
    }
}
