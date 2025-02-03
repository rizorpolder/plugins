var playDeckBridgeIAP = (function () {
    const _wrapper = window.parent.window;
    var _unityInstance = null;

    const handleReceiveMessage = (message) => {
        const playdeck = message?.data?.playdeck;

        if (!playdeck) return;

        console.log(playdeck);
        if (playdeck.method === "requestPayment") {
            console.log(playdeck.value);
            _unityInstance?.SendMessage("PlayDeckBridge", "RequestPaymentHandler", JSON.stringify(playdeck.value))
        } else if (playdeck.method === 'invoiceClosed') {
            console.log(playdeck.value);
            _unityInstance?.SendMessage("PlayDeckBridge", "InvoiceClosedHandler", playdeck.value)
        } else if (playdeck.method === "getPaymentInfo") {
            console.log(playdeck.value);
            _unityInstance?.SendMessage("PlayDeckBridge", "GetPaymentInfoHandler", JSON.stringify(playdeck.value))
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