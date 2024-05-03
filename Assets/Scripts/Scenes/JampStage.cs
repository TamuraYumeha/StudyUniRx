using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JampStage : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void GoNormal()
    {
        SceneManager.LoadScene("InGame");
    }
    public void GoSpecial()
    {
        SceneManager.LoadScene("Special");
    }
}
