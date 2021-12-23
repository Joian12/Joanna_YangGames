using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using TMPro;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    public FirebaseAuth auth;
    public LoginUser loginUser;
    public FirebaseUser user;
    public TextMeshProUGUI username;
    public TextMeshProUGUI email;
    public TextMeshProUGUI confirmEmail;
    public InputField password, confirmPassword;
    public TextMeshProUGUI errorMessage;
    public GameObject loginPage;
    public GameObject regsiterPage;

    private void Start() {

    }
    public void RegisterUser(){   
        auth = loginUser.auth;  
        StartCoroutine("CoroutinRegister");
    }

    public IEnumerator CoroutinRegister(){   
        if(username.text.Length > 1 && email.text.Length > 1 && email.text == confirmEmail.text && password.text.Length > 1 && password.text == confirmPassword.text){
            var register = auth.CreateUserWithEmailAndPasswordAsync(email.text, password.text);

            yield return new WaitUntil(predicate: () => register.IsCompleted);

            if(register.Exception != null){
                FirebaseException firebaseEx = register.Exception.GetBaseException() as FirebaseException;
                AuthError error = (AuthError)firebaseEx.ErrorCode;

                string message = "Registration Failed";
               
                switch (error){
                    case AuthError.MissingEmail:
                        message = "Missing Email";
                        break;
                    case AuthError.EmailAlreadyInUse:
                        message = "Email already in use";
                        break;
                    case AuthError.MissingPassword:
                        message = "Missing Password";
                        break;
                }

                errorMessage.text = message;
            }
            user = register.Result;

            if(user != null){
                UserProfile profile = new UserProfile{ DisplayName = username.text};
                        
                var profileTask = user.UpdateUserProfileAsync(profile);

                yield return new WaitUntil(predicate: () => profileTask.IsCompleted);
                errorMessage.text = "Registration Success";
            }else{
                Debug.Log("User is null");
            }

        }else{
            errorMessage.text = "Registration Failed\n Please Fill Up Everything";
        }
    }

    public void GoToLogInPage(){
        loginPage.SetActive(true);
        regsiterPage.SetActive(false);
    }
}
