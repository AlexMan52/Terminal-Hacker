using UnityEngine;



public class Hacker : MonoBehaviour
{
    //Game config data
    string[] level1Passwords = { "axe", "knife", "sword", "spear" };
    string[] level2Passwords = { "elephant", "mouse", "cat", "dog", "porcupine" };
    string[] level3Passwords = { "pipeline", "rectification", "distillation", "drilling", "monoethanolamine" };


    int levelIndex;

    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;



    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu("Hello, meatbag!");

    }

    void ShowMainMenu(string greeting)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("");
        Terminal.WriteLine("If you want to try easy level press '1'");
        Terminal.WriteLine("If you want to try medium level press '2'");
        Terminal.WriteLine("If you want to try SUPERHARD level press '3'");
        Terminal.WriteLine("If you want to continue your miserable life press 'exit'");

    }
    void OnUserInput(string input)
    {
        if (input == "q") // we can always go direct to main menu
        {
            ShowMainMenu("Hello, again!");
        }
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("If on the web close the tab.");
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
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
        bool isValidLevelIndex = (input == "1" || input == "2" || input == "3");
        if (isValidLevelIndex)
        {
            levelIndex = int.Parse(input); // присваиваем levelIndex значение из ввода с переводом из string в int
            AskForPassword(levelIndex);
        }
        else
        {
            Terminal.WriteLine("I don't understand you");
        }
    }

    void AskForPassword(int levelIndex)
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("Press 'q' to go back");
        Terminal.WriteLine("");
        Terminal.WriteLine("Try to pass the code!");
        SetRandomPassword(levelIndex);
        Terminal.WriteLine("Enter your password. Hint: " + password.Anagram());
    }

    void SetRandomPassword(int levelIndex)
    {
        switch (levelIndex)
        {
            case 1:
                Terminal.WriteLine("Level 1 is about weapons");
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                Terminal.WriteLine("Level 2 is about animals");
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                Terminal.WriteLine("Level 3 is about oil and gas");
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Terminal.WriteLine("Invalid level number");
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
            AskForPassword(levelIndex);
            Terminal.WriteLine("WRONG! Password has been changed!");
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowRewardScreen();
        Terminal.WriteLine("Press 'q' to choose level again");
    }

    void ShowRewardScreen()
    {
        switch (levelIndex)
        {
            case 1:
                Terminal.WriteLine("WOW! Take that axe");
                Terminal.WriteLine(@" 
                 _,-,
                T_  |
                ||`-'
                ||
                ||
                ~~
                ");
                break;
            case 2:
                Terminal.WriteLine("WOW! You are the King now! Take your crown!");
                Terminal.WriteLine(@" 
                ,  ,() , ,
                |\/\/\/\/|
                |_o_<>_o_|
                ");
                break;
            case 3:
                Terminal.WriteLine("WOW! You are the Petroleum Engineer! Take your gloves!");
                Terminal.WriteLine(@" 
                  _           _  
                ,|||.       ,|||.
                |||||       |||||
                |||||/)   (\|||||
                \,,, /     \ ,,,/
                |___|       |___|
                ");
                break;
            default:
                Debug.LogError("Error");
                break;
        }
    }
}
