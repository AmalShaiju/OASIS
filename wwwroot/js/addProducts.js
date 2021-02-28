// 2021-02-26 Amal Shaiju

var postBack = [];

for (var i = 0; i < $("#selectedProducts option").length; i++) {
    postBack.push($($("#selectedProducts option")[i]).val())
}
console.log(postBack)

$("#btnAddProduct").click(function () {
    console.log(postBack)

    var inputProduct = $("#ProductID option:selected");
    var inputQuantity = $("#ProductQuantity");

    if (!(ProductChecker(postBack, inputProduct.val())) && inputProduct.val() != "" && inputQuantity.val() != "") {

        postBack.push(inputProduct.val())


        optionToAdd = inputProduct.text() + "\t" + "-" + "\t" + inputQuantity.val();
        qntyToAdd = inputQuantity.val();

        $('#selectedProducts').append($(inputProduct).clone());
        $('#selectedQuantity').append(new Option(inputQuantity.val(), inputQuantity.val()));
    }

    console.log(postBack);

});
$("#btnSubmit").click(function () {
    $('#selectedProducts option').prop('selected', true);
    $('#selectedQuantity option').prop('selected', true);
});

$("#btnRemove").click(function () {
    var selecetdProduct = $("#selectedProducts option:selected");
    if (selecetdProduct.length > 1) {
        alert("You can only delete one item at a time");


    }
    else if (selecetdProduct.length < 0) {
        alert("please select a product to delete");
    }
    else {

        console.log($("#selectedProducts option:selected").val())
        selectedQuantity[selecetdProduct.index()].remove();
        var index = postBack.indexOf($("#selectedProducts option:selected").val());
        if (index !== -1) {
            postBack.splice(index, 1);
        }
        selecetdProduct.remove();
        
        console.log(postBack)

    }




});


function ProductChecker(ary, product) {
    for (var i = 0; i < ary.length; i++) {
        if (ary[i] == product)
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
