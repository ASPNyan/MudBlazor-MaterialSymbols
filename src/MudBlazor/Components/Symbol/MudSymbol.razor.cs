#nullable enable
using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;

namespace MudBlazor;

public partial class MudSymbol : MudSymbolComponentBase
{
    protected string ClassName =>
        new CssBuilder("mud-symbol-base")
            .AddClass($"mud-symbol-{LineStyle}")
            .AddClass($"mud-{Color.ToString().ToLower()}-text")
            .AddClass($"mud-symbol-size-{Size.ToString().ToLower()}")
            .Build();
    
    /// <summary>
    /// The name of the Material symbol.
    /// </summary>
    [Parameter, EditorRequired, Category(CategoryTypes.Icon.Behavior)]
    public string? Symbol { get; set; }

    /// <summary>
    /// The size of the icon
    /// </summary>
    [Parameter, Category(CategoryTypes.Icon.Appearance)]
    public Size Size { get; set; } = Size.Small;

    /// <summary>
    /// The color of the icon, 
    /// </summary>
    [Parameter, Category(CategoryTypes.Icon.Appearance)]
    public Color Color { get; set; } = Color.Inherit;
}