#nullable enable
using System;
using Microsoft.AspNetCore.Components;

namespace MudBlazor;

public abstract class MudSymbolComponentBase : MudComponentBase
{
    public const bool DefaultFill = false;
    public const int DefaultWeight = 400;
    public const int DefaultGrade = 0;
    public const int DefaultOpticalSize = 24;
    public const MudSymbolLineStyle DefaultLineStyle = MudSymbolLineStyle.Outlined; 
    
    public const int MinimumWeight = 100;
    public const int MinimumGrade = -25;
    public const int MinimumOpticalSize = 20;
    
    public const int MaximumWeight = 700;
    public const int MaximumGrade = 200;
    public const int MaximumOpticalSize = 48;
    
    [CascadingParameter(Name = nameof(CascadingIconConfig))] 
    public MudSymbolComponentBase? CascadingIconConfig { get; set; }

    private bool? _fill;
    /// <summary>
    /// Fill gives you the ability to modify the default icon style. A single icon can render both
    /// unfilled and filled states. To convey a state transition, use the fill axis for animation or interaction.
    /// The values are 0 for default or 1 for completely filled. Along with the weight axis,
    /// the fill also impacts the look of the icon.
    /// </summary>
    [Parameter, Category(CategoryTypes.Icon.Behavior)]
    public bool Fill
    {
        get => _fill ?? DefaultFill;
        set => _fill = value;
    }

    private int? _weight;
    /// <summary>
    /// Weight defines the symbol's stroke weight, with a range of weights between thin (lower) and bold (higher).
    /// Weight can also affect the overall size of the symbol. Weight ranges from 100 to 700 inclusively.
    /// </summary>
    [Parameter, Category(CategoryTypes.Icon.Behavior)]
    public int Weight
    {
        get => _weight ?? DefaultWeight;
        set
        {
            ThrowIfLessThan(value, MinimumWeight, nameof(Weight));
            ThrowIfGreaterThan(value, MaximumWeight, nameof(Weight));
            _weight = value;
        }
    }

    private int? _grade;
    /// <summary>
    /// Weight and grade affect a symbol's thickness. Adjustments to grade are more granular than adjustments to weight
    /// and have a small impact on the size of the symbol. Grade is also available in some text fonts. You can match grade
    /// levels between text and symbols for a harmonious visual effect. For example, if the text font has a -25 grade value,
    /// the symbols can match it with a suitable value, say -25. You can use grade for different needs:
    /// Low emphasis (e.g. -25 grade): To reduce glare for a light symbol on a dark background, use a low grade.
    /// High emphasis (e.g. 200 grade): To highlight a symbol, increase the positive grade.
    /// Grade ranges from -25 to 200 inclusively.
    /// </summary>
    [Parameter, Category(CategoryTypes.Icon.Behavior)]
    public int Grade
    {
        get => _grade ?? DefaultGrade;
        set
        {
            ThrowIfLessThan(value, MinimumGrade, nameof(Grade));
            ThrowIfGreaterThan(value, MaximumGrade, nameof(Grade));
            _grade = value;
        }
    }

    private int? _opticalSize;
    /// <summary>
    /// For the image to look the same at different sizes, the stroke weight (thickness) changes as the icon size scales.
    /// Optical Size offers a way to automatically adjust the stroke weight when you increase or decrease the symbol size.
    /// Optical Size ranges from 20 to 48 inclusively.
    /// </summary>
    [Parameter, Category(CategoryTypes.Icon.Behavior)]
    public int OpticalSize
    {
        get => _opticalSize ?? DefaultOpticalSize;
        set
        {
            ThrowIfLessThan(value, MinimumOpticalSize, nameof(OpticalSize));
            ThrowIfGreaterThan(value, MaximumOpticalSize, nameof(OpticalSize));
            _opticalSize = value;
        }
    }

    /// <summary>
    /// Line Style denotes the style of the icon, <see cref="MudSymbolLineStyle.Outlined"/>,
    /// <see cref="MudSymbolLineStyle.Rounded"/>, or <see cref="MudSymbolLineStyle.Sharp"/>.
    /// </summary>
    [Parameter, Category(CategoryTypes.Icon.Behavior)] 
    public MudSymbolLineStyle? LineStyle { get; set; }

    /// <inheritdoc/>
    protected override void OnParametersSet()
    {
        MudSymbolConfiguration cascadingIconConfig = CascadingIconConfig?.LocalIconConfig ?? 
                                                 new MudSymbolConfiguration(DefaultFill, DefaultWeight, DefaultGrade, 
                                                     DefaultOpticalSize, DefaultLineStyle);
        
        // this makes the preferred order: inline -> cascading -> default
        LocalIconConfig = cascadingIconConfig.WithNewValues(_fill, _weight, _grade, _opticalSize);
    }

    private MudSymbolConfiguration LocalIconConfig { get; set; }

    protected string StyleRuleString => LocalIconConfig.GetFontVariationStyle();

    private static void ThrowIfGreaterThan(int actualValue, int upperBound, string paramName)
    {
        if (actualValue > upperBound)
            throw new ArgumentOutOfRangeException(paramName, actualValue,
                $@"{paramName} (value: {actualValue}) must not be greater than {upperBound}");
    }

    private static void ThrowIfLessThan(int actualValue, int lowerBound, string paramName)
    {
        if (actualValue < lowerBound)
            throw new ArgumentOutOfRangeException(paramName, actualValue,
                $@"{paramName} (value: {actualValue}) must not be less than {lowerBound}");
    }
}