var playDeckBridgeSocial = (function () {
    const _wrapper = window.parent.window;
    var _unityInstance = null;

    const handleReceiveMessage = (message) => {
        const playdeck = message?.data?.playdeck;

        if (!playdeck) return;

        console.log(playdeck);
        if (playdeck.method === "getShareLink") {
            console.log(playdeck.value);
            _unityInstance?.SendMessage("PlayDeckBridge", "GetShareLinkHandler", playdeck.value);
        }

    }

    return {
        init: function (unityInstance) {
            _unityInstance = unityInstance;
            window.addEventListener("message", handleReceiveMessage);
        },

        setLoadingProgress: function (progressValue) {
            _wrapper.postMessage({playdeck: {method: "loading", value: progressValue}}, "*")
        }
    };
});