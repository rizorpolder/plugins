mergeInto(LibraryManager.library, {
  PlayDeckBridge_PostMessage_RequestPayment: function(data) {
    const parent = window.parent.window;
    const jsonData = JSON.parse(UTF8ToString(data));
    console.log(jsonData);
    parent.postMessage(
      { playdeck: { method: "requestPayment", value: jsonData } },
      "*"
    );
  },
  
  PlayDeckBridge_PostMessage_GetPaymentInfo: function(data) {
    const parent = window.parent.window;
    const jsonData = JSON.parse(UTF8ToString(data));
    console.log(jsonData);
    parent.postMessage(
      { playdeck: { method: "getPaymentInfo", value: jsonData } },
      "*"
    );
  }
});
  