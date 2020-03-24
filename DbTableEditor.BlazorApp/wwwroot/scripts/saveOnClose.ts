class SaveOnClose
{
    public bindToClose(obj: DotNet.DotNetObject): void
    {
        window.addEventListener("beforeunload", function (_)
        {
            obj.invokeMethod("OnClose")
        })
    }

    public unbind(obj: DotNet.DotNetObject): void
    {
        // window.removeEventListener("beforeunload", ?)
    }
}

class PreventClosing
{
    public bindToClose(obj: DotNet.DotNetObject): void
    {
        window.addEventListener("beforeunload", function (event)
        {
            if (obj.invokeMethod<boolean>("ShouldPreventClosing"))
            {
                event.preventDefault()
                event.returnValue = ""
            }
        })
    }

    public unbind(): void
    {
        // window.removeEventListener("beforeunload", ?)
    }
}

window["saveOnClose"] = new SaveOnClose()
window["preventClosing"] = new PreventClosing()
