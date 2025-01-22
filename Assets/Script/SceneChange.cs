using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void changeSceneBtn()
    {
        switch (this.gameObject.name)
        {
            case "StartBtn":
                SceneManager.LoadScene("InGame");
                break;
            case "SettingBtn":
                Debug.Log("¼¼ÆÃ");
                break;
        }
    }
}
