using System;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using Firebase.Extensions;
using TMPro;

namespace rpg
{
    public class FirebaseInstance : MonoBehaviour
    {   
        public static FirebaseInstance instance;
        public DependencyStatus dependencyStatus;
        public FirebaseAuth auth;
        public FirebaseUser user;
        public DatabaseReference reference;
        public TextMeshProUGUI testText;

        void Awake(){     
            CheckFirebaseInititalization();
            
            instance = this;
        }

        public void CheckFirebaseInititalization(){
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>{
                dependencyStatus = task.Result;
                if(dependencyStatus == DependencyStatus.Available){
                    Initialize();
                }else{
                    Debug.LogError(System.String.Format("Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                }
            });
        }

        public void Initialize(){
            auth = FirebaseAuth.DefaultInstance;
            user = FirebaseAuth.DefaultInstance.CurrentUser;
            //reference = Firebase.Database.FirebaseDatabase.DefaultInstance.RootReference;
            reference = FirebaseDatabase.DefaultInstance.RootReference;
            PlayerStats();
            testText.text = user.DisplayName;
        }

        public void PlayerStats()
        {
            reference.Child("Players").Child(user.DisplayName).Child("Player Stat's").Child("Health").SetValueAsync(1);
        }

        public void SaveAllWeaponData(){
            GetAllGlovesData();
            GetAllSwordsData();
            GetAllRifleData();
        }

        public void SaveAllQuestData(){
            GetAllKillQuestData();
            GetAllRetrieveQuestData();
            GetAllTravelQuestData();
        }

        public void GetAllGlovesData(){   
            for (int i = 0; i < InventoryMain.Instance.allGloves.Count; i++){
                reference.Child("Players").Child(user.DisplayName).Child("Inventory").Child("Gloves").Child(InventoryMain.Instance.allGloves[i].meleeWeaponName);
                reference.Child("Players").Child(user.DisplayName).Child("Inventory").Child("Gloves").Child(InventoryMain.Instance.allGloves[i].meleeWeaponName).Child("AddedToInventory").SetValueAsync(InventoryMain.Instance.allGloves[i].addedToInventory);
                reference.Child("Players").Child(user.DisplayName).Child("Inventory").Child("Gloves").Child(InventoryMain.Instance.allGloves[i].meleeWeaponName).Child("AddedToChest").SetValueAsync(InventoryMain.Instance.allGloves[i].addedToChest);
            }
        }
        
        public void GetAllSwordsData(){
            for (int i = 0; i < InventoryMain.Instance.allSwords.Count; i++){
                reference.Child("Players").Child(user.DisplayName).Child("Inventory").Child("Swords").Child(InventoryMain.Instance.allSwords[i].meleeWeaponName);
                reference.Child("Players").Child(user.DisplayName).Child("Inventory").Child("Swords").Child(InventoryMain.Instance.allSwords[i].meleeWeaponName).Child("AddedToInventory").SetValueAsync(InventoryMain.Instance.allSwords[i].addedToInventory);
                reference.Child("Players").Child(user.DisplayName).Child("Inventory").Child("Swords").Child(InventoryMain.Instance.allSwords[i].meleeWeaponName).Child("AddedToChest").SetValueAsync(InventoryMain.Instance.allSwords[i].addedToChest);
            }
        }

        public void GetAllRifleData(){
            for (int i = 0; i < InventoryMain.Instance.allRange.Count; i++){
                reference.Child("Players").Child(user.DisplayName).Child("Inventory").Child("Range").Child(InventoryMain.Instance.allRange[i].rangeWeaponName);
                reference.Child("Players").Child(user.DisplayName).Child("Inventory").Child("Range").Child(InventoryMain.Instance.allRange[i].rangeWeaponName).Child("AddedToInventory").SetValueAsync(InventoryMain.Instance.allRange[i].addedToInventory);
                reference.Child("Players").Child(user.DisplayName).Child("Inventory").Child("Range").Child(InventoryMain.Instance.allRange[i].rangeWeaponName).Child("AddedToChest").SetValueAsync(InventoryMain.Instance.allRange[i].addedToChest);
                reference.Child("Players").Child(user.DisplayName).Child("Inventory").Child("Range").Child(InventoryMain.Instance.allRange[i].rangeWeaponName).Child("IsActive").SetValueAsync(InventoryMain.Instance.allRange[i].isActive);
            }
        }

        ////All Quest Data Save
        public void GetAllKillQuestData(){
            for (int i = 0; i < QuestManager.instance.allQuestKill.Count; i++){
                reference.Child("Players").Child(user.DisplayName).Child("Quest").Child("Quest Kill").Child(QuestManager.instance.allQuestKill[i].questName);
                reference.Child("Players").Child(user.DisplayName).Child("Quest").Child("Quest Kill").Child(QuestManager.instance.allQuestKill[i].questName).Child("Active").SetValueAsync(QuestManager.instance.allQuestKill[i].active);
                reference.Child("Players").Child(user.DisplayName).Child("Quest").Child("Quest Kill").Child(QuestManager.instance.allQuestKill[i].questName).Child("Main Active").SetValueAsync(QuestManager.instance.allQuestKill[i].mainActive);
                reference.Child("Players").Child(user.DisplayName).Child("Quest").Child("Quest Kill").Child(QuestManager.instance.allQuestKill[i].questName).Child("Already Added").SetValueAsync(QuestManager.instance.allQuestKill[i].alreadAdded);
                reference.Child("Players").Child(user.DisplayName).Child("Quest").Child("Quest Kill").Child(QuestManager.instance.allQuestKill[i].questName).Child("Finished").SetValueAsync(QuestManager.instance.allQuestKill[i].finished);
                reference.Child("Players").Child(user.DisplayName).Child("Quest").Child("Quest Kill").Child(QuestManager.instance.allQuestKill[i].questName).Child("Done").SetValueAsync(QuestManager.instance.allQuestKill[i].done);
                reference.Child("Players").Child(user.DisplayName).Child("Quest").Child("Quest Kill").Child(QuestManager.instance.allQuestKill[i].questName).Child("Kill Requirements").SetValueAsync(QuestManager.instance.allQuestKill[i].killRequirements);
            }
        }
        public void GetAllRetrieveQuestData(){
            for (int i = 0; i < QuestManager.instance.allQuestRetrieve.Count; i++){
                reference.Child("Players").Child(user.DisplayName).Child("Quest").Child("Quest Retrieve").Child(QuestManager.instance.allQuestRetrieve[i].questName);
                reference.Child("Players").Child(user.DisplayName).Child("Quest").Child("Quest Retrieve").Child(QuestManager.instance.allQuestRetrieve[i].questName).Child("Active").SetValueAsync(QuestManager.instance.allQuestRetrieve[i].active);
                reference.Child("Players").Child(user.DisplayName).Child("Quest").Child("Quest Retrieve").Child(QuestManager.instance.allQuestRetrieve[i].questName).Child("Main Active").SetValueAsync(QuestManager.instance.allQuestRetrieve[i].mainActive);
                reference.Child("Players").Child(user.DisplayName).Child("Quest").Child("Quest Retrieve").Child(QuestManager.instance.allQuestRetrieve[i].questName).Child("Already Added").SetValueAsync(QuestManager.instance.allQuestRetrieve[i].alreadAdded);
                reference.Child("Players").Child(user.DisplayName).Child("Quest").Child("Quest Retrieve").Child(QuestManager.instance.allQuestRetrieve[i].questName).Child("Finished").SetValueAsync(QuestManager.instance.allQuestRetrieve[i].finished);
            }
        }
        public void GetAllTravelQuestData(){
            for (int i = 0; i < QuestManager.instance.allQuestTravel.Count; i++){
                reference.Child("Players").Child(user.DisplayName).Child("Quest").Child("Quest Travel").Child(QuestManager.instance.allQuestTravel[i].questName);
                reference.Child("Players").Child(user.DisplayName).Child("Quest").Child("Quest Travel").Child(QuestManager.instance.allQuestTravel[i].questName).Child("Active").SetValueAsync(QuestManager.instance.allQuestTravel[i].active);
                reference.Child("Players").Child(user.DisplayName).Child("Quest").Child("Quest Travel").Child(QuestManager.instance.allQuestTravel[i].questName).Child("Main Active").SetValueAsync(QuestManager.instance.allQuestTravel[i].mainActive);
                reference.Child("Players").Child(user.DisplayName).Child("Quest").Child("Quest Travel").Child(QuestManager.instance.allQuestTravel[i].questName).Child("Already Added").SetValueAsync(QuestManager.instance.allQuestTravel[i].alreadAdded);
                reference.Child("Players").Child(user.DisplayName).Child("Quest").Child("Quest Travel").Child(QuestManager.instance.allQuestTravel[i].questName).Child("Finished").SetValueAsync(QuestManager.instance.allQuestTravel[i].finished);
            }

        }
    }
}

