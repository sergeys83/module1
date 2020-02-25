
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : Menu
{
    public Button btnPlay;
    public Button btnOptions;
    public string mainmenu;
    public LevelMenu levelMenu;
    public OptionMenu optionMenu;

    // Start is called before the first frame update
    void Start()
    {
        btnPlay.onClick.AddListener(ShowLevelMenu);
        btnOptions.onClick.AddListener(ShowOptionMenu);
        BackButtonHandler(Hide);
    }

    private void ShowLevelMenu()
    {
        base.Hide();
        levelMenu.Show();

    }

    private void ShowOptionMenu()
    {
        base.Hide();
        optionMenu.Show();

    }

    public void LoadMainMenu()
    {
        Hide();
    }

    public override void Hide()
    {
       base.Hide();

        Application.Quit();

    }
  /*  public override void Show()
    {
        base.Show();
    }
    */
    // Update is called once per frame
    void Update()
    {
        
    }
}
