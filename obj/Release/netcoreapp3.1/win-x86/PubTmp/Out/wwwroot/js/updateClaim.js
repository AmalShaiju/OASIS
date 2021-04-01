// Amal Shaiju 2021-03-30
function UpdateClaim(e) {
    var type = e.id.split("-")[0];
    if ($(`#${e.id} `).prop('checked'))
    {
        var value = "True"
        console.log("true")
    }
    else {
        var value = "False"
        console.log("false")

    }
    var role = e.id.split("-")[2];



    console.log(`#${e.id} `);

    if (type != null && value != null && role != null) {
        $.ajax({
            type: "GET",
            url: "/UserRoles/UpdateClaims",
            data: {
                'claimType': type,
                'claimValue': value,
                'roleName': role
            },
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response != null) {

                    if (response) {
                        alert("sucess")
                    }
                    else {
                        alert("Failed")
                    }


                } else {
                    alert("Something went wrong");
                }
            },
            failure: function (response) {
                alert("failed");
            },
            error: function (response) {
                alert(response);
                console.log(response);

            }
        });
    }
}

function UpdateUserClaim(e) {
    var type = e.id.split("-")[0];

    if ($(`#${e.id} `).prop('checked')) {
        var value = "True"
        console.log("true")
    }
    else {
        var value = "False"
        console.log("false")

    }

    var user = e.id.split("-")[2];



    console.log(`#${e.id} `);

    if (type != null && value != null && user != null) {
        $.ajax({
            type: "GET",
            url: "/UserRoles/UpdateUserClaims",
            data: {
                'claimType': type,
                'claimValue': value,
                'userName': user
            },
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response != null) {

                    if (response) {
                        alert("sucess")
                    }
                    else {
                        alert("Failed")
                    }


                } else {
                    alert("Something went wrong");
                }
            },
            failure: function (response) {
                alert("failed");
            },
            error: function (response) {
                alert(response);
                console.log(response);

            }
        });
    }
}
