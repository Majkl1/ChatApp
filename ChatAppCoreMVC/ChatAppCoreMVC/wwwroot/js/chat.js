"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
document.getElementById("sendBtn").disabled = true;

connection.start().then(function() {
    document.getElementById("sendBtn").disabled = false;
}).catch(function(err) {
    return console.error(err.toString());
});

connection.on("ReceiveMessage", function(userFrom, userTo, message) {
    var msgText = userFrom + ": " + message;
    var li = document.createElement("li");
    li.textContent = msgText;
    document.getElementById("msgBox").appendChild(li);
});

function send() {
    var userTo = document.getElementById("userTo").textContent;
    var userFrom = document.getElementById("userFrom").textContent;
    var message = document.getElementById("msgText").value;
    connection.invoke("SendMessage", userFrom, userTo, message).catch(function(err) {
        return console.error(err.toString())
    });
}
