using DbTableEditor.BlazorApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DbTableEditor.BlazorApp.Shared
{
    public abstract partial class EditTable<T> : ComponentBase
        where T : new()
    {
        protected EditTable(HttpClient http, SaveOnCloseService saveOnClose)
        {
            Http = http;
            SaveOnClose = saveOnClose;
        }

        [Parameter] public List<string> Columns { get; set; }
        [Parameter] public List<T> Items { get; set; }
        [Parameter] public RenderFragment Header { get; set; }
        [Parameter] public RenderFragment<T> ChildContent { get; set; }
        [Parameter] public Func<T, int> GetId { get; set; }
        [Parameter] public Action<T, int> SetId { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> AdditionalAttributes { get; set; }

        protected SaveOnCloseService SaveOnClose { get; }
        protected HttpClient Http { get; }

        protected override async Task OnInitializedAsync()
        {
            await PopulateData();
            SaveOnClose.PageClosing += async (ctx) => await SubmitChanges(ctx);
            await SaveOnClose.EnablePreventClosing();
        }

        protected abstract Task PopulateData();

        private void Create()
        {
            var item = new T();
            Items.Add(item);
            OnAdded(item);
            StateHasChanged();
        }

        protected abstract void OnAdded(T item);

        private async Task Remove(T item)
        {
            Items.Remove(item);
            OnRemoved(item);
            if (GetId(item) != 0)
            {
                await Http.DeleteAsync($"api/spaceships/{GetId(item)}")
                    .ConfigureAwait(false);
            }
        }

        protected abstract void OnRemoved(T item);

        private async Task SubmitChanges(EditContext ctx)
        {
            if (!ctx.IsModified())
            {
                return;
            }

            if (!CanSubmitChanges(ctx))
            {
                return;
            }

            var item = (T)ctx.Model;
            if (GetId(item) == 0)
            {
                var created = await Http.PostJsonAsync<T>("api/spaceships", item);
                SetId(item, GetId(created));
            }
            else
            {
                await Http.PutJsonAsync($"api/spaceships/{GetId(item)}", item);
            }

            ctx.MarkAsUnmodified();
            OnChangesSubmitted(ctx);
        }

        protected abstract void OnChangesSubmitted(EditContext ctx);
        protected abstract bool CanSubmitChanges(EditContext ctx);

        private void UpdateSelected(EditContext ctx)
        {
            SaveOnClose.EditContext = ctx;
        }
    }
}
