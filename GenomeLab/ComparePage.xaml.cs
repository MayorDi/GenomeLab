using GenomeAnalyzer;
using Microsoft.Maui.Animations;

namespace GenomeLab;

public partial class ComparePage : ContentPage
{
	public ComparePage()
	{
		InitializeComponent();
    }

    private async void Button_ClickedLoad_1Genome(object sender, EventArgs e)
    {
        FileResult fileResult = await LoadFile();
        if (fileResult != null)
        {
            byte[] file = File.ReadAllBytes(fileResult.FullPath);
            CompareGenomes.Project1 = new Project
            {
                Name = fileResult.FileName.Substring(0, fileResult.FileName.Length - 7),
                Genome = (new Parser(file.ToList())).Parsing()
            };

            UpdatePage();
        }
    }

    private async void Button_ClickedLoad_2Genome(object sender, EventArgs e)
    {
        FileResult fileResult = await LoadFile();
        if (fileResult != null)
        {
            byte[] file = File.ReadAllBytes(fileResult.FullPath);
            CompareGenomes.Project2 = new Project
            {
                Name = fileResult.FileName.Substring(0, fileResult.FileName.Length - 7),
                Genome = (new Parser(file.ToList())).Parsing()
            };

            UpdatePage();
        }
    }

    public void UpdatePage()
    {
        genome1.Text = CompareGenomes.Project1?.Name ?? "none";
        genome2.Text = CompareGenomes.Project2?.Name ?? "none";

        stackMode.Children.Clear();

        int i = 0;
        foreach (var gene in CompareGenomes.Project1.Genome)
        {
            stackMode.Children.Add(UiDraw.CreatePanelInfoOfGene(gene, CompareGenomes.Project2?.Genome?[i]));
            i++;
        }

    }

    private async Task<FileResult> LoadFile()
    {
        PickOptions pickOptions = new PickOptions
        {
            PickerTitle = "Select your genome"
        };

        var fileRes = await FilePicker.PickAsync(pickOptions);

        if (fileRes != null)
        {
            if (fileRes.FileName.EndsWith("genome"))
            {
                return fileRes;
            }

            await DisplayAlert("Is not genome", "Select the file with the extension \".genome\"", "ok");
        }

        return null;
    }
}