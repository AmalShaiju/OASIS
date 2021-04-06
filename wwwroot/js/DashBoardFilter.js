// Amal Shaiju 2021-04-03

function FilterDashBoard(e) {

    var approvalID = null;
    var bidStatusID = null
    var projectID = null;
    var fromDate = null;
    var toDate = null;
    console.log("FilterDashBoard")

    var type = e.id.split("-")[0];
    var id = e.id.split("-")[1];

    console.log($('#date-FromDate').val())
    console.log($('#date-Todate').val())

    if ($('#date-FromDate').val() != null) {
        fromDate = $('#date-FromDate').val();
    }

    if ($('#date-Todate').val() != null) {
        toDate = $('#date-Todate').val();
    }



    if (type == "approvalStatus") {
        var approvalID = id;
    }
    else if (type == "bidStatus") {
        var bidStatusID = id
    }
    else {
        var projectID = id
    }



    if (id != null || type != null || fromDate != null || toDate != null) {
        $.ajax({
            type: "GET",
            url: "Home/DashFilter",
            data: {
                'ApprovalStatus': approvalID,
                'BidStatusID': bidStatusID,
                'ProjectID': projectID,
                'userName': $('#userName').html(),
                'FromDate': fromDate,
                'ToDate': toDate

            },
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response != null) {

                    if (response.success) {


                        var tbodyToAdd;

                        if (response.objects != null) {
                            console.log(response.objects);

                            for (var i = 0; i < response.objects.length; i++) {
                                tbodyToAdd += `<tr style="background:#343a40">
                                <th scope="row">${response.objects[i].dateCreated.split("T")[0]}</th>
                                <th scope="row">${response.objects[i].projectName}</th>
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
                        }


                        var theadToAdd = ` <tr>
                                <th scope="col">Date Created</th>
                                <th scope="col">Project</th>
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


function DateFilter(e) {

    var fromDate = null;
    var toDate = null;

    console.log($('#date-FromDate').val() == "")
    console.log($('#date-Todate').val() == "")

    if ($('#date-FromDate').val() != "") {
        fromDate = $('#date-FromDate').val();
    }

    if ($('#date-Todate').val() != "") {
        toDate = $('#date-Todate').val();
    }


    if (fromDate != null || toDate != null) {
        $.ajax({
            type: "GET",
            url: "Home/DateFilter",
            data: {
                'userName': $('#userName').html(),
                'FromDate': fromDate,
                'ToDate': toDate

            },
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                console.log(response)

                if (response != null) {
                    if (response.success) {

                        $('#toggle-bids').hide();

                        var tbodyToAdd;

                        if (response.bids != null) {
                            for (var i = 0; i < response.bids.length; i++) {
                                tbodyToAdd += `<tr style="background:#343a40">
                                <th scope="row">${response.bids[i].dateCreated.split("T")[0]}</th>
                                <th scope="row">${response.bids[i].projectName}</th>
                                <td>$${response.bids[i].estAmount.toFixed(2)}</td>
                                <td>
                                    <a href="${getBaseUrl()}Bids/Edit/${response.bids[i].id}" style="height:28px; width:24%" class="btn btn-outline-primary p-0 mr-3">
                                        <span class="material-icons">
                                            edit
                                                                </span>
                                    </a>
                                    <ahref="${getBaseUrl()}Bids/Details/${response.bids[i].id}" style="height:28px; width:24%" class="btn btn-outline-info p-0">
                                        <span class="material-icons">
                                            info
                                                                </span>
                                    </a>
                                </td>
                            </tr>`
                            }
                        }

                        // Clear List
                        $('#approval-list').empty();
                        $('#bidStatus-list').empty();
                        $('#startApproch-list').empty();
                        $('#EndApproch-list').empty();


                        if (response.approvalsCount != null) {
                            var listItemToAdd = ` <li class="list-group-item">
                                    <span style="float:left; cursor:pointer" id="approvalStatus-Approved" onclick="FilterDashBoard(this)">Approved</span>
                                    <span style="float:right" class="badge badge-pill badge-success">${response.approvalsCount}</span>
                                </li>`

                            $('#approval-list').append(listItemToAdd);

                        }

                        if (response.disapprovalsCount != null) {
                            var listItemToAdd = ` <li class="list-group-item">
                                    <span style="float:left; cursor:pointer" id="approvalStatus-Disapproved" onclick="FilterDashBoard(this)">DisApproved</span>
                                    <span style="float:right" class="badge badge-pill badge-danger">${response.disapprovalsCount}</span>
                                </li>`

                            $('#approval-list').append(listItemToAdd);

                        }

                        if (response.reqapprovalsCount != null) {
                            var listItemToAdd = ` <li class="list-group-item">
                                    <span style="float:left; cursor:pointer" id="approvalStatus-RequiresApproval" onclick="FilterDashBoard(this)">ReqApproval</span>
                                    <span style="float:right" class="badge badge-pill badge-warning">${response.reqapprovalsCount}</span>
                                </li>`

                            $('#approval-list').append(listItemToAdd);
                        }

                        if (response.endApprochBids != null) {
                            for (var i = 0; i < response.endApprochBids.length; i++) {

                                var listItemToAdd = `    <li class="list-group-item">
                                        <span style="float:left;cursor:pointer" id="Startproject-${response.endApprochBids[i].projectID}" onclick="FilterDashBoard(this)">${response.endApprochBids[i].projectName}</span>
                                        <span style="float:right" class="badge badge-pill badge-warning">${response.endApprochBids[i].approvedBidDate.split("T")[0]}</span>
                                    </li>`

                                $('#EndApproch-list').append(listItemToAdd);
                            }
                        }

                        if (response.startApprochBids != null) {
                            for (var i = 0; i < response.startApprochBids.length; i++) {

                                var listItemToAdd = `    <li class="list-group-item">
                                        <span style="float:left;cursor:pointer" id="Startproject-${response.startApprochBids[i].projectID}" onclick="FilterDashBoard(this)">${response.startApprochBids[i].projectName}</span>
                                        <span style="float:right" class="badge badge-pill badge-success">${response.startApprochBids[i].approvedBidDate.split("T")[0]}</span>
                                    </li>`

                                $('#startApproch-list').append(listItemToAdd);
                            }
                        }

                        if (response.bidStatusByBids != null) {
                            for (var i = 0; i < response.bidStatusByBids.length; i++) {

                                var listItemToAdd = `   <li class="list-group-item">
                                        <span style="float:left;cursor:pointer " id="bidStatus-${response.bidStatusByBids[i].bidStatusID}" onclick="FilterDashBoard(this)">${response.bidStatusByBids[i].bidStatusName}</span>
                                        <span style="float:right" class="badge badge-pill badge-primary">${response.bidStatusByBids[i].bidsCount}</span>
                                    </li>`

                                $('#bidStatus-list').append(listItemToAdd);
                            }
                        }




                        var theadToAdd = ` <tr>
                                <th scope="col">Date Created</th>
                                <th scope="col">Project</th>
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
                    showStatusMsg(false, "success is false", 3000);
                }
            },
            failure: function (response) {
                showStatusMsg(false, "Failed to call the function", 3000);
            },
            error: function (response) {
                showStatusMsg(false, "Something went wrong", 3000);
                console.log(response)
                console.log(response.responseText)


            }
        });
    }
    else {
        showStatusMsg(false, "Please fill in one of the dates to filter", 3000);
    }
}