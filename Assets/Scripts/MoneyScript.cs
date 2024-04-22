using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI moneyText;
    private BuildManager buildManager;
    // Start is called before the first frame update
    void Start()
    {
        buildManager = new BuildManager();
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "$" + buildManager.GetCurrentMoney();
    }
}
