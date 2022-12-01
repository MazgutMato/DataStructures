namespace FileApp;

using View;

public partial class FileApp : Form
{
    NavigationControls navigationControls;
    NavigationButtons navigationButtons;

    Color btnDefaultColor = Color.FromKnownColor(KnownColor.ControlLight);
    Color btnSelecedColor = Color.FromKnownColor(KnownColor.ControlDark);

    public FileApp()
    {
        InitializeComponent();
        InitializeNavigationControls();
        InitializeNavigationButtons();
    }

    private void InitializeNavigationControls()
    {
        List<UserControl> userControls = new List<UserControl>()
        { new Settings() };

        navigationControls = new NavigationControls(userControls, Panel);
        navigationControls.Display(0);
    }

    private void InitializeNavigationButtons()
    {
        List<Button> buttons = new List<Button>() { SettingsButton, PatientsButton, RecordsButton };

        navigationButtons = new NavigationButtons(buttons, btnDefaultColor, btnSelecedColor);
        navigationButtons.Highlight(SettingsButton);
    }

    private void FileApp_Load(object sender, EventArgs e)
    {

    }

    private void PatientsButton_Click(object sender, EventArgs e)
    {

    }

    private void RecordsButton_Click(object sender, EventArgs e)
    {

    }

    private void SettingsButton_Click(object sender, EventArgs e)
    {
        navigationButtons.Highlight(SettingsButton);
        navigationControls.Display(0);
    }
}
