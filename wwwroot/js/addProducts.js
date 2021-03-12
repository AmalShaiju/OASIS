// 2021-03-12 Amal Shaiju

//Add 
var productsAssigned = []


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

        alert("Product is already in the list."+ "\n"+"Delete the product from the list to edit the quantity");
    }
    else {

        var id = $("#ProductID").val();
        var quantity = $("#ProductQuantity").val();

        // call get products
        $.ajax({
            type: "GET",
            url: '../Bids/GetProduct',
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
                        //.append($('<td class="column5">').append(`x${quantity}`))
                        .append($(`<td class="column6" id="total-${response.id}">`).append(`$${response.price * quantity}`))
                        .append($('<td class="column6">').append(`<input type="button" id="edit-${response.id}" class="btn btn-primary" onclick="editRow(this.id)" value="Edit"/><input type="button" style="display:none" id="save-${response.id}" class="btn btn-success" onclick="saveRow(this.id)" value="Save"/>`))
                        .append($('<td class="column6">').append(`<input type="button" id="delete-${response.id}" class="btn btn-danger" onclick="deleteRow(this.id)"  value="Delete" />`))

                );

                productsAssigned.push({
                    productID: response.id,
                    qnty: parseInt(quantity),
                });

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

function editRow(id) {
    // convert editID to different ID's
    var commonId = id.split('-').pop();
    var txtboxId = "#txt-" + commonId;
    var saveBtn = "#save-" + commonId;
    var editBtnId = "#" + id;

    // Make the textbox avialable to edit
    $(txtboxId).prop("disabled", false);
    $(txtboxId).css({ "border" : "1px solid black", });

    // Show save button and hide edit button
    $(saveBtn).show();
    $(editBtnId).hide();
}


function saveRow(id) {
    var commonId = id.split('-').pop();
    var txtboxId = "#txt-" + commonId;
    var editBtnId = "#edit-" + commonId;
    var saveBtn = "#" + id;;

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
    console.log(productsAssigned[0].productID != parseInt(commonId))
    $(rowID).remove();

    productsAssigned = productsAssigned.filter(p => p.productID != parseInt(commonId));
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
    $(totalID).text("$"+(parseFloat(price) * parseFloat(qnty)).toString());
    
}

//Helper Funtions
function ArrayItemFinder(ary, item) {
    for (var i = 0; i < ary.length; i++) {
        if (ary[i].productID == parseInt(item))
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
