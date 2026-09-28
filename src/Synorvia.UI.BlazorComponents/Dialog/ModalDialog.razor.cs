using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Synorvia.UI.BlazorComponents.Dialog
{
    public partial class ModalDialog
    {
        [Inject]
        private IStringLocalizer<ModalDialog> L { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventCallback<bool> OnClose { get; set; }

        // For dialogs with a third answer. OnClose stays as it is, so nothing that uses the
        // two-answer shapes has to change.
        [Parameter]
        public EventCallback<ModalDialogResult> OnResult { get; set; }

        [Parameter]
        public ModalDialogType DialogType { get; set; } = ModalDialogType.Ok;

        // Wording of the confirming button. Empty keeps the dialog type's own label.
        [Parameter]
        public string ConfirmText { get; set; } = "";

        // Wording of the discarding button, same rule.
        [Parameter]
        public string DiscardText { get; set; } = "";

        [Parameter]
        public bool CanConfirm 
        { 
            get;
            
            set; 
        
        } = true;

        

        protected override void OnInitialized()
        {
            
        }

        private string ConfirmLabel(string defaultLabel)
        {
            string result = defaultLabel;

            if (!string.IsNullOrEmpty(ConfirmText))
            {
                result = ConfirmText;
            }

            return result;
        }

        private string DiscardLabel(string defaultLabel)
        {
            string result = defaultLabel;

            if (!string.IsNullOrEmpty(DiscardText))
            {
                result = DiscardText;
            }

            return result;
        }

        // The x in the corner and the cancel button mean the same thing: answer nothing.
        private Task ModalCancel()
        {
            return Answer(ModalDialogResult.Cancel, false);
        }

        private Task ModalOk()
        {
            return Answer(ModalDialogResult.Confirm, true);
        }

        private Task ModalDiscard()
        {
            return Answer(ModalDialogResult.Discard, false);
        }

        // Both callbacks are served, so a dialog can listen to whichever fits it.
        private Task Answer(ModalDialogResult result, bool confirmed)
        {
            if (OnResult.HasDelegate)
            {
                return OnResult.InvokeAsync(result);
            }

            return OnClose.InvokeAsync(confirmed);
        }

        public enum ModalDialogType
        {
            Ok,
            OkCancel,
            DeleteCancel,
            SaveDiscardCancel
        }

        public enum ModalDialogResult
        {
            Confirm,
            Discard,
            Cancel
        }
    }
}