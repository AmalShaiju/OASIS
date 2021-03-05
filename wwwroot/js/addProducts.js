// 2021-02-26 Amal Shaiju

var postBack = [];
var rolePostBack = [];

// Add all assigned product to postBack onload
for (var i = 0; i < $("#selectedProducts option").length; i++) {
    postBack.push($($("#selectedProducts option")[i]).val())
}

// Add all assigned roles to rolePostBack onload
for (var i = 0; i < $("#selectedRoles option").length; i++) {
    rolePostBack.push($($("#selectedRoles option")[i]).val())
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
    else if (ArrayItemFinder(postBack, inputProduct.val())) { // check if array already has the selected value

        alert("Product is already in the list."+ "\n"+"Delete the product from the list to edit the quantity");
    }
    else {
        postBack.push(inputProduct.val())
        $('#selectedProducts').append($(inputProduct).clone());   //clone the selected ddl option  and append it to select list.
        $('#selectedQuantity').append(new Option(inputQuantity.val(), inputQuantity.val())); // create and append the option to the select list using the inputs
    }


});

//Add selecetd Product product to Role select list

$("#btnAddRole").click(function () {

    var inputRole = $("#RoleID option:selected");
    var inputHours = $("#roleHours");

    if (inputRole.val() == "") { // check option is selected
        alert("Please Select a role to add");
    }
    else if (inputHours.val() == "") { // check if value is inputed
        alert("Please input a valid Hour");
    }
    else if (ArrayItemFinder(rolePostBack, inputRole.val())) { // check if array already has the selected value

        alert("Role is already in the list." + "\n" + "Delete the role from the list to edit the hours");
    }
    else {
        rolePostBack.push(inputRole.val())
        $('#selectedRoles').append($(inputRole).clone());  //clone the selected ddl option  and append it to select list.
        $('#requiredHours').append(new Option(inputHours.val(), inputHours.val())); // create and append the option to the select list using the inputs
    }


});

//Remove product from select list
$("#btnProductRemove").click(function () {
    var selecetdProduct = $("#selectedProducts option:selected");
    console.log(selecetdProduct)

    if (selecetdProduct.length > 1) { // check if multiple option is selected
        alert("You can only delete one product at a time");
    }
    else if (selecetdProduct.length < 1) { //chek if no option is selected
        alert("No product to delete");
    }
    else {

        selectedQuantity[selecetdProduct.index()].remove();
        var index = postBack.indexOf($(selecetdProduct).val()); 
        if (index !== -1) {
            postBack.splice(index, 1);
        }
        selecetdProduct.remove();
    }
});

// Remove role from select list
$("#btnRoleRemove").click(function () {
    var selecetdRole = $("#selectedRoles option:selected");

    if (selecetdRole.length > 1) { // check if multiple option is selected
        alert("You can only delete one role at a time");
    }
    else if (selecetdRole.length < 1) { //chek if no option is selected
        alert("No role to delete");
    }
    else {

        requiredHours[selecetdRole.index()].remove(); // remove the hours option parlel to the option selected
        var index = rolePostBack.indexOf($(selecetdRole).val());
        if (index !== -1) {
            rolePostBack.splice(index, 1);
        }
        selecetdRole.remove();

    }

});


$("#btnSubmit").click(function () {
    $('#selectedProducts option').prop('selected', true);
    $('#selectedQuantity option').prop('selected', true);
    $('#selectedRoles option').prop('selected', true);
    $('#requiredHours option').prop('selected', true);
});

//Helper Funtions
function ArrayItemFinder(ary, item) {
    for (var i = 0; i < ary.length; i++) {
        if (ary[i] == item)
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
