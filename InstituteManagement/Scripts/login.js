function Login()
{
    var data = { "Username": $("#login-username").val(), "Password": $("#login-password").val() }
    $.ajax({
        url: "/api/Login/LoginResult",
        type: "POST",

        data: JSON.stringify(data),
        dataType: "json",
        contentType: "application/json",
        success: function (status) {
            alert(status);
        },
        error: function () {

        }
    })
}