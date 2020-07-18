class Message {
    constructor(ApplicationUserId, Username, Text, DateTime) {
        this.ApplicationUserId = ApplicationUserId;
        this.Username = Username;
        this.Text = Text;
        this.DateTime = DateTime;
    }
}
const Text = $("#Text").val();
const ChatDiv = document.getElementById('ChatDiv');


$(function () {
    var chat = $.connection.chatHub;

    chat.client.addNewMessageToPage = function (ApplicationUserId, Username, Text, DateTime) {
        
        let IsCurrentUserMessage = (ApplicationUserId == ApplicationUserId) ? true : false;
        let Container = document.createElement('div');
        Container.className = IsCurrentUserMessage ? "right" : "left";
        let authorname = document.createElement('div');
        authorname.className = "author-name";
        let chatmessageactive = document.createElement('div');
        chatmessageactive.className = IsCurrentUserMessage ? "chat-message" : "chat-message active";
        chatmessageactive.innerHTML = Text;
        var currentDate = new Date();
        authorname.innerHTML = Username + "<small class='chat-date'> " + (currentDate.getMonth() + 1) + "/" +
            currentDate.getDate() + "/" +
            currentDate.getFullYear() + "  " +
            currentDate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', second: 'numeric' }); +"</small>"
        Container.appendChild(authorname);
        Container.appendChild(chatmessageactive);
        ChatDiv.appendChild(Container);
    };
    $('#Text').focus();
    // Start the connection.
    $.connection.hub.start().done(function () {
        $('#Text').keypress(function (event) {
            debugger;
            var keycode = (event.keyCode ? event.keyCode : event.which);
            if (keycode == '13') {
                SendChat();
            }
        });
        $('#ChatSubmit').click(function () {
            SendChat();
        });

        function SendChat() {
            const Text = $("#Text").val();
            let currentDate = new Date();
            if (Text.trim() != "") {
                var obj = { ApplicationUserId: ApplicationUserId, Username: Username, Text: Text };
                AjaxCall('/Administration/InternalChat/Create', JSON.stringify(obj), 'POST').done(function (response) {
                    if (response == "Ok") {
                        chat.server.send(ApplicationUserId, Username, Text, currentDate);
                        $('#Text').val('').focus();
                    }
                    else {
                        swal({
                            title: "Please try again?",
                            text: "",
                            type: "warning",
                            confirmButtonColor: "#DD6B55",
                            confirmButtonText: "Ok",
                            closeOnConfirm: true,
                        });
                    }
                }).fail(function (error) {
                    swal({
                        title: "Please try again?",
                        text: "",
                        type: "warning",
                        confirmButtonColor: "#DD6B55",
                        confirmButtonText: "Ok",
                        closeOnConfirm: true,
                    });
                });

            }

        }
    });
});
