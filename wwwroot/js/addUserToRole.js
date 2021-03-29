// Amal Shaiju 2021-03-29

function addUserToRole(e) {

    console.log("add user to role begin");

    // roleName to add
    var roleToAssign = e.id.split("-")[1];

    //username to add
    var employeeUserName = $(`#EmployeeID-${roleToAssign}`).val();

    console.log(roleToAssign + "" + employeeUserName);


    // Controller should contain [From Body]
    // Data should be stringified

    if (employeeUserName != null && roleToAssign != null) {
        $.ajax({
            type: "GET",
            url: "/UserRoles/AddUserToRole",
            data: {
                'userName': employeeUserName,
                'roleName': roleToAssign
            },
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response) {


                    htmlToadd = ` <li id="${employeeUserName}-${roleToAssign}" class="col-11 row ml-5">
                            <div class="list-group-item col-11" >"${employeeUserName}" </div >
                                <button class="btn btn-outline-danger col-1 p-0 m-0" onclick="removeUserFromRole(this)" id="delete-${employeeUserName}-${roleToAssign}">
                                    <svg xmlns="http://www.w3.org/2000/svg" height="24" viewBox="0 0 24 24" width="24"><path d="M0 0h24v24H0z" fill="none" /><path d="M6 19c0 1.1.9 2 2 2h8c1.1 0 2-.9 2-2V7H6v12zM19 4h-3.5l-1-1h-5l-1 1H5v2h14V4z" /></svg>
                                </button>
                                        </li >`
                    console.log($(`#${roleToAssign}-list`).html());
                    $(`#${roleToAssign}-list`).append(htmlToadd);

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
};


function removeUserFromRole(e) {

    console.log("deleet user to role begin");

    // roleName to add
    var roleToRemove = e.id.split("-")[2];

    //username to add
    var employeeToRemove = e.id.split("-")[1];

    console.log(roleToRemove + "" + employeeToRemove);


    if (employeeToRemove != null && roleToRemove != null) {
        $.ajax({
            type: "GET",
            url: "/UserRoles/RemoveUserFromRole",
            data: {
                'userName': employeeToRemove,
                'roleName': roleToRemove
            },
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response != null) {
                    if (response) {
                        $(`#${employeeToRemove}-${roleToRemove}`).remove();
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
};