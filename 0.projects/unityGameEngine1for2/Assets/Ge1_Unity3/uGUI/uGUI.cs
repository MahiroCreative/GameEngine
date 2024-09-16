using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class uGUI : MonoBehaviour
{
    TextMeshProUGUI _buttonText;
    TextMeshProUGUI _Text;
    Image _Image;
    bool _flag;

    // Start is called before the first frame update
    void Start()
    {
        _Image = GameObject.Find("Canvas/Image").GetComponent<Image>();
        _Text = GameObject.Find("Canvas/Text").GetComponent<TextMeshProUGUI>();
        _buttonText = GameObject.Find("Canvas/Button/Text (TMP)").GetComponent <TextMeshProUGUI>();
        _flag = false;
    }

    public void OnClick()
    {
        if (_flag==false)
        {
            _Text.color = Color.red;
            _Text.text = "GameOver!";
            _Image.color = Color.red;
            _buttonText.text = "Change!";
            _flag = true;
        }
        else
        {
            _Text.color = Color.blue;
            _Text.text = "Push!";
            _Image.color = Color.blue;
            _buttonText.text = "push!";
            _flag = false;
        }
    }
}
