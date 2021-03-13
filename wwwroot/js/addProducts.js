﻿// 2021-03-12 Amal Shaiju

var productsAssigned = []

//Populate with already assigned products
try {

    // get al rows to check if there is any product assigned 
    rows = $("#BidproductTable > tbody > tr")

    if (rows.length > 0) {

        // Get all input in colum 5 class
        var txtColumns = $(".column5 :input")

        for (var i = 0; i < txtColumns.length; i++) {

            txtBox = txtColumns[i]; // txt box
            qnty = $(txtBox).val(); // value in txtbox

            txtId = $(txtColumns[i]).attr('id'); // txtbox ID

            var commonId = txtId.split('-').pop(); // CommonID extracted from textbox ID

            // Push the qnty and product ID 
            productsAssigned.push({
                Quantity: parseInt(qnty),
                ProductID: commonId
            });

            console.log(productsAssigned);
        }
    }
}
catch {

}


//Add selecetd list product to product select list
$("#btnAddProduct").click(function () {

    var inputProduct = $("#ProductID option:selected");
    var inputQuantity = $("#ProductQuantity");

    if (inputProduct.val() == "") { // check option is selected
        alert("Please Select a product to add");
    }
    else if (inputQuantity.val() == "") { // check if value is inputed
        alert("Please input a valid quanity");
    }
    else if (ArrayItemFinder(productsAssigned, inputProduct.val())) { // check if array already has the selected value

        alert("Product is already in the list." + "\n" + "Delete the product from the list to edit the quantity");
    }
    else {

        var id = $("#ProductID").val();
        var quantity = $("#ProductQuantity").val();

        // call get products
        $.ajax({
            type: "GET",
            url: getBaseUrl() + 'Bids/GetProduct',
            data: { ID: id },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            beforeSend: function () {
                // Show(); // Show loader icon  
            },
            success: function (response) {
                // Add a new row to the end of the table
                $("#bidProductTable").find('tbody')
                    .append($(`<tr id=row-${response.id} >`)
                        .append($('<td class="column1">').append(`${response.code}`))
                        .append($('<td class="column2">').append(`${response.description}`))
                        .append($('<td class="column3">').append(`${response.size}`))
                        .append($(`<td class="column4" id=price-${response.id}>`).append(`$${response.price}`))
                        .append($('<td class="column5">').append(`<input type="text" disabled id="txt-${response.id}" value="${quantity}" />`))
                        .append($(`<td class="column6" id="total-${response.id}">`).append(`$${response.price * quantity}`))
                        .append($('<td class="column6">').append(`<input type="button" id="edit-${response.id}" class="btn btn-primary" onclick="editRow(this.id)" value="Edit"/><input type="button" style="display:none" id="save-${response.id}" class="btn btn-success" onclick="saveRow(this.id)" value="Save"/>`))
                        .append($('<td class="column6">').append(`<input type="button" id="delete-${response.id}" class="btn btn-danger" onclick="deleteRow(this.id)"  value="Delete" />`))

                );



                productsAssigned.push({
                    Quantity: parseInt(quantity),
                    ProductID: response.id,
                });

                console.log(productsAssigned);
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

$("#btnSubmit").click(function () {

    $("#ProductsAssigned").val(JSON.stringify(productsAssigned));

});


function editRow(id) {
    // convert editID to different ID's
    var commonId = id.split('-').pop();
    var txtboxId = "#txt-" + commonId;
    var saveBtn = "#save-" + commonId;
    var editBtnId = "#" + id;

    // Make the textbox avialable to edit
    $(txtboxId).prop("disabled", false);
    $(txtboxId).css({ "border": "1px solid black", });

    // Show save button and hide edit button
    $(saveBtn).show();
    $(editBtnId).hide();
}


function saveRow(id) {
    var commonId = id.split('-').pop();
    var txtboxId = "#txt-" + commonId;
    var editBtnId = "#edit-" + commonId;
    var saveBtn = "#" + id;;

    updateQnty($(txtboxId).val(), commonId);
    updateTotal(id);

    // Remove the border after saved
    $(txtboxId).removeAttr("style");
    $(txtboxId).prop("disabled", true);

    //after save show edit button
    $(saveBtn).hide();
    $(editBtnId).show();
}



function deleteRow(id) {
    var commonId = id.split('-').pop();
    var rowID = "#row-" + commonId;
    console.log('comm - ' + commonId)
    console.log(productsAssigned[0].ProductID != parseInt(commonId))
    $(rowID).remove();

    productsAssigned = productsAssigned.filter(p => p.ProductID != parseInt(commonId));
    console.log(productsAssigned);
}


function updateTotal(id) {
    var commonId = id.split('-').pop();
    var totalID = "#total-" + commonId;
    var txtboxId = "#txt-" + commonId;
    var priceID = "#price-" + commonId;

    // get the text and remove '$'
    var price = $(priceID).text().split('$').pop();;
    var qnty = $(txtboxId).val();

    // tack the total to the <td>
    $(totalID).text("$" + (parseFloat(price) * parseFloat(qnty)).toFixed(2).toString());

}

//Helper Funtions
function ArrayItemFinder(ary, item) {
    for (var i = 0; i < ary.length; i++) {
        if (ary[i].ProductID == parseInt(item))
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

function updateQnty(qnty, productID) {
    //loop over array
    for (var i = 0; i < productsAssigned.length; i++) {
        if (productID == productsAssigned[i].ProductID) {
            if (productsAssigned[i].Quantity != qnty) {
                productsAssigned[i].Quantity = qnty;
            }
        }
    }

    function deleteProductObj(productID) {
        for (var i = 0; i < productsAssigned.length; i++) {
            if (productID == productsAssigned[i].ProductID) {
                productsAssigned.splice(i, i); 
            }
        }
        console.log(productsAssigned);
    }
        //check if the product id == obj["ProductID"]
            // change corresponding quantity 

}