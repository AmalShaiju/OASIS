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
                                tbodyToAdd += `<tr id="${response.objects[i].projectName}-${response.objects[i].id}" onclick="PreviewBid(this)" style="cursor:pointer;">
                                <th scope="row">${response.objects[i].dateCreated.split("T")[0]} </th>
                                <td>${response.objects[i].projectName}</td>
                                <td>$${response.objects[i].estAmount.toFixed(2)}</td>
                                <td>
                                    <a href="${getBaseUrl()}Bids/Edit/${response.objects[i].id}" style="height:28px; width:24%" class="btn btn-outline-primary p-0 mr-3">
                                        <span class="material-icons">
                                            edit
                                                                </span>
                                    </a>
                                    <a href="${getBaseUrl()}Bids/Details/${response.objects[i].id}" style="height:28px; width:24%" class="btn btn-outline-info p-0">
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
                                tbodyToAdd += `<tr id="${response.bids[i].projectName}-${response.bids[i].id}" onclick="PreviewBid(this)" style="cursor:pointer;" style="background:#343a40">
                                <th scope="row">${response.bids[i].dateCreated.split("T")[0]}</th>
                                <th scope="row">${response.bids[i].projectName}</th>
                                <td>$${response.bids[i].estAmount.toFixed(2)}</td>
                                <td>
                                    <a href="${getBaseUrl()}Bids/Edit/${response.bids[i].id}" style="height:28px; width:24%" class="btn btn-outline-primary p-0 mr-3">
                                        <span class="material-icons">
                                            edit
                                                                </span>
                                    </a>
                                    <a href="${getBaseUrl()}Bids/Details/${response.bids[i].id}" style="height:28px; width:24%" class="btn btn-outline-info p-0">
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

function ShowCustomer(e) {

    var id = e.id.split("-")[1];

    if (id != null) {
        $.ajax({
            type: "GET",
            url: "Home/ShowCustomer",
            data: {
                'Id': id
            },
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response != null) {
                    console.log(response);

                    if (response.success) {
                        $('#cus-First').text(response.customer.firstName);
                        $('#cus-Last').text(response.customer.lastName);
                        $('#cus-Middle').text(response.customer.middleName);
                        $('#cus-Pos').text(response.customer.position);
                        $('#cus-Phone').text(response.customer.phone);
                        $('#cus-Email').text(response.customer.email);
                        $('#cusFullName').text(response.customer.fullName)

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

function PreviewBid(e) {
    var id = e.id.split("-")[1];

    if (id != null) {
        $.ajax({
            type: "GET",
            url: "Home/PreviewBid",
            data: {
                'Id': id
            },
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response != null) {
                    console.log(response);

                    if (response.success) {

                        if (response.bidProducts.length != 0) {
                            // products 
                            var bidProductsToAdd;
                            var productSubTotal = 0;
                            for (var i = 0; i < response.bidProducts.length; i++) {
                                bidProductsToAdd += ` <tr>
                                                            <td class="column1">${response.bidProducts[i].code}</td>
                                                            <td class="column2">${response.bidProducts[i].description}</td>
                                                            <td class="column3">$${response.bidProducts[i].price.toFixed(2)}</td>
                                                            <td class="column4">${response.bidProducts[i].quantity}</td>
                                                            <td class="column5">${response.bidProducts[i].size}</td>
                                                            <td class="column6">$${response.bidProducts[i].total.toFixed(2)}</td>
                                                        </tr>`
                                productSubTotal += response.bidProducts[i].total;
                            }

                            bidProductsToAdd += ` <tr>
                                                            <td class="column1"></td>
                                                            <td class="column2"></td>
                                                            <td class="column3"></td>
                                                            <td class="column4"></td>
                                                            <td class="column5" style="color:#7460ee"><strong>SubTotal:</strong></td>
                                                            <td class="column6" style="color:#7460ee"><strong>$${productSubTotal.toFixed(2)}</strong></td>
                                                        </tr>`


                            $('#bidProduct-dash').empty();
                            $('#bidProduct-dash').append(bidProductsToAdd);
                        }

                        // Labours 
                        if (response.bidLabours.length != 0) {

                            var bidLaboursToAdd;
                            var labourSubTotal = 0;

                            for (var i = 0; i < response.bidLabours.length; i++) {
                                bidLaboursToAdd += ` <tr>
                                                            <td class="column1">${response.bidLabours[i].name}</td>
                                                            <td class="column4">${response.bidLabours[i].hours}</td>
                                                            <td class="column5">$${response.bidLabours[i].price.toFixed(2)}</td>
                                                            <td class="column6">$${response.bidLabours[i].total.toFixed(2)}</td>
                                                        </tr>`
                                labourSubTotal += response.bidLabours[i].total;
                            }

                            bidLaboursToAdd += ` <tr>
                                                            <td class="column1"></td>
                                                            <td class="column4"></td>
                                                            <td class="column5" style="color:#7460ee"><strong>SubTotal:</strong></td>
                                                            <td class="column6" style="color:#7460ee"><strong>$${labourSubTotal.toFixed(2)}</strong></td>
                                                        </tr>`

                            $('#bidLabour-dash').empty();
                            $('#bidLabour-dash').append(bidLaboursToAdd);
                        }

                        $('#bidHeading').empty();

                        if (response.bid.length != 0) {
                            if (response.bid.estAmount != null) {
                                $('#bid-Amount').text(`Estimate: $${response.bid.estAmount.toFixed(2)}`)

                            }

                            if (response.bid.budget != null) {
                                $('#bid-Budget').text(`Budget: $${response.bid.budget.toFixed(2)}`)

                            }


                            if (response.bid.estBidEndDate != null) {
                                $('#bid-EndDate').text(`Estimated End Date: ${response.bid.estBidEndDate.split("T")[0]}`)

                            }

                            if (response.bid.estBidStartDate != null) {
                                $('#bid-StartDate').text(`Estimated Start Date: ${response.bid.estBidStartDate.split("T")[0]}`)

                                var bidSummary = `<a class="btn-link" style="Color:white" href="/Bids/Details/${response.bid.id}"> ${e.id.split("-")[0]}: ${response.bid.estBidStartDate.split("T")[0]}</a>`;
                                $('#bidHeading').append(bidSummary);
                            }
                            if (response.bid.createdOn != null) {
                                $('#bid-CreatedOn').text(`Estimated Start Date: ${response.bid.createdOn.split("T")[0]}`)

                            }
                            if (response.bid.dateCreated != null) {
                                $('#bid-createdOn').text(`Created On: ${response.bid.dateCreated.split("T")[0]}`)

                            }

                            if (response.bid.updatedOn != null) {
                                $('#bid-updateOn').text(`Updated On: ${response.bid.updatedOn.split("T")[0]}`)

                            }


                        }

                        $('#bid-ManDisApproveBid').empty();
                        $('#bid-ManApproveBid').empty();
                        $('#bid-ClientDisapproveBid').empty()
                        $('#bid-ClientApproveBid').empty();
                        $('#bidStartStop').empty();

                        if (response.bid.approval != null) {

                            if (response.bid.approval.clientStatus.name == "RequiresApproval") {
                                var btnClientApprove = `<a href="/Home/UpdateApproval?approvalType=client&bidId=${response.bid.id}&approvalStatusName=Approved" class="btn btn-outline-success">Approve</a>`
                                $('#bid-ClientApproveBid').append(btnClientApprove);

                                var btnClientDisApprove = `<a href="/Home/UpdateApproval?approvalType=client&bidId=${response.bid.id}&approvalStatusName=Disapproved" class="btn btn-outline-danger">DisApprove</a>`
                                $('#bid-ClientDisapproveBid').append(btnClientDisApprove);

                            }
                            else {
                                if (response.bid.approval.clientStatus.name == "Disapproved") {
                                    var btnClientApprove = `<a href="/Home/UpdateApproval?approvalType=client&bidId=${response.bid.id}&approvalStatusName=Approved" class="btn btn-outline-success">Approve</a>`
                                    $('#bid-ClientApproveBid').append(btnClientApprove);
                                }
                                else {
                                    var btnClientDisApprove = `<a href="/Home/UpdateApproval?approvalType=client&bidId=${response.bid.id}&approvalStatusName=Disapproved" class="btn btn-outline-danger">DisApprove</a>`
                                    $('#bid-ClientDisapproveBid').append(btnClientDisApprove);
                                }
                            }

                            if (response.bid.approval.designerStatus.name == "RequiresApproval") {

                                var btnManApprove = `<a href="/Home/UpdateApproval?approvalType=designer&bidId=${response.bid.id}&approvalStatusName=Approved" class="btn btn-outline-success">Approve</a>`
                                $('#bid-ManApproveBid').append(btnManApprove);

                                var btnManDisApprove = `<a  href="/Home/UpdateApproval?approvalType=designer&bidId=${response.bid.id}&approvalStatusName=Disapproved" class="btn btn-outline-danger">DisApprove</a>`
                                $('#bid-ManDisApproveBid').append(btnManDisApprove);
                            }
                            else {
                                if (response.bid.approval.designerStatus.name == "Disapproved") {
                                    var btnManApprove = `<a href="/Home/UpdateApproval?approvalType=designer&bidId=${response.bid.id}&approvalStatusName=Approved"  class="btn btn-outline-success">Approve</a>`
                                    $('#bid-ManApproveBid').append(btnManApprove);
                                }
                                else {
                                    var btnManDisApprove = `<a href="/Home/UpdateApproval?approvalType=designer&bidId=${response.bid.id}&approvalStatusName=Disapproved"  class="btn btn-outline-danger">DisApprove</a>`
                                    $('#bid-ManDisApproveBid').append(btnManDisApprove);
                                }
                            }

                            if (response.bid.projectStartDate == null) {
                                var btnStart = ` <button onclick="UpdateBidActualDate(this)" id="bidStart-${response.bid.id}" class="btn btn-outline-success" style="display:flex">
                                                <span class="material-icons">
                                                    play_arrow
                                                </span>
                                                Start Bid
                                            </button>`


                                $('#bidStartStop').append(btnStart);
                            }

                            if (response.bid.projectStartDate != null && response.bid.projectEndDate == null) {
                                var btnStart = ` <button onclick="UpdateBidActualDate(this)" id="bidStop-${response.bid.id}" class="btn btn-outline-danger" style="display:flex">
                                               <span class="material-icons">
                                                    stop
                                                </span>
                                                Stop Bid
                                            </button>`


                                $('#bidStartStop').append(btnStart);
                            }


                        }

                        



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

function UpdateBidActualDate(e) {
    var id = e.id.split("-")[1];
    console.log(id);
    $.ajax({
        type: "GET",
        url: "Bids/PopulateStartDate",
        data: {
            'id': id
        },
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response != null) {
                console.log(response);

                if (response.success) {
                    var k = { id: e.id };
                    PreviewBid(k);

                    showStatusMsg(response.success, response.msg, 1000);
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