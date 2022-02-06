using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HpUiManagerScript : MonoBehaviour
{
   
    public TextMeshProUGUI PlayerHP; 
    public TextMeshProUGUI BossHP;
    public int A;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       
        PlayerHP.text = PlayerScript.Ref.HP.ToString();
        if (EnemyScript.Ref.EnemyHp >= 0) {
        A = (int)EnemyScript.Ref.EnemyHp;
        }else
        {
            A = 0;
        }
        BossHP.text = A.ToString();


    }
}
