using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synorvia.UI.BlazorComponents.Ribbon
{
    public partial class RibbonCategory
    {

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        private bool Collapsed { get; set; } = false;

        private void OnCollapseButtonClick()
        {
            Collapsed = !Collapsed;
        }
    }
}
