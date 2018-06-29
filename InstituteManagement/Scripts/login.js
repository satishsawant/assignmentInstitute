function Login()
{
    var data = { "Username": $("#login-username").val(), "Password": $("#login-password").val() }
    $.ajax({
        url: "http://localhost:50076/api/Login/Loginresult",
        type: "POST",
        data: JSON.stringify(data),
        dataType: "json",
        contentType: "application/json",
        success: function (login) {
            var success = login.success;
            if (success)
            {
                var roleId = login.RoleId;
                var teacherdtls = [];
                var studentdtls = [];
                var staffdtls = [];
                if (roleId == 2) { studentdtls = data.studentData; }
                else if (roleId == 3) { teacherdtls = data.departments; }
                else if (roleId == 4) { }
                else if (roleId == 1) { }
                else
                {
                    alert(login.error);
                }
            }
            else { alert(login.error); }
        },
        error: function () {

        }
    })
}