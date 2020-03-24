class SaveOnClose
{
    public bindToClose(obj: DotNet.DotNetObject): void
    {
        window.addEventListener("beforeunload", function (e)
        {
            obj.invokeMethodAsync("OnClose")
            console.log("save on close - bind")
        })
    }

    public unbind(obj: DotNet.DotNetObject): void
    {
        // window.removeEventListener("beforeunload", ?)
        console.log("save on close - unbind")
    }
}

class PreventClosing
{
    public bindToClose(): void
    {
        window.addEventListener("beforeunload", function (e)
        {
            const confirmationMessage = "";
            (e || window.event).returnValue = confirmationMessage
            return confirmationMessage
        })
        console.log("prevent closing - bind")
    }

    public unbind(): void
    {
        // window.removeEventListener("beforeunload", ?)
        console.log("prevent closing - unbind")
    }
}

window["saveOnClose"] = new SaveOnClose()
window["preventClosing"] = new PreventClosing()
