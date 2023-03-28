using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UniRx;
using SimpleJSON;
using Unity.VisualScripting;

public class Conect_Api_User : MonoBehaviour
{
    public string apiUrl = "https://randomuser.me/api/?results=50&callback=randomuserdata.";
    public GameObject prefab_user;
    public Transform content;

    private void Start()
    {
        ObservableWWW.Get(apiUrl)
           .Subscribe(json =>
           {
               JSONNode data = JSON.Parse(json.Substring(0));
               foreach (JSONNode usernode in data["results"])
               {
                   User user_aux = new User(usernode);

                   GameObject userObject = Instantiate(prefab_user, content);
                   userObject.GetComponent<User>().firstName = user_aux.firstName;
                   userObject.GetComponent<User>().lastName = user_aux.lastName;
                   userObject.GetComponent<User>().email = user_aux.email;
                   userObject.GetComponent<User>().gender = user_aux.gender;
                   userObject.GetComponent<User>().age = user_aux.age;
                   userObject.GetComponent<User>().city = user_aux.city;
                   userObject.GetComponent<User>().photo_thumbnail = user_aux.photo_thumbnail;
                   userObject.GetComponent<User>().photo_medium = user_aux.photo_medium;
                   userObject.GetComponent<User>().photo_large = user_aux.photo_large;

               }
           },
           ex => Debug.LogException(ex));
    }
}

