using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class More_user : MonoBehaviour
{
    [Header("More_data")]
    public Image User_photo;
    public TextMeshProUGUI user_email;
    public TextMeshProUGUI User_name;
    public TextMeshProUGUI user_gender;
    public TextMeshProUGUI user_age;
    public TextMeshProUGUI user_city;

    public void View_info(User user)
    {
        StartCoroutine(image(user.photo_medium));
        user_email.text = "Email: " + user.email;
        User_name.text = "Name: " + user.firstName + " " + user.lastName;
        user_gender.text = "Genero: " + user.gender;
        user_age.text = "Edad: " + user.age;
        user_city.text = "Ciudad: " + user.city;
    }
    IEnumerator image(string aux)
    {
        WWW www = new WWW(aux);
        yield return www;

        Texture2D texture = www.texture;
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

        User_photo.sprite = sprite;
    }
}
