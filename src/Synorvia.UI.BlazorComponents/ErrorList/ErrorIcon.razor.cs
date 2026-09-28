using Synorvia.UI.DataModels.ErrorList;
using Microsoft.AspNetCore.Components;

namespace Synorvia.UI.BlazorComponents.ErrorList
{
    public partial class ErrorIcon
    {
        [Parameter]
        public IErrorListElement DataContext { get; set; } = null!;
    }
}