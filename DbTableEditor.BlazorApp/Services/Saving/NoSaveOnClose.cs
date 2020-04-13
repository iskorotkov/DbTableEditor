using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace DbTableEditor.BlazorApp.Services.Saving
{
    public class NoSaveOnClose : ISaveOnCloseService
    {
        public Task EnablePreventClosing()
        {
            return Task.CompletedTask;
        }

        public Task EnableSaveOnClose()
        {
            return Task.CompletedTask;
        }

        public EditContext EditContext { get; set; }
        public event Action<EditContext> PageClosing;
    }
}
