// 2021-03-13 Amal Shaiju

var rolesAssigned = []

//Populate with already assigned products
try {

    // get al rows to check if there is any product assigned 
    rows = $("#BidproductTable > tbody > tr")
    if (rows.length > 0) {

        // Get all input in colum 5 class
        var txtColumns = $("#BidLabourTable .column5 :input")
        for (var i = 0; i < txtColumns.length; i++) {

            txtBox = txtColumns[i]; // txt box
            qnty = $(txtBox).val(); // value in txtbox

            txtId = $(txtColumns[i]).attr('id'); // txtbox ID

            var commonId = txtId.split('-').pop(); // CommonID extracted from textbox ID

            // Push the qnty and product ID 
            rolesAssigned.push({
                Hours: parseInt(qnty),
                RoleID: commonId
            });

            console.log(rolesAssigned);
        }
    }
}
catch {

}


//Add selecetd list product to product select list
$("#btnAddRole").click(function () {

    var inputRole = $("#RoleID option:selected");
    var inputHours = $("#roleHours");

    if (inputRole.val() == "") { // check option is selected
        alert("Please Select a product to add");
    }
    else if (inputHours.val() == "") { // check if value is inputed
        alert("Please input a valid quanity");
    }
    else if (LabourArrayItemFinder(rolesAssigned, inputRole.val())) { // check if array already has the selected value

        alert("Role is already in the list");
    }
    else {

        var id = $("#RoleID").val();
        var hours = $("#roleHours").val();

        // call get products
        $.ajax({
            type: "GET",
            url: getBaseUrl() + 'Bids/GetRole',
            data: { ID: id },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            beforeSend: function () {
                // Show(); // Show loader icon  
            },
            success: function (response) {
                console.log(response);
                // Add a new row to the end of the table
                $("#BidLabourTable").find('tbody')
                    .append($(`<tr id=labourRow-${response.id} >`)
                        .append($('<td class="column1">').append(`${response.name}`))
                        .append($(`<td class="column4" id="labourPrice-${response.id}">`).append(`$${response.labourPricePerHr}`))
                        .append($('<td class="column5">').append(`<input type="number" disabled id="labourTxt-${response.id}" value="${hours}" />`))
                        .append($(`<td class="column6" id="labourTotal-${response.id}">`).append(`$${response.labourPricePerHr * hours}`))
                        .append($('<td class="column7">').append(`<input type="button" id="labourEdit-${response.id}" class="btn btn-primary" onclick="labourEditRow(this.id)" value="Edit"/><input type="button" style="display:none" id="labourSave-${response.id}" class="btn btn-success" onclick="labourSaveRow(this.id)" value="Save"/>`))
                        .append($('<td class="column7">').append(`<input type="button" id="labourDelete-${response.id}" class="btn btn-danger" onclick="labourDeleteRow(this.id)"  value="Delete" />`))

                    );



                rolesAssigned.push({
                    Hours: parseInt(hours),
                    RoleID: response.id,
                });

                UpdateRunningTotal()
                console.log(rolesAssigned);
            },
            complete: function () {
                // Hide(); // Hide loader icon  
                console.log(productsAssigned)
            },
            failure: function (jqXHR, textStatus, errorThrown) {
                alert("HTTP Status: " + jqXHR.status + "; Error Text: " + jqXHR.responseText); // Display error message  
            }
        });


    }



});


function labourEditRow(id) {
    // convert editID to different ID's
    var commonId = id.split('-').pop();
    var txtboxId = "#labourTxt-" + commonId;
    var saveBtn = "#labourSave-" + commonId;
    var editBtnId = "#" + id;

    // Make the textbox avialable to edit
    $(txtboxId).prop("disabled", false);
    $(txtboxId).css({ "border": "1px solid black", });

    // Show save button and hide edit button
    $(saveBtn).show();
    $(editBtnId).hide();
}


function labourSaveRow(id) {
    var commonId = id.split('-').pop();
    var txtboxId = "#labourTxt-" + commonId;
    var editBtnId = "#labourEdit-" + commonId;
    var saveBtn = "#" + id;;

    updatehrs($(txtboxId).val(), commonId);
    labourUpdateTotal(id);

    // Remove the border after saved
    $(txtboxId).removeAttr("style");
    $(txtboxId).prop("disabled", true);

    //after save show edit button
    $(saveBtn).hide();
    $(editBtnId).show();
}



function labourDeleteRow(id) {
    var commonId = id.split('-').pop();
    var rowID = "#labourRow-" + commonId;
    console.log('comm - ' + commonId)
    $(rowID).remove();

    rolesAssigned = rolesAssigned.filter(p => p.RoleID != parseInt(commonId));
    console.log(rolesAssigned);
    UpdateRunningTotal()
}


function labourUpdateTotal(id) {
    var commonId = id.split('-').pop();
    var totalID = "#labourTotal-" + commonId;
    var txtboxId = "#labourTxt-" + commonId;
    var priceID = "#labourPrice-" + commonId;

    // get the text and remove '$'
    var price = $(priceID).text().split('$').pop();;
    var qnty = $(txtboxId).val();

    // tack the total to the <td>
    $(totalID).text("$" + (parseFloat(price) * parseFloat(qnty)).toFixed(2).toString());
    UpdateRunningTotal()


}

//Helper Funtions
function LabourArrayItemFinder(ary, item) {
    for (var i = 0; i < ary.length; i++) {
        if (ary[i].RoleID == parseInt(item))
            return true;
    }

    return false;
}

Array.prototype.remove = function () {
    var what, a = arguments, L = a.length, ax;
    while (L && this.length) {
        what = a[--L];
        while ((ax = this.indexOf(what)) !== -1) {
            this.splice(ax, 1);
        }
    }
    return this;
};

function getBaseUrl() {
    var pathArray = location.href.split('/');
    var protocol = pathArray[0];
    var host = pathArray[2];
    var url = protocol + '//' + host + '/';

    return url;
}

function updatehrs(hrs, roleID) {
    //loop over array
    for (var i = 0; i < rolesAssigned.length; i++) {
        if (roleID == rolesAssigned[i].RoleID) {
            if (rolesAssigned[i].Hours != hrs) {
                rolesAssigned[i].Hours = parseInt(hrs);
            }
        }
    }
    console.log(rolesAssigned);

}
function deleteRoleObj(roleID) {
    for (var i = 0; i < rolesAssigned.length; i++) {
        if (roleID == rolesAssigned[i].roleID) {
            rolesAssigned.splice(i, i);
        }
    }
    console.log(rolesAssigned);
}
    
