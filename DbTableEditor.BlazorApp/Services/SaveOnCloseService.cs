using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace DbTableEditor.BlazorApp.Services
{
    public sealed class SaveOnCloseService : IDisposable
    {
        public EditContext EditContext { get; set; }
        public event Action PageClosing;

        private readonly IJSRuntime _jSRuntime;
        private readonly DotNetObjectReference<SaveOnCloseService> _objRef;

        public SaveOnCloseService(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
            _objRef = DotNetObjectReference.Create(this);
        }

        public async Task EnablePreventClosing()
        {
            await _jSRuntime.InvokeVoidAsync("preventClosing.bindToClose", _objRef);
        }

        public async Task EnableSaveOnClose()
        {
            await _jSRuntime.InvokeVoidAsync("saveOnClose.bindToClose", _objRef);
        }

        [JSInvokable]
        public void OnClose()
        {
            if (EditContext?.Validate() == true)
            {
                PageClosing?.Invoke();
            }
        }

        [JSInvokable]
        public bool ShouldPreventClosing() => EditContext?.IsModified() == true && EditContext.Validate();

        public void Dispose() => _objRef.Dispose();
    }
}
