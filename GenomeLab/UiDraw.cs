using GenomeAnalyzer;

namespace GenomeLab;

public class UiDraw
{
    public static Frame CreatePanelInfoOfGene(Gene gene, Gene newGene = null)
    {
        Frame panel = new()
        {
            Padding = new(0.0),
            CornerRadius = 24.0f,
            BorderColor = Color.FromRgba(0, 0, 0, 0)
        };

        StackLayout box = new()
        {
            Background = new SolidColorBrush(Color.FromArgb("#3A3A3A")),
            Orientation = StackOrientation.Vertical,
            Padding = new Thickness(10)
        };

        StackLayout header = new()
        {
            Orientation = StackOrientation.Horizontal,
            VerticalOptions = LayoutOptions.Center
        };

        Frame circle = new()
        {
            CornerRadius = 100.0f,
            Background = new SolidColorBrush(Color.FromRgb(gene.Color.R, gene.Color.G, gene.Color.B)),
            BorderColor = Color.FromArgb("#00000000"),
            WidthRequest = 30.0,
            HeightRequest = 30.0
        };

        Label titleMode = new()
        {
            Text = $"M{gene.Id + 1}",
            Margin = new Thickness(5, 0, 0, 0),
            TextColor = Color.FromArgb("#ACACAC"),
            FontFamily = "NunitoMedium",
            FontSize = 32,
            FontAttributes = FontAttributes.Bold
        };

        BoxView separator = new()
        {
            Color = Color.FromArgb("#6E6E6E"),
            HeightRequest = 4,
            CornerRadius = 10,
            Margin = new Thickness(0, 5, 0, 10)
        };

        StackLayout content = new()
        {
            Orientation = StackOrientation.Vertical,
            Padding = new Thickness(0, 0, 0, 15)
        };

        #region Filds

        var props = gene.GetType().GetProperties();
        var newProps = newGene?.GetType()?.GetProperties();
        var propsUi = new List<StackLayout>();

        for (int i = 0; i < props.Length; i++)
        {
            System.Reflection.PropertyInfo prop = props[i];
            StackLayout views = new()
            {
                Spacing = 10,
                Orientation = StackOrientation.Horizontal,
            };

            if (prop.Name == "Id" || prop.Name == "Color" || prop.Name == "SpecificSettings") continue;

            var propName = new Label
            {
                Text = $"{prop.Name}: ",
                TextColor = Color.FromArgb("#ACACAC"),
                FontFamily = "NunitoMedium",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold
            };
            views.Children.Add(propName);

            var val = new Label
            {
                Text = $"{prop.GetValue(gene)}",
                TextColor = Color.FromArgb("#ACACAC"),
                FontFamily = "NunitoMedium",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold
            };
            views.Children.Add(val);

            if (prop.Name == "CellType")
                val.Text = ((CompareGenomes.TypeCell)prop.GetValue(gene)).ToString();

            if (prop.Name == "Child1Mode" || prop.Name == "Child2Mode")
                val.Text = ((int)prop.GetValue(gene) + 1).ToString();

            if (newProps != null)
                if (newProps[i].GetValue(newGene).GetHashCode() != prop.GetValue(gene).GetHashCode())
                {
                    propName.TextColor = Color.FromArgb("#5298CC");
                    val.TextColor = Color.FromArgb("#E75E5E");

                    var arrow = new Label
                    {
                        Text = "→",
                        TextColor = Color.FromArgb("#ACACAC"),
                        FontFamily = "NunitoMedium",
                        FontSize = 20,
                        FontAttributes = FontAttributes.Bold
                    };
                    views.Children.Add(arrow);

                    var newVal = new Label
                    {
                        Text = $"{newProps[i].GetValue(newGene)}",
                        TextColor = Color.FromArgb("#61CC52"),
                        FontFamily = "NunitoMedium",
                        FontSize = 20,
                        FontAttributes = FontAttributes.Bold
                    };
                    views.Children.Add(newVal);

                    if (newProps[i].Name == "CellType")
                        newVal.Text = ((CompareGenomes.TypeCell)newProps[i].GetValue(newGene)).ToString();

                    if (newProps[i].Name == "Child1Mode" || newProps[i].Name == "Child2Mode")
                        newVal.Text = ((int)newProps[i].GetValue(newGene) + 1).ToString();
                }

            propsUi.Add(views);
        }

        #endregion

        header.Children.Add(circle);
        header.Children.Add(titleMode);

        propsUi.ForEach(content.Children.Add);

        box.Children.Add(header);
        box.Children.Add(separator);
        box.Children.Add(content);

        panel.Content = box;

        return panel;
    }
}