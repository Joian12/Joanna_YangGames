using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using TMPro;

public class LoginUser : MonoBehaviour
{
    public DependencyStatus dependencyStatus;
    public TextMeshProUGUI email;
    public InputField password;
    public FirebaseAuth auth;
    public GameObject registerPage;
    public GameObject loginPage;
    public TextMeshProUGUI errorMessage;
    public bool loginComplete;

    private void Start() {
        loginComplete = false;
        CheckFirebaseInititalization();
        email.text = string.Empty;
        password.text = string.Empty; 
    }
  
    public void CheckFirebaseInititalization(){
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if(dependencyStatus == DependencyStatus.Available){
                auth = FirebaseAuth.DefaultInstance;
            }else{
                Debug.LogError(System.String.Format("Could not resolve all Firebase dependencies: {0}", dependencyStatus));
            }
        });
    }
    
    public void ClickLogin(){
        StartCoroutine("Login");
    }
    public IEnumerator Login(){   
        Debug.Log(email.text);
        Debug.Log(password.text);
        if(email.text.Length > 1 && password.text.Length > 1){
            var login = auth.SignInWithEmailAndPasswordAsync(email.text, password.text);
            Debug.Log(password.text);
            yield return new WaitUntil(predicate: () => login.IsCompleted);

            if(login.Exception != null){
                FirebaseException firebaseEx = login.Exception.GetBaseException() as FirebaseException;
                AuthError error = (AuthError)firebaseEx.ErrorCode;

                switch (error){
                    case AuthError.InvalidEmail:
                        errorMessage.text = "Invalid Email";
                        break;
                    case AuthError.MissingEmail:
                        errorMessage.text = "Missing Email";
                        break;
                    case AuthError.MissingPassword:
                        errorMessage.text = "Missing Password";
                        break;
                    case AuthError.UserMismatch:
                        errorMessage.text = "Mismatch Information";
                        break;
                }
            }

            auth.SignInWithEmailAndPasswordAsync(email.text, password.text).ContinueWith(task => {
            if (task.IsCanceled) {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted) {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            if(task.IsCompleted){
                Firebase.Auth.FirebaseUser newUser = task.Result;
                loginComplete = true;
            }
            });
        }else
            errorMessage.text = "Fill Up Everything";     
    }

    private void Update() {
        if(loginComplete)
            LoadScene();
    }

    public void GoToRegisterPage(){
        registerPage.SetActive(true);
        loginPage.SetActive(false);
    }

    public void LoadScene(){
        SceneManager.LoadScene(1);
    }
}
