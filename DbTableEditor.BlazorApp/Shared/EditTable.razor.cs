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
        [Parameter] public RenderFragment<T> Row { get; set; }
        [Parameter] public Func<T, int> GetId { get; set; }
        [Parameter] public Action<T, int> SetId { get; set; }
        [Parameter] public EventCallback PopulateData { get; set; }
        [Parameter] public EventCallback<T> OnAdded { get; set; }
        [Parameter] public EventCallback<T> OnRemoved { get; set; }
        [Parameter] public EventCallback<EditContext> OnChangesSubmitted { get; set; }
        [Parameter] public Predicate<EditContext> CanSubmitChanges { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> AdditionalAttributes { get; set; }

        protected SaveOnCloseService SaveOnClose { get; }
        protected HttpClient Http { get; }

        protected override async Task OnInitializedAsync()
        {
            await PopulateData.InvokeAsync(null);
            SaveOnClose.PageClosing += async (ctx) => await SubmitChanges(ctx);
            await SaveOnClose.EnablePreventClosing();
        }

        private async Task Create()
        {
            var item = new T();
            Items.Add(item);
            await OnAdded.InvokeAsync(item);
            StateHasChanged();
        }

        private async Task Remove(T item)
        {
            Items.Remove(item);
            await OnRemoved.InvokeAsync(item);
            if (GetId(item) != 0)
            {
                await Http.DeleteAsync($"api/spaceships/{GetId(item)}")
                    .ConfigureAwait(false);
            }
        }

        private async Task SubmitChanges(EditContext ctx)
        {
            if (!ctx.IsModified())
            {
                return;
            }

            if (!CanSubmitChanges?.Invoke(ctx) ?? false)
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
            await OnChangesSubmitted.InvokeAsync(ctx);
        }

        private void UpdateSelected(EditContext ctx)
        {
            SaveOnClose.EditContext = ctx;
        }
    }
}
