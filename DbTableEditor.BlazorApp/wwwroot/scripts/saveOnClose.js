var SaveOnClose = /** @class */ (function () {
    function SaveOnClose() {
    }
    SaveOnClose.prototype.bindToClose = function (obj) {
        window.addEventListener("beforeunload", function (_) {
            obj.invokeMethod("OnClose");
        });
    };
    SaveOnClose.prototype.unbind = function (obj) {
        // window.removeEventListener("beforeunload", ?)
    };
    return SaveOnClose;
}());
var PreventClosing = /** @class */ (function () {
    function PreventClosing() {
    }
    PreventClosing.prototype.bindToClose = function (obj) {
        window.addEventListener("beforeunload", function (event) {
            if (obj.invokeMethod("ShouldPreventClosing")) {
                event.preventDefault();
                event.returnValue = "";
            }
        });
    };
    PreventClosing.prototype.unbind = function () {
        // window.removeEventListener("beforeunload", ?)
    };
    return PreventClosing;
}());
window["saveOnClose"] = new SaveOnClose();
window["preventClosing"] = new PreventClosing();
//# sourceMappingURL=saveOnClose.js.map