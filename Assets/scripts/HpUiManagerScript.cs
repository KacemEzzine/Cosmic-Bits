using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HpUiManagerScript : MonoBehaviour
{
   
    public TextMeshProUGUI PlayerHP; 
    
    public BaseEnemyScript Enemy;


    public int A;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       
        PlayerHP.text = PlayerScript.Ref.HP.ToString();
        if (Enemy.EnemyHp >= 0) {
        A = (int)Enemy.EnemyHp;
        }else
        {
            A = 0;
        }



    }
}
