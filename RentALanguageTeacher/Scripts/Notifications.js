
//AddNewUser using ajax
function AddNewUser(UserName, Password, Email){    

    $.ajax({
        type: "POST",
        url: "Default.aspx/Register",
        data: "{'UserName': '" + UserName + "', 'Password': '" + Password + "', 'Email': '" + Email + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            if (msg.d == 'Success') { } else {
                var n = noty({ text: msg.d });
            }

        },
        error: function (request, status, error) {
            var n = noty({ text: request.responseText, type: alert });
        },

    });
}

function NewUserValidationError() {

    var n = noty({ text: 'Please complete the required fields', type:'error' });
}

function Notification(Text, Type, TimeOut) {

    var n = noty({ text: Text, type: Type, timeout: TimeOut });

}

function StickyNotification(Text, Type) {

    var n = noty({ text: Text, type: Type });

}

function CallBackNotification(Text, Type, Callback) {

    var n = noty({
        text: Text, type: Type, callback: {
            afterClose: function () {Callback }
        } });

}