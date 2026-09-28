using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synorvia.UI.BlazorComponents.Ribbon
{
    public partial class RibbonPanel
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string PanelTitle { get; set; }
    }
}
