using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

[SerializeField]
public class User : MonoBehaviour
{
    public string firstName;
    public string lastName;
    public string email;
    public string gender;
    public string age;
    public string city;
    public string photo_thumbnail;
    public string photo_medium;
    public string photo_large;

    public User(JSONNode node)
    {
        firstName = node["name"]["first"].Value;
        lastName = node["name"]["last"].Value;
        email = node["email"].Value;
        gender = node["gender"].Value;
        age = node["dob"]["age"].Value;
        city = node["location"]["city"].Value;
        photo_large = node["picture"]["large"].Value;
        photo_medium = node["picture"]["medium"].Value;
        photo_thumbnail = node["picture"]["thumbnail"].Value;
    }
}
