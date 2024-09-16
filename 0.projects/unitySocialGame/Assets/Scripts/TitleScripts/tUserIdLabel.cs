using System;
using UnityEngine;
using UnityEngine.UI;

public class tUserIdLabel : MonoBehaviour
{
    /*コンポーネント変数*/
    Text _userIdLabel;

    // Start is called before the first frame update
    void Start()
    {
        /*コンポーネントの取得*/
        _userIdLabel = GameObject.Find("userIdLabel").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        /*userIDの確認*/
        var temp = PlayerPrefs.GetString("userID", String.Empty);
        if (temp != string.Empty)
        {
            //IDがある場合
            _userIdLabel.text = $"ID:{temp}";

        }
        else
        {
            //IDが無い場合
            _userIdLabel.text = $"userID: none ID.";
        }
    }
}
