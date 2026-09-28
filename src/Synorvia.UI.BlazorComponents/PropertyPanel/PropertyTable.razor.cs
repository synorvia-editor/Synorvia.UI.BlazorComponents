using Microsoft.AspNetCore.Components;

namespace Synorvia.UI.BlazorComponents.PropertyPanel
{
    public partial class PropertyTable
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; } = default!;
    }
}