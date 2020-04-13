using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace DbTableEditor.BlazorApp.Services.Saving
{
    public interface ISaveOnCloseService
    {
        Task EnablePreventClosing();
        Task EnableSaveOnClose();

        public EditContext EditContext { get; set; }
        public event Action<EditContext> PageClosing;
    }
}
