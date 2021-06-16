class ProductIndexPageController {
    constructor() {
        $(document).ready(() => this.init());
    }
    init() {
        this.initDataTable();
        this.initButtons();
    }
    initButtons() {
        $("#buttonCategories").click(() => productIndexPageController.applyCategories());
        $(document).on('click', '.btn-add-to-cart', function () {
            let productId = $(this).data("id");
            let formData = new FormData();
            formData.append("productId", productId);
            $.ajax({
                url: "ShoppingCart/AddToCart",
                method: "POST",
                data: formData,
                processData: false,
                contentType: false,
                success: function (dataResponse) {
                    if (dataResponse.success) {
                        alert(dataResponse.message);
                        shoppingCartSharedPartialController.setCounterCart(dataResponse.counter);
                    }
                }
            });
        });
    }
    initDataTable() {
        this.datatable = $("#productTable");
        $("#productTable").DataTable({
            "ajax": {
                "url": "/Product/GetList",
                "type": "GET",
                "dataType": "json",
                "data": this.tableData
            },
            "columns": [
                {
                    "data": "productId",
                    "render": function (data, type, row) {
                        return `<button class="btn btn-primary btn-sm btn-add-to-cart" data-id="${data}" ><nobr>Add to Cart</nobr></button>`;
                    }
                },
                {
                    "data": "imagePath",
                    "render": function (data, type, row) {
                        return `<img src="${data.slice(1)}" width = "100px" height = "100px" />`;
                    }
                },
                { "data": "productName" },
                { "data": "width" },
                { "data": "length" },
                { "data": "height" },
                { "data": "weight" },
                { "data": "standardLoad" },
                { "data": "optionalLoad" },
                {
                    "data": "productId",
                    "render": function (data, type, row) {
                        return `<a href="Product/Details?id=${data}" class="btn btn-info"><nobr>More info</nobr></a>`;
                    }
                }
            ]
        });
    }
    getMuscleLoadCheckedValues() {
        var checkedArray = $('.checkbox-muscle-load:checked').map(function () {
            return parseInt($(this).val().toString());
        }).get();
        return checkedArray;
    }
    createCategoriesProductRequestDTO() {
        let muscleLoadRequestDTO = new CategoriesProductRequestDTO();
        muscleLoadRequestDTO.muscleLoadIds = this.getMuscleLoadCheckedValues();
        return muscleLoadRequestDTO;
    }
    applyCategories() {
        let categoriesProductRequestDTO = this.createCategoriesProductRequestDTO();
        $.ajax({
            type: 'POST',
            url: "/Product/GetListCategorized",
            data: { MuscleLoadIds: this.getMuscleLoadCheckedValues() },
            dataType: 'json',
            success: this.populateDataTable,
            error: function (e) {
                console.log("There was an error with your request...");
                console.log("error: " + JSON.stringify(e));
            }
        });
    }
    populateDataTable(dataToTable) {
        this.datatable = $("#productTable").DataTable();
        this.datatable.clear().draw();
        this.datatable.rows.add(dataToTable.data); // Add new data
        this.datatable.columns.adjust().draw(); // Redraw the DataTable
    }
    refreshDataTable() {
        let datatable = $("#productTable").DataTable();
        datatable.ajax.reload();
    }
}
class CategoriesProductRequestDTO {
}
let productIndexPageController = new ProductIndexPageController();
//# sourceMappingURL=productIndex.js.map