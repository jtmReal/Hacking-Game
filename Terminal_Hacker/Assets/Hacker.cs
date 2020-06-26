using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game Config
    const string menuHint = "You may type menu at any time.";
    string[] level1Passwords = {"lunch", "principal", "student", "teacher", "lab" };
    string[] level2Passwords = { "game", "company", "builderman", "random", "banned" };
    string[] level3Passwords = { "jail", "space", "engineer", "secret", "first" };

    //Game State
    int level;
    enum Screen { MainMenu, Password, Win }
    Screen currentScreen;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("The following 3 areas have different levels of security.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for your school");
        Terminal.WriteLine("Press 2 for ROBLOX");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection");
        Terminal.WriteLine("");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if( currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    private void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        {
            if (isValidLevelNumber)
            {
                level = int.Parse(input);//Allows me to have as many levels as I want as long as I define the valid levels
                AskForPassword();
            }
            else
            {
                Terminal.WriteLine("Invalid Option");
                Terminal.WriteLine(menuHint);
            }
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("You're currently hacking into a system with level " + level + " security");
        Terminal.WriteLine("Enter Password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                int index1 = Random.Range(0, level1Passwords.Length);
                password = level1Passwords[index1];
                break;
            case 2:
                int index2 = Random.Range(0, level2Passwords.Length);
                password = level2Passwords[index2];
                break;
            case 3:
                int index3 = Random.Range(0, level3Passwords.Length);
                password = level3Passwords[index3];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("You've successfully gained access into your school's system");
                break;
            case 2:
                Terminal.WriteLine("You've successfully gained access into ROBLOX's system");
                break;
            case 3:
                Terminal.WriteLine("You've successfully gained access into NASA's System!! I wish you the best of luck, because the FBI is searching for you!!");
                break;
        }
    }
}
