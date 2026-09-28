using Synorvia.UI.BlazorComponents.Services;
using Synorvia.UI.DataModels.DragDrop;
using Synorvia.UI.DataModels.Tree;
using Microsoft.AspNetCore.Components;
          
namespace Synorvia.UI.BlazorComponents.Tree
{
    public partial class MvvmTreeNode<TNode>
    {
        [Inject]
        public DragDropDataProvider DragDropDataProvider { get; set; }

        [Parameter]
        public ITreeNode DataContext { get; set; }

        [Parameter]
        public RenderFragment<TNode> TitleTemplate { get; set; }

        [Parameter]
        public RenderFragment<TNode> LoadingTemplate { get; set; }

        [Parameter]
        public TreeStyle Style { get; set; } = TreeStyle.Bootstrap;


        [Parameter]
        public EventCallback<ITreeNode> TreeNodeChanged { get; set; }

        [Parameter]
        public bool ShowTreeIcons { get; set; } = true;

        // Lets the caller supply type-symbol logic without MvvmTreeNode depending on app-specific types.
        [Parameter]
        public Func<ITreeNode, string>? TypeSymbolSelector { get; set; }

        protected override void OnInitialized()
        {
            DataContext.TreeStateChanged += OnTreeStateChanged;
        }

        private void OnTreeStateChanged(object? sender, EventArgs e)
        {
            if(TreeNodeChanged.HasDelegate)
            {
                InvokeAsync(() =>
                {
                    TreeNodeChanged.InvokeAsync();
                });
            }
        }

        private async Task OnToggleNode(ITreeNode node, bool expand)
        {
            var expanded = node.IsExpanded;
            // colapse
            if (expanded && !expand)
            {
                node.IsExpanded =  false;
            }
            // expand
            else if (!expanded && expand)
            {
                node.IsExpanded = true;
            }
            StateHasChanged();
        }

        private void OnSelectNode(ITreeNode node)
        {
            if(node !=null && node.Tree != null)
            {
                if(node.Tree.SelectedNode != node)
                {
                    node.Tree.SelectedNode = node;
                    StateHasChanged();
                    if (TreeNodeChanged.HasDelegate)
                    {
                        TreeNodeChanged.InvokeAsync();
                    }
                }
            }
        }

        private void OnDragNodeStart()
        {
            if(!DataContext.IsLoading)
            {
                DragDropDataProvider.SetData(new DragDropInformation
                {
                    Data = DataContext,
                    OperationInformation = DataContext.DragDropOperationInformation
                });
            }
        }


        private string GetTypeSymbol()
        {
            return TypeSymbolSelector?.Invoke(DataContext) ?? "";
        }
    }
}