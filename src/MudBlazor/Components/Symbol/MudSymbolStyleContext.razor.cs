#nullable enable
using Microsoft.AspNetCore.Components;

namespace MudBlazor;

public partial class MudSymbolStyleContext : MudSymbolComponentBase
{
    [Parameter, Category(CategoryTypes.Icon.Behavior)]
    public RenderFragment? ChildContent { get; set; }
}