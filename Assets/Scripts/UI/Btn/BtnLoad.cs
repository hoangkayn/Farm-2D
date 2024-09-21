using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnLoad : BaseBtn
{
    protected override void OnClick()
    {
        GameManager.Instance.isNewGame = false;
        SceneManager.LoadScene("demo");
        
    }
  
}
