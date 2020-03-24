using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace DbTableEditor.BlazorApp.Services
{
    public sealed class SaveOnCloseService : IDisposable
    {
        public EditContext EditContext { get; set; }
        public event Action<EditContext> PageClosing;

        private readonly IJSRuntime _jSRuntime;
        private readonly DotNetObjectReference<SaveOnCloseService> _objRef;

        private bool _preventClosingEnabled;
        private bool _saveOnCloseEnabled;

        public SaveOnCloseService(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
            _objRef = DotNetObjectReference.Create(this);
        }

        public async Task EnablePreventClosing()
        {
            if (!_preventClosingEnabled)
            {
                _preventClosingEnabled = true;
                await _jSRuntime.InvokeVoidAsync("preventClosing.bindToClose", _objRef);
            }
        }

        public async Task EnableSaveOnClose()
        {
            if (!_saveOnCloseEnabled)
            {
                _saveOnCloseEnabled = true;
                await _jSRuntime.InvokeVoidAsync("saveOnClose.bindToClose", _objRef);
            }
        }

        [JSInvokable]
        public void OnClose()
        {
            if (EditContext?.Validate() == true)
            {
                PageClosing?.Invoke(EditContext);
            }
        }

        [JSInvokable]
        public bool ShouldPreventClosing()
        {
            return true;
        }

        public void Dispose()
        {
            _objRef.Dispose();
        }
    }
}
