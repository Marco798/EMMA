using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace EMMA_FE.Classes.Common {
    public abstract class EditableFields<T> : ComponentBase {
        [Parameter]
        public T Value { get; set; }
        [Parameter]
        public bool Editing { get; set; } = false;

        [Parameter]
        public string TableName { get; set; } = string.Empty;
        [Parameter]
        public string FieldName { get; set; } = string.Empty;
        [Parameter]
        public long Id { get; set; }

        protected string EditButton = string.Empty;
        protected T originalValue;
        protected bool firstRenderAfterActiveEditing = false;
        protected ElementReference element;

        protected override async Task OnAfterRenderAsync(bool firstRender) {
            if (Editing && firstRenderAfterActiveEditing) {
                firstRenderAfterActiveEditing = false;
                await element.FocusAsync();
            }
        }

        protected void ActiveEditing() {
            Editing = true;
            originalValue = Value;
            firstRenderAfterActiveEditing = true;
        }

        protected void Cancel() {
            Value = originalValue;
            Editing = false;
            EditButton = string.Empty;
        }

        protected abstract Task Save();

        protected async Task OnKeyDown(KeyboardEventArgs e) {
            if (e.Key == "Escape") {
                Cancel();
            }
            if (e.Key == "Enter") {
                await Save();
            }
        }
    }
}
