using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BtnNew : BaseBtn
{
    protected override void OnClick()
    {
        GameManager.Instance.isNewGame = true;
        SceneManager.LoadScene("demo");
      
    }
   

}
