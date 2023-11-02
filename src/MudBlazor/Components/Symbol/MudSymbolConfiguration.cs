namespace MudBlazor;

public readonly struct MudSymbolConfiguration
{
    public bool Fill { get; }
    public int Weight { get; }
    public int Grade { get; }
    public int OpticalSize { get; }
    public MudSymbolLineStyle LineStyle { get; }

    public MudSymbolConfiguration(bool fill, int weight, int grade, int opticalSize, MudSymbolLineStyle lineStyle)
    {
        Fill = fill;
        Weight = weight;
        Grade = grade;
        OpticalSize = opticalSize;
        LineStyle = lineStyle;
    }

    /// <summary>
    /// Set values here to null to leave the real values unchanged.
    /// </summary>
    public MudSymbolConfiguration WithNewValues(bool? fill, int? weight = null,
        int? grade = null, int? opticalSize = null, MudSymbolLineStyle? lineStyle = null)
    {
        bool newFill = fill ?? Fill;
        int newWeight = weight ?? Weight;
        int newGrade = grade ?? Grade;
        int newOpticalSize = opticalSize ?? OpticalSize;
        MudSymbolLineStyle newLineStyle = lineStyle ?? LineStyle;

        return new MudSymbolConfiguration(newFill, newWeight, newGrade, newOpticalSize, newLineStyle);
    }
    
    public string GetFontVariationStyle() 
        => $"font-variation-settings: 'FILL' {(Fill ? 1 : 0)}, 'wght' {Weight}, 'GRAD' {Grade}, 'opsz' {OpticalSize}";
}