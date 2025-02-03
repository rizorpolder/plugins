var playDeckBridgeCommon = (function() {
    const _wrapper = window.parent.window;
    var _unityInstance = null;

    const handleReceiveMessage = (message) => {
        const playdeck = message?.data?.playdeck;

        if (!playdeck) return;

        console.log(playdeck);

        if (playdeck.method === "getUserProfile") {
            _unityInstance?.SendMessage("PlayDeckBridge", "GetUserHandler", JSON.stringify(playdeck.value))
        }
        else if (playdeck.method === "getData") {
            let data = playdeck?.value?.data?.toString();
            console.log("playdeck data: " + data);
            if (!data) data = "";
            _unityInstance.SendMessage("PlayDeckBridge", "GetDataHandler", data);
        }
    }

    return {
        init: function(unityInstance){
            _unityInstance = unityInstance;
            window.addEventListener("message", handleReceiveMessage);
        },

        setLoadingProgress: function (progressValue) {
            _wrapper.postMessage({ playdeck: { method: "loading", value: progressValue } }, "*")
        }
    };
});