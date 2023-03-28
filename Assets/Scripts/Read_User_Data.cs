using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UniRx;

public class Read_User_Data : MonoBehaviour
{
    [Header("General_data")]
    public Image User_photo;
    public TextMeshProUGUI User_name;
    public Toggle user_like;
    public Button B_More_data;
    [SerializeField] GameObject panel;

    void Start()
    {
        Transform parentTransform = GameObject.Find("Canvas").transform;
        Transform moreDataTransform = parentTransform.Find("More_Data");
        if (moreDataTransform != null)
        {
            panel = moreDataTransform.gameObject;
        }
        B_More_data.onClick.AddListener(open_More_info);
        User_name.text = GetComponent<User>().firstName + " " + GetComponent<User>().lastName;
        StartCoroutine(image());

    }
    IEnumerator image()
    {
        WWW www = new WWW(GetComponent<User>().photo_thumbnail);
        yield return www;

        Texture2D texture = www.texture;
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

        User_photo.sprite = sprite;
    }

    void open_More_info()
    {
        panel.SetActive(true);
        panel.GetComponent<More_user>().View_info(GetComponent<User>());
    }
}
