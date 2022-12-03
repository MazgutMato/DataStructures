namespace FileApp;

using View;

public partial class FileApp : Form
{
    NavigationControls navigationControls;
    NavigationButtons navigationButtons;
    PatientsController patientsController;

    Color btnDefaultColor = Color.FromKnownColor(KnownColor.ControlLight);
    Color btnSelecedColor = Color.FromKnownColor(KnownColor.ControlDark);

    public FileApp()
    {
        InitializeComponent();
        InitializePatientsController();
        InitializeNavigationControls();
        InitializeNavigationButtons();        
    }

    private void InitializePatientsController()
    {
        patientsController = new PatientsController();
    }

    private void InitializeNavigationControls()
    {
        List<UserControl> userControls = new List<UserControl>()
        { new Settings(patientsController), new Patients(patientsController), new Records() , new SearchPatient(patientsController)};

        navigationControls = new NavigationControls(userControls, Panel);
        navigationControls.Display(0);
    }

    private void InitializeNavigationButtons()
    {
        List<Button> buttons = new List<Button>() { SettingsButton, PatientsButton, RecordsButton, SearchButton };

        navigationButtons = new NavigationButtons(buttons, btnDefaultColor, btnSelecedColor);
        navigationButtons.Highlight(SettingsButton);
    }

    private void FileApp_Load(object sender, EventArgs e)
    {

    }

    private void PatientsButton_Click(object sender, EventArgs e)
    {
        navigationButtons.Highlight(PatientsButton);
        navigationControls.Display(1);
    }

    private void RecordsButton_Click(object sender, EventArgs e)
    {
        navigationButtons.Highlight(RecordsButton);
        navigationControls.Display(2);
    }

    private void SettingsButton_Click(object sender, EventArgs e)
    {
        navigationButtons.Highlight(SettingsButton);
        navigationControls.Display(0);
    }

    private void FileApp_FormClosing(object sender, FormClosingEventArgs e)
    {        
        patientsController.Save();
    }

    private void buttonSearch_Click(object sender, EventArgs e)
    {
        navigationButtons.Highlight(SearchButton);
        navigationControls.Display(3);
    }
}
