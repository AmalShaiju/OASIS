// Amal Shaiju 2021-03-26

$("#btn-login").click(function () {
    console.log('clicked');

    var UserAuthenticationVM = new Object();
    UserAuthenticationVM.Username = $('#txtUserName').val();
    UserAuthenticationVM.Password = $('#txtPassword').val();
    UserAuthenticationVM.RememberMe = false;
    UserAuthenticationVM.ReturnUrl = "http://localhost:63341/Employees"

    console.log(UserAuthenticationVM)

    if (UserAuthenticationVM != null) {
        $.ajax({
            type: "POST",
            url: "/UserRoles/Authorization",
            data: JSON.stringify(UserAuthenticationVM),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response != null) {
                    alert(response.responseText());
                } else {
                    alert("Something went wrong");
                }
            },
            failure: function (response) {
                alert("failed");
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    }
});  

