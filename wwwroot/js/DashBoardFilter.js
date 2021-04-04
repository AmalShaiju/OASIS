// Amal Shaiju 2021-04-03

function FilterDashBoard(e) {

    console.log("FilterDashBoard")

    var type = e.id.split("-")[0];
    var id = e.id.split("-")[1];

    var approvalID = null;
    var bidStatusID = null
    var projectID = null;

    if (type == "approvalStatus") {
        var approvalID = id;
    }
    else if (type == "bidStatus") {
        var bidStatusID = id
    }
    else {
        var projectID = id
    }


    if (id != null && type != null) {
        $.ajax({
            type: "GET",
            url: "Home/DashFilter",
            data: {
                'ApprovalStatus': approvalID,
                'BidStatusID': bidStatusID,
                'ProjectID': projectID,
                'userName': $('#userName').html()

            },
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response != null) {
                    console.log(response.objects)

                    if (response.success) {

                        $(`${e.id}`).addClass()

                        var tbodyToAdd;

                        for (var i = 0; i < response.objects.length; i++) {
                            tbodyToAdd += `<tr style="background:#343a40">
                                <th scope="row">${response.objects[i].dateCreated.split("T")[0]}</th>
                                <td>$${response.objects[i].estAmount.toFixed(2)}</td>
                                <td>
                                    <a href="${getBaseUrl()}Bids/Edit/${response.objects[i].id}" style="height:28px; width:24%" class="btn btn-outline-primary p-0 mr-3">
                                        <span class="material-icons">
                                            edit
                                                                </span>
                                    </a>
                                    <ahref="${getBaseUrl()}Bids/Details/${response.objects[i].id}" style="height:28px; width:24%" class="btn btn-outline-info p-0">
                                        <span class="material-icons">
                                            info
                                                                </span>
                                    </a>
                                </td>
                            </tr>`
                        }

                        var theadToAdd = ` <tr>
                                <th scope="col">Date Created</th>
                                <th scope="col">Estimate</th>
                                <th scope="col"></th>
                            </tr>`

                        $('#dashboard-thead').empty();
                        $('#dashboard-thead').append(theadToAdd);

                        $('#dashboard-tbody').empty();
                        $('#dashboard-tbody').append(tbodyToAdd);




                        showStatusMsg(response.success, response.msg, 500);
                    }
                    else {
                        showStatusMsg(response.success, response.msg, 2000);
                    }
                }
                else {
                    showStatusMsg(false, "Something went wrong", 3000);
                }
            },
            failure: function (response) {
                showStatusMsg(false, "Something went wrong", 3000);
            },
            error: function (response) {
                showStatusMsg(false, "Something went wrong", 3000);
            }
        });
    }
}