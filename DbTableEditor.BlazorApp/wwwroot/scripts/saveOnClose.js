var SaveOnClose = /** @class */ (function () {
    function SaveOnClose() {
    }
    SaveOnClose.prototype.bindToClose = function (obj) {
        window.addEventListener("beforeunload", function (e) {
            obj.invokeMethodAsync("OnClose");
            console.log("save on close - bind");
        });
    };
    SaveOnClose.prototype.unbind = function (obj) {
        // window.removeEventListener("beforeunload", ?)
        console.log("save on close - unbind");
    };
    return SaveOnClose;
}());
var PreventClosing = /** @class */ (function () {
    function PreventClosing() {
    }
    PreventClosing.prototype.bindToClose = function () {
        window.addEventListener("beforeunload", function (e) {
            var confirmationMessage = "";
            (e || window.event).returnValue = confirmationMessage;
            return confirmationMessage;
        });
        console.log("prevent closing - bind");
    };
    PreventClosing.prototype.unbind = function () {
        // window.removeEventListener("beforeunload", ?)
        console.log("prevent closing - unbind");
    };
    return PreventClosing;
}());
window["saveOnClose"] = new SaveOnClose();
window["preventClosing"] = new PreventClosing();
//# sourceMappingURL=saveOnClose.js.map